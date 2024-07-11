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

        public bool AllUserLoginPasswordCreated()
        {
            try
            {
                List<PersonData> personData = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(x=>x.employee_type_).ToList();
                for (int i=0; i < personData.Count; i++)
                {
                    int a = personData[i].persons_id ??= 100;
                    int num = a + 2024;
                    string login = personData[i].persons_.firstName.Trim() + num + "@" + "tstu";
                    string password = PasswordManager.EncryptPassword(login + (personData[i].persons_.firstName.Trim() + num));
                    User user = new User
                    {
                        login = login,
                        password = password,
                        user_type_id = _context.user_types_20ts24tu.FirstOrDefault(x => x.type == SessionClass.UserTypeId(personData[i].persons_.employee_type_.title.Trim())).id,
                        person_id = personData[i].persons_id,
                        status_id = 1
                    };
                    _context.users_20ts24tu.Add(user);
                    _context.SaveChanges();
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
