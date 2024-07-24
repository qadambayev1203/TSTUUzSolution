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
        public async Task<ActionResult<UserAuthInfoDTO>> LoginAsync([FromBody] UserCredentials credentials, CancellationToken cancellationToken)
        {
            return await HandleLoginAsync(credentials, cancellationToken, false, credentials.CaptchaNumbersSumm);
        }

        //[AllowAnonymous]
        //[HttpPost("loginhemis")]
        //public async Task<ActionResult<UserAuthInfoDTO>> LoginAsyncHemis([FromBody] UserCredentialsHemis credentials, CancellationToken cancellationToken)
        //{
        //    if (credentials == null)
        //    {
        //        return BadRequest("No data");
        //    }

        //    string passportNumber = "AA1234567";
        //    string pinfl = "12345678901234";

        //    try
        //    {
        //        var url = "https://student.tstu.uz/rest/v1/account/me";
        //        var request = new HttpRequestMessage(HttpMethod.Get, url);
        //        request.Headers.Add("Authorization", $"Bearer {credentials.hemis_token}");
        //        request.Headers.Add("accept", "application/json");

        //        var response = await _httpClient.SendAsync(request);
        //        var responseContent = await response.Content.ReadAsStringAsync();

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var jsonDocument = JsonDocument.Parse(responseContent);
        //            var root = jsonDocument.RootElement;

        //            if (root.TryGetProperty("data", out JsonElement dataElement))
        //            {
        //                passportNumber = dataElement.GetProperty("passport_number").GetString() ?? passportNumber;
        //                pinfl = dataElement.GetProperty("passport_pin").GetString() ?? pinfl;
        //            }
        //            else
        //            {
        //                return BadRequest("Hemis token invalid");
        //            }
        //        }
        //        else
        //        {
        //            return BadRequest("Hemis token invalid");
        //        }
        //    }
        //    catch
        //    {
        //        return BadRequest("Hemis token invalid");
        //    }

        //    var hemisCredentials = new UserCredentials
        //    {
        //        Login = passportNumber,
        //        Password = pinfl,
        //        CaptchaNumbersSumm = 0
        //    };

        //    return await HandleLoginAsync(hemisCredentials, cancellationToken, true, 0);
        //}

        private async Task<ActionResult<UserAuthInfoDTO>> HandleLoginAsync(UserCredentials credentials, CancellationToken cancellationToken, bool isHemis, int captcha)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (token != SessionClass.tokenCheck && token != SessionClass.token)
            {
                return Unauthorized();
            }

            if (credentials == null)
            {
                return BadRequest("No data");
            }

            if (!isHemis)
            {
                var capt = captcheck.CheckCaptcha(captcha);
                if (!capt)
                {
                    return BadRequest("Captcha failed!");
                }
            }

            credentials.Password = !isHemis ? credentials.Password = PasswordManager.EncryptPassword((credentials.Login + credentials.Password).ToString()) : credentials.Password;

            var user = isHemis ? await repositoryManager.User.LoginAsyncHemis(credentials.Login, credentials.Password, false, cancellationToken)
                                : await repositoryManager.User.LoginAsync(credentials.Login, credentials.Password, false, cancellationToken);

            if (user == null)
            {
                return Unauthorized("Error login");
            }

            if (isHemis)
            {
                _logger.LogInformation($"Get By Passport number and Pinfl - User {JsonConvert.SerializeObject(credentials)}");
            }
            else
            {
                _logger.LogInformation($"Get By Login and Password - User {JsonConvert.SerializeObject(credentials)}");
            }

            try
            {
                var key = Encoding.ASCII.GetBytes(appSettings.Value.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("UserId", user.id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.login.ToString()),
                new Claim(ClaimTypes.Role, user.user_type_.type.ToString())
            }),
                    Expires = DateTime.UtcNow.AddDays(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                var authInfo = new UserAuthInfoDTO
                {
                    Token = securityTokenHandler.WriteToken(securityToken),
                    UserDetails = mapper.Map<UserDTO>(user)
                };

                SessionClass.token = "Bearer " + authInfo.Token;
                SessionClass.id = authInfo.UserDetails.id;

                return Ok(authInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating token");
                return Unauthorized("Error generating token");
            }
        }


        [Authorize]
        [HttpGet("verification")]
        public IActionResult TokenCheckModel()
        {
            try
            {
                string authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();
                string token = authorizationHeader.Substring("Bearer ".Length);
                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest("Token is empty");
                }

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
                int userId = Convert.ToInt32(principal.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value);

                if (userId == 0)
                {
                    return Unauthorized("Invalid user ID");
                }

                SessionClass.id = userId;
                SessionClass.token = authorizationHeader;

                if (!principal.Identity.IsAuthenticated)
                {
                    return Unauthorized("Authentication failed");
                }

                return Ok(new TokenVerify { verification = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Invalid token");
                return Unauthorized("Invalid token");
            }
        }



        [Authorize]
        [HttpPut("userprofilupdated")]
        public async Task<IActionResult> UserProfilUpdatedAsync(UserProfilUpdatedDTO user)
        {
            try
            {
                var tokenCheckResult = TokenCheckModel();

                if (SessionClass.id == 0)
                {
                    return Unauthorized();
                }

                var userU = mapper.Map<User>(user);

                var fileUpload = new FileUploadRepository();
                var url = fileUpload.SaveFileAsync(user.img_up);

                if (url == "File not found or empty!" || url == "Invalid file extension!" || url == "Error!")
                {
                    return BadRequest("File creation error!");
                }

                if (!string.IsNullOrEmpty(url))
                {
                    userU.person_.img_ = new Files
                    {
                        title = Guid.NewGuid().ToString(),
                        url = url
                    };
                }

                if (userU != null)
                {
                    var oldPassw = user.oldPassword;
                    var updateResult = _repository.UpdateUserProfil(userU, oldPassw);
                    if (updateResult)
                    {
                        return Ok(true);
                    }
                }

                return BadRequest("Profile update failed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user profile");
                return StatusCode(401, "Bad Request");
            }
        }



    }

}
