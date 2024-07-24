using AutoMapper;
using Contracts.AllRepository.AppealsToRectorRepository;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Attributes;
using TSTUWebAPI.Captcha;

namespace TSTUWebAPI.Controllers.CaptchaControllers
{
    [Route("api/captcha")]
    [ApiController]
    public class CaptchaController : ControllerBase
    {
        private readonly CaptchaCheck captcheck;
        public CaptchaController(CaptchaCheck _captcha)
        {
            captcheck = _captcha;
        }

        [StaticAuth]
        [HttpGet("getcaptchanumbers")]
        public IActionResult GetCaptchaNumbers()
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (token == SessionClass.tokenCheck || token == SessionClass.token)
            {
                CaptchaModel captcha = captcheck.GetCaptchNumbers();
                return Ok(captcha);
            }
            return Unauthorized();

        }

        [StaticAuth]
        [HttpGet("birthdaynull")]
        public IActionResult BirthdayNull(string password)
        {
            bool check = captcheck.BirthdayNull(password);
            if (check) { return Ok(); }
            return NoContent();

        }

        //[StaticAuth]
        //[HttpGet("alluserprofilcreated")]
        //public IActionResult AllUserProfilCreated()
        //{
        //    //bool check = captcheck.AllUserLoginPasswordCreated();
        //    bool check = captcheck.BirthdayNull("pass1for$");
        //    if (check) { return Ok(); }
        //    return NoContent();

        //}
    }
}
