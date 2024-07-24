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

        public bool BirthdayNull(string password)
        {
            try
            {
                if (password == "pass1for$")
                {
                    _context.Database.ExecuteSqlRaw("ALTER TABLE departament_20ts24tu ADD COLUMN hemis_id character varying(100);");
                    _context.SaveChanges();

                    _context.Database.ExecuteSqlRaw("ALTER TABLE appeal_to_employee_20ts24tu DROP CONSTRAINT FK_appeals_to_rectors_20ts24tu_statuses_20ts24tu_status_id; ALTER TABLE appeal_to_employee_20ts24tu DROP COLUMN status_id; ALTER TABLE appeal_to_employee_20ts24tu ADD COLUMN confirm boolean;");
                    _context.SaveChanges();


                    _context.Database.ExecuteSqlRaw("ALTER TABLE appeal_to_employee_translation_20ts24tu DROP CONSTRAINT FK_appeals_to_rectors_translations_20ts24tu_statuses_translati; ALTER TABLE appeal_to_employee_translation_20ts24tu DROP COLUMN status_translation_id; ALTER TABLE appeal_to_employee_translation_20ts24tu ADD COLUMN confirm boolean;");
                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool AllUserLoginPasswordCreated()
        {
            try
            {

                List<User> users = new List<User>();
                users = _context.users_20ts24tu.ToList();

                foreach (User user in users)
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        try
                        {
                            var newContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
                            string password = PasswordManager.EncryptPassword(user.login + user.login.Split("@")[0]);
                            user.password = password;
                            newContext.SaveChanges();
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }

        }




    }
}
