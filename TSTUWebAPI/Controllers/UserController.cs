using AutoMapper;
using Contracts;
using Contracts.AllRepository.ProfilsRepository;
using Entities.DTO;
using Entities.DTO.UserProfilDTOS;
using Entities.Model;
using Entities.Model.AnyClasses;
using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.FileModel;
using Entities.Model.SiteDetailsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using TSTUWebAPI.Captcha;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers
{
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

        public UserController(IRepositoryManager repositoryManager, IOptions<AppSettings> appSettings, IMapper mapper, ILogger<UserController> logger, CaptchaCheck _captcheck, IProfilRepository repository, HttpClient httpClient)
        {
            this.repositoryManager = repositoryManager;
            this.appSettings = appSettings;
            this.mapper = mapper;
            this.securityTokenHandler = new JwtSecurityTokenHandler();
            this._logger = logger;
            captcheck = _captcheck;
            this._repository = repository;
            _httpClient = httpClient;
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

                SessionClass.token = "Bearer " + authInfo.Token;
                SessionClass.id = authInfo.UserDetails.id;
                return Ok(authInfo);
            }
            return Unauthorized();
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


        //        var capt = captcheck.CheckCaptcha(credentials.CaptchaNumbersSumm);
        //        if (!capt)
        //        {
        //            return BadRequest("Captcha failed!");
        //        }


        //        //hemis
        //        string passportNumber = "AA1234567";
        //        string pinfl = "12345678901234";

        //        try
        //        {
        //            var url = "https://student.tstu.uz/rest/v1/account/me";

        //            var request = new HttpRequestMessage(HttpMethod.Get, url);
        //            request.Headers.Add("Authorization", $"Bearer {credentials.hemis_token}");
        //            request.Headers.Add("accept", "application/json");

        //            var response = await _httpClient.SendAsync(request);

        //            var responseContent = await response.Content.ReadAsStringAsync();

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var jsonDocument = JsonDocument.Parse(responseContent);
        //                var root = jsonDocument.RootElement;

        //                if (root.TryGetProperty("data", out JsonElement dataElement))
        //                {
        //                    passportNumber = dataElement.GetProperty("passport_number").GetString() != null ? dataElement.GetProperty("passport_number").GetString() : passportNumber;
        //                    pinfl = dataElement.GetProperty("passport_pin").GetString() != null ? dataElement.GetProperty("passport_pin").GetString() : pinfl;
        //                }
        //                else
        //                {
        //                    return BadRequest("Hemis token invalid");
        //                }
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
        //        // endhemis

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
                TokenCheckModel();
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

}
