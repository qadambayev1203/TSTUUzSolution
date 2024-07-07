using Entities;
using Entities.Model.AnyClasses;
using Microsoft.EntityFrameworkCore;

namespace TSTUWebAPI.Captcha
{
    public class CaptchaCheck
    {
        public static CaptchaModel _captcha;
        private static RepositoryContext _context { get; set; }
        public CaptchaCheck(RepositoryContext context)
        {
            _context = context;
        }


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
            try
            {
                if (_captcha == null)
                {
                    _captcha = new CaptchaModel()
                    {
                        num1 = 125,
                        num2 = 12522
                    };
                }

                int sum1 = _captcha.num1 + _captcha.num2;
                _captcha = new CaptchaModel();
                if (sum == sum1)
                {
                    _captcha = new CaptchaModel()
                    {
                        num1 = 125,
                        num2 = 12542
                    };
                    return true;
                }
                _captcha = new CaptchaModel()
                {
                    num1 = 125,
                    num2 = 125423
                };
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool BirthdayNull()
        {
            try
            {
                _context.Database.ExecuteSqlRaw("UPDATE public.persons_data_20ts24tu SET  birthday=null, experience_year=0; UPDATE public.persons_data_translations_20ts24tu SET  birthday=null, experience_year=0;");
                _context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

    }
}
