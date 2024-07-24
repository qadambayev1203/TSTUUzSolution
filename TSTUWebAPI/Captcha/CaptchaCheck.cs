using Entities;
using Entities.DTO.UserCrudDTOS;
using Entities.DTO;
using Entities.Model.AnyClasses;
using Entities.Model.PersonDataModel;
using Microsoft.EntityFrameworkCore;
using System;
using Entities.Model;

namespace TSTUWebAPI.Captcha
{
    public class CaptchaCheck
    {
        public static CaptchaModel _captcha;
        private readonly IServiceScopeFactory _scopeFactory;

        private static RepositoryContext _context { get; set; }
        public CaptchaCheck(RepositoryContext context, IServiceScopeFactory scopeFactory)
        {
            _context = context;
            _scopeFactory = scopeFactory;
            _scopeFactory = scopeFactory;
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
        
    }
}
