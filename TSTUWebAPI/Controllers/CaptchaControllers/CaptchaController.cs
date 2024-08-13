using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Attributes;
using TSTUWebAPI.Captcha;

namespace TSTUWebAPI.Controllers.CaptchaControllers;

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
   
   
}
