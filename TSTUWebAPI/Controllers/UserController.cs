using AutoMapper;
using Contracts;
using Contracts.AllRepository.ProfilsRepository;
using Entities.DTO;
using Entities.DTO.UserProfilDTOS;
using Entities.Model;
using Entities.Model.AnyClasses;
using Entities.Model.FileModel;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using TSTUWebAPI.Captcha;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers;

[Route("api/user")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IRepositoryManager repositoryManager;
    private readonly IProfilRepository _repository;
    private readonly IOptions<AppSettings> appSettings;
    private readonly IMapper mapper;
    private readonly JwtSecurityTokenHandler securityTokenHandler;
    private readonly ILogger<UserController> _logger;
    private UserAuthInfoDTO authInfo;
    private User user;
    private readonly CaptchaCheck captcheck;
    private readonly HttpClient _httpClient;
    private readonly IHttpClientFactory _clientFactory;

    public UserController(
        IRepositoryManager repositoryManager,
        IOptions<AppSettings> appSettings,
        IMapper mapper, ILogger<UserController> logger,
        CaptchaCheck _captcheck, IProfilRepository repository,
        HttpClient httpClient,
        IHttpClientFactory clientFactory)
    {
        this.repositoryManager = repositoryManager;
        this.appSettings = appSettings;
        this.mapper = mapper;
        this.securityTokenHandler = new JwtSecurityTokenHandler();
        this._logger = logger;
        captcheck = _captcheck;
        this._repository = repository;
        _httpClient = httpClient;
        _clientFactory = clientFactory;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<UserAuthInfoDTO>> LoginAsync([FromBody] UserCredentials credentials, CancellationToken cancelationToken)
    {
        var token = HttpContext.Request.Headers["Authorization"];
        if (token == SessionClass.tokenCheck || token == SessionClass.token)
        {
            authInfo = new UserAuthInfoDTO();
            if (credentials == null)
            {
                return BadRequest("No data");
            }


            var capt = captcheck.CheckCaptcha(credentials.CaptchaNumbersSumm);
            if (!capt)
            {
                return BadRequest("Captcha failed!");
            }

            credentials.Password = PasswordManager.EncryptPassword((credentials.Login + credentials.Password).ToString());


            user = await repositoryManager.User.LoginAsync(credentials.Login, credentials.Password, false, cancelationToken);
            if (user != null)
            {
                _logger.LogInformation($"Get By Login and Password - User " + JsonConvert.SerializeObject(credentials));
                try
                {
                    var key = Encoding.ASCII.GetBytes(appSettings.Value.SecretKey);
                    var tokenDescriptoir = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(
                            new Claim[]
                            {
                        new Claim("UserId", user.id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.login.ToString()),
                        new Claim(ClaimTypes.Role, user.user_type_.type.ToString()),
                            }
                           ),
                        Expires = DateTime.UtcNow.AddDays(20),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    };
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptoir);
                    authInfo.Token = securityTokenHandler.WriteToken(securityToken);
                    authInfo.UserDetails = mapper.Map<UserDTO>(user);
                }
                catch { }
            }
            if (string.IsNullOrEmpty(authInfo?.Token))
            {
                return Unauthorized("Error login or password");
            }

            SessionClass.id = authInfo.UserDetails.id;
            SessionClass.token = "Bearer " + authInfo.Token;

            return Ok(authInfo);
        }
        return Unauthorized();
    }

    [AllowAnonymous]
    [HttpPost("auth2hemis")]
    public async Task<ActionResult<UserAuthInfoDTO>> Auth2HemisAsync([FromBody] OAuth2Credentials credentials, CancellationToken cancelationToken)
    {
        var authInfo = new UserAuthInfoDTO();

        if (credentials == null || string.IsNullOrEmpty(credentials.OAuth2Code))
        {
            return BadRequest("No data or invalid OAuth2 code");
        }

        // OAuth2 token olish
        var accessToken = await GetOAuth2AccessTokenAsync(credentials.OAuth2Code);
        if (accessToken == null)
        {
            return Unauthorized("OAuth2 token olishda xatolik yuz berdi");
        }

        // Foydalanuvchi ma'lumotlarini token orqali olish
        OAuth2UserDTO oAuthUser = await GetUserFromOAuth2TokenAsync(accessToken);
        if (oAuthUser == null)
        {
            return Unauthorized("Foydalanuvchi ma'lumotlarini olishda xatolik yuz berdi");
        }

        // Foydalanuvchini passportNumber va Jshshir bo'yicha bazadan topish
        var user = await repositoryManager.User.LoginAsyncHemis(oAuthUser.PassportNumber, oAuthUser.Jshshir, false, cancelationToken);
        if (user == null)
        {
            return Unauthorized("Bazadan foydalanuvchini topish imkonsiz");
        }

        try
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Value.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim("UserId", user.id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.login.ToString()),
                new Claim(ClaimTypes.Role, user.user_type_.type.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
            authInfo.Token = securityTokenHandler.WriteToken(securityToken);
            authInfo.UserDetails = mapper.Map<UserDTO>(user);
        }
        catch
        {
            return Unauthorized("Token yaratishda xatolik yuz berdi");
        }

        if (string.IsNullOrEmpty(authInfo?.Token))
        {
            return Unauthorized("Token yaratilmadi");
        }

        // SessionClass yangilash
        SessionClass.id = authInfo.UserDetails.id;
        SessionClass.token = "Bearer " + authInfo.Token;

        return Ok(authInfo);
    }

    private async Task<string> GetOAuth2AccessTokenAsync(string authorizationCode)
    {
        var tokenUrl = "https://hemis.tstu.uz/oauth/access-token";
        var clientId = "8";
        var clientSecret = "Vt5dnZtzK_v3vzs0ycsV2uLzrh7zicZUrz4TEiOI";
        var redirectUri = "http://your-app-url/api/oauth/callback";

        var client = _clientFactory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Post, tokenUrl);

        var parameters = new Dictionary<string, string>
    {
        {"grant_type", "authorization_code"},
        {"code", authorizationCode},
        {"client_id", clientId},
        {"client_secret", clientSecret},
        {"redirect_uri", redirectUri}
    };

        request.Content = new FormUrlEncodedContent(parameters);
        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();
        var tokenData = JsonConvert.DeserializeObject<OAuth2TokenResponse>(content);
        return tokenData?.AccessToken;
    }

    private async Task<OAuth2UserDTO> GetUserFromOAuth2TokenAsync(string accessToken)
    {
        var apiUrl = "https://univer.hemis.uz/oauth/api/user?fields=id,uuid,employee_id_number,type,roles,name,login,email,picture,firstname,surname,patronymic,birth_date,university_id,phone";

        var client = _clientFactory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();
        var userData = JsonConvert.DeserializeObject<OAuth2UserDTO>(content);
        return userData;
    }




    [Authorize]
    [HttpGet("verification")]
    public IActionResult TokenCheckModel()
    {
        try
        {
            string token1 = HttpContext.Request.Headers["Authorization"].ToString();
            int prefixLength = "Bearer ".Length;
            string token = token1.Substring(prefixLength);
            if (string.IsNullOrEmpty(token))
                return BadRequest();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Value.SecretKey);


            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            int user_id = Convert.ToInt32(principal.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value);
            if (user_id != 0)
            {
                SessionClass.id = user_id;
                SessionClass.token = token1;
            }
            var check = principal.Identity.IsAuthenticated;

            if (!check)
            {
                return StatusCode(401);
            }

            TokenVerify tokenVerify = new TokenVerify()
            {
                verification = true
            };
            return Ok(tokenVerify);

        }
        catch
        {
            _logger.LogInformation($"invalid token");
            return StatusCode(401);
        }
    }


    [Authorize]
    [HttpPut("userprofilupdated")]
    public IActionResult UserProfilUpdated(UserProfilUpdatedDTO user)
    {
        try
        {
            if (SessionClass.id != 0)
            {
                User userU = mapper.Map<User>(user);

                FileUploadRepository fileUpload = new FileUploadRepository();

                var Url = fileUpload.SaveFileAsync(user.img_up);

                if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url != null && Url.Length > 0)
                {
                    userU.person_.img_ = new Files
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url
                    };
                }

                if (userU != null)
                {
                    string oldPassw = user.oldPassword;
                    bool check = _repository.UpdateUserProfil(userU, oldPassw);
                    if (check) { return Ok(true); }
                }
                return BadRequest();
            }


            return Unauthorized();


        }
        catch
        {
            _logger.LogInformation($"invalid token");
            return StatusCode(401);
        }
    }

}




//[AllowAnonymous]
//[HttpPost("loginhemis")]
//public async Task<ActionResult<UserAuthInfoDTO>> LoginAsyncHemis([FromBody] UserCredentialsHemis credentials, CancellationToken cancelationToken)
//{
//    var token = HttpContext.Request.Headers["Authorization"];
//    if (token == SessionClass.tokenCheck || token == SessionClass.token)
//    {
//        authInfo = new UserAuthInfoDTO();
//        if (credentials == null)
//        {
//            return BadRequest("No data");
//        }

//        #region hemis
//        string passportNumber = "AA1234567";
//        string pinfl = "12345678901234";

//        try
//        {
//            var url = "https://api.example.com/data";

//            var request = new HttpRequestMessage(HttpMethod.Get, url);
//            request.Headers.Add("Authorization", credentials.hemis_token);

//            var response = await _httpClient.SendAsync(request);

//            var responseContent = await response.Content.ReadAsStringAsync();

//            if (response.IsSuccessStatusCode)
//            {
//                var jsonDocument = JsonDocument.Parse(responseContent);
//                var root = jsonDocument.RootElement;
//                passportNumber = root.GetProperty("passportNumber").GetString() != null ? root.GetProperty("passportNumber").GetString() : passportNumber;
//                passportNumber = root.GetProperty("pinfl").GetString() != null ? root.GetProperty("pinfl").GetString() : pinfl;
//            }
//            else
//            {
//                return BadRequest("Hemis token invalid");
//            }
//        }
//        catch
//        {
//            return BadRequest("Hemis token invalid");
//        }
//        #endregion

//        user = await repositoryManager.User.LoginAsyncHemis(passportNumber, pinfl, false, cancelationToken);
//        if (user != null)
//        {
//            _logger.LogInformation($"Get By Login and Password - User " + JsonConvert.SerializeObject(credentials));
//            try
//            {
//                var key = Encoding.ASCII.GetBytes(appSettings.Value.SecretKey);
//                var tokenDescriptoir = new SecurityTokenDescriptor()
//                {
//                    Subject = new ClaimsIdentity(
//                        new Claim[]
//                        {
//                    new Claim("UserId", user.id.ToString()),
//                    new Claim(ClaimTypes.NameIdentifier, user.login.ToString()),
//                    new Claim(ClaimTypes.Role, user.user_type_.type.ToString()),
//                        }
//                       ),
//                    Expires = DateTime.UtcNow.AddDays(20),
//                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
//                };
//                var securityToken = securityTokenHandler.CreateToken(tokenDescriptoir);
//                authInfo.Token = securityTokenHandler.WriteToken(securityToken);
//                authInfo.UserDetails = mapper.Map<UserDTO>(user);
//            }
//            catch { }
//        }
//        if (string.IsNullOrEmpty(authInfo?.Token))
//        {
//            return Unauthorized("Hemis token invalid");
//        }

//        SessionClass.token = "Bearer " + authInfo.Token;
//        SessionClass.id = authInfo.UserDetails.id;
//        return Ok(authInfo);
//    }
//    return Unauthorized();
//}
