using Entities.Model.AnyClasses;

namespace TSTUWebAPI.Captcha
{
    public class CaptchaCheck
    {
        public static CaptchaModel _captcha;


        public CaptchaModel GetCaptchNumbers()
        {
            Random rnd = new Random();
            _captcha = new CaptchaModel()
            {
                num1 = rnd.Next(0, 10),
                num2 = rnd.Next(0, 10)
            };
            return _captcha;
        }
        public bool CheckCaptcha(int sum)
        {
            
            int sum1 = _captcha.num1+_captcha.num2;
            _captcha = new CaptchaModel();
            if (sum == sum1)
            {
                return true;
            }
            _captcha = new CaptchaModel(); 
            return false;
        }
    }
}
