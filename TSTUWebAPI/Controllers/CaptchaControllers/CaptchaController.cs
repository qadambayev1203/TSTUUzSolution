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
        public IActionResult BirthdayNull()
        {
            bool check = captcheck.BirthdayNull();
            if (check) { return Ok(); }
            return NoContent();

        }

        //[StaticAuth]
        //[HttpGet("alluserprofilcreated")]
        //public IActionResult AllUserProfilCreated()
        //{
        //    bool check = captcheck.AllUserLoginPasswordCreated();
        //    if (check) { return Ok(); }
        //    return NoContent();

        //}
    }
}
