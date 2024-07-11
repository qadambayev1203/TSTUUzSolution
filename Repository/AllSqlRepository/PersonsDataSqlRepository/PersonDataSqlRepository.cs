using Entities.Model.PersonDataModel;
using Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contracts.AllRepository.PersonsDataRepository;
using System.Net;
using Entities.Model.PersonModel;
using Entities.Model.DepartamentsModel;
using Entities.Model;
using Entities.Model.AnyClasses;
using Entities.DTO.UserCrudDTOS;
using Entities.DTO;

namespace Repository.AllSqlRepository.PersonDatasDataSqlRepository
{
    public class PersonDataSqlRepository : IPersonDataRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<PersonDataSqlRepository> _logger;
        public PersonDataSqlRepository(RepositoryContext repositoryContext, ILogger<PersonDataSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }


        //PersonData CRUD
        public IEnumerable<PersonData> AllPersonDataSite(int queryNum, int pageNum)
        {
            try
            {
                var personDatas = new List<PersonData>();
                if (queryNum == 0 && pageNum != 0)
                {
                    personDatas = _context.persons_data_20ts24tu
                        .Include(x => x.persons_).ThenInclude(y => y.img_)
                        .Include(x => x.persons_).ThenInclude(y => y.departament_).ThenInclude(y => y.img_)
                        .Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.status_)
                        .Where(x => x.status_.status != "Deleted").Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    personDatas = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_)
                        .Where(x => x.status_.status != "Deleted").Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    personDatas = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted")
                        .ToList();

                }
                return personDatas;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return Enumerable.Empty<PersonData>();
            }
        }

        public IEnumerable<PersonData> AllPersonDataDepId(int department_id)
        {
            try
            {
                var personDatas = new List<PersonData>();
                if (department_id != 0)
                {
                    personDatas = _context.persons_data_20ts24tu
                        .Include(x => x.persons_).ThenInclude(y => y.img_)
                        .Include(x => x.persons_).ThenInclude(y => y.departament_).ThenInclude(y => y.img_)
                        .Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.status_)
                        .Where(x => x.persons_.departament_id == department_id)
                        .Where(x => x.status_.status != "Deleted")
                        .ToList();

                }

                return personDatas;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return Enumerable.Empty<PersonData>();
            }
        }
        public IEnumerable<PersonData> AllPersonData(int queryNum, int pageNum)
        {
            try
            {
                var personDatas = new List<PersonData>();
                if (queryNum == 0 && pageNum != 0)
                {
                    personDatas = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    personDatas = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_)
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    personDatas = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_)
                        .ToList();

                }
                return personDatas;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return Enumerable.Empty<PersonData>();
            }
        }

        public IEnumerable<PersonData> AllPersonDataEmployeeTypeSite(int queryNum, int pageNum, string employee_type)
        {
            try
            {
                var personDatas = new List<PersonData>();
                if (queryNum == 0 && pageNum != 0)
                {
                    personDatas = _context.persons_data_20ts24tu
                        .Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_)
                        .Where(x => (x.status_.status != "Deleted" && x.persons_.employee_type_.title == employee_type)).Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    personDatas = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_)
                        .Where(x => (x.status_.status != "Deleted" && x.persons_.employee_type_.title == employee_type)).Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    personDatas = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_)
                        .Where(x => (x.status_.status != "Deleted" && x.persons_.employee_type_.title == employee_type))
                        .ToList();

                }
                return personDatas;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return Enumerable.Empty<PersonData>();
            }
        }
        public IEnumerable<PersonData> AllPersonDataEmployeeType(int queryNum, int pageNum, string employee_type)
        {
            try
            {
                var personDatas = new List<PersonData>();
                if (queryNum == 0 && pageNum != 0)
                {
                    personDatas = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_)
                        .Where(x => x.persons_.employee_type_.title == employee_type)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    personDatas = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_)
                        .Where(x => x.persons_.employee_type_.title == employee_type)
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    personDatas = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_)
                        .Where(x => x.persons_.employee_type_.title == employee_type)
                        .ToList();

                }
                return personDatas;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return Enumerable.Empty<PersonData>();
            }
        }

        public int CreatePersonData(PersonData personData, User user)
        {
            try
            {
                if (personData == null)
                {
                    return 0;
                }

                DateTime localDateTime = DateTime.Parse(personData.birthday.ToString());
                localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
                DateTime utcDateTime = localDateTime.ToUniversalTime();

                personData.birthday = utcDateTime;

                _context.persons_data_20ts24tu.Add(personData);

                _context.SaveChanges();
                if (user == null)
                {
                    int num = personData.persons_.id + 2024;
                    string login = personData.persons_.firstName.Trim() + num + "@" + "tstu";
                    string password = PasswordManager.EncryptPassword(login + (personData.persons_.firstName.Trim() + num));
                    user = new User
                    {
                        login = login,
                        password = password,
                        user_type_id = 0,
                        person_id = 0,
                        status_id = 0
                    };

                }

                user.person_id = personData.persons_id;
                user.created_at = DateTime.UtcNow;
                user.active = true;
                user.removed = false;
                user.email = personData.persons_.email;
                user.status_id = personData.status_id;

                string emp = _context.employee_types_20ts24tu.FirstOrDefault(x => x.id == personData.persons_.employee_type_id).title;
                string usType = SessionClass.UserTypeId(emp);
                user.user_type_id = _context.user_types_20ts24tu.FirstOrDefault(x => x.type == usType).id;
                _context.users_20ts24tu.Add(user);

                _context.SaveChanges();


                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(personData));

                return personData.id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return 0;
            }
        }

        public bool DeletePersonData(int id)
        {
            try
            {
                var personData = GetPersonDataById(id);
                if (personData == null)
                {
                    return false;
                }
                personData.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;

                User user = _context.users_20ts24tu.FirstOrDefault(x => x.person_id == personData.persons_id);
                user.active = false;
                user.removed = true;
                user.status_id = personData.status_id;

                _context.persons_data_20ts24tu.Update(personData);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(personData));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return false;
            }
        }

        public PersonData GetPersonDataByIdSite(int id)
        {
            try
            {
                var personData = _context.persons_data_20ts24tu
                    .Where(x => x.status_.status != "Deleted")
                    .Include(x => x.persons_).ThenInclude(y => y.img_)
                    .Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_)
                    .FirstOrDefault(x => x.id.Equals(id));
                return personData;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }
        public PersonData GetPersonDataById(int id)
        {
            try
            {
                var personData = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
                return personData;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public PersonData GetPersonDataByPersonIdSite(int person_id)
        {
            try
            {
                var personData = _context.persons_data_20ts24tu
                    .Where(x => x.status_.status != "Deleted")
                    .Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_)
                    .FirstOrDefault(x => x.persons_id.Equals(person_id));
                return personData;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }
        public PersonData GetPersonDataByPersonId(int person_id)
        {
            try
            {
                var personData = _context.persons_data_20ts24tu.Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.persons_).ThenInclude(y => y.departament_)
                        .Include(x => x.persons_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                        .Include(x => x.status_).FirstOrDefault(x => x.persons_id.Equals(person_id));
                return personData;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public bool UpdatePersonData(int id, PersonData personData, User user)
        {

            try
            {
                var dbcheck = GetPersonDataById(id);
                if (dbcheck is null)
                {
                    return false;
                }

                DateTime localDateTime = DateTime.Parse(personData.birthday.ToString());
                localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
                DateTime utcDateTime = localDateTime.ToUniversalTime();

                personData.birthday = utcDateTime;

                dbcheck.persons_.firstName = personData.persons_.firstName;
                dbcheck.persons_.lastName = personData.persons_.lastName;
                dbcheck.persons_.fathers_name = personData.persons_.fathers_name;
                dbcheck.persons_.email = personData.persons_.email;
                dbcheck.persons_.gender_id = personData.persons_.gender_id;
                dbcheck.persons_.pinfl = personData.persons_.pinfl;
                dbcheck.persons_.passport_text = personData.persons_.passport_text;
                dbcheck.persons_.passport_number = personData.persons_.passport_number;
                dbcheck.persons_.status_id = personData.persons_.status_id;
                if (personData.persons_.img_ != null)
                {
                    dbcheck.persons_.img_ = personData.persons_.img_;
                }
                dbcheck.persons_.departament_id = personData.persons_.departament_id;
                dbcheck.persons_.employee_type_id = personData.persons_.employee_type_id;

                dbcheck.biography_json = personData.biography_json;
                dbcheck.birthday = personData.birthday;
                dbcheck.degree = personData.degree;
                dbcheck.experience_year = personData.experience_year;
                dbcheck.phone_number1 = personData.phone_number1;
                dbcheck.phone_number2 = personData.phone_number2;
                dbcheck.orchid = personData.orchid;
                dbcheck.scopus_id = personData.scopus_id;
                dbcheck.address = personData.address;
                dbcheck.languages_uz = personData.languages_uz;
                dbcheck.languages_en = personData.languages_en;
                dbcheck.languages_ru = personData.languages_ru;
                dbcheck.languages_any_title = personData.languages_any_title;
                dbcheck.languages_any = personData.languages_any;
                dbcheck.experience_json = personData.experience_json;
                dbcheck.scientific_activity_json = personData.scientific_activity_json;
                dbcheck.portfolio_json = personData.portfolio_json;
                dbcheck.blog_json = personData.blog_json;
                dbcheck.status_id = personData.status_id;


                if (user != null)
                {
                    User userDB = _context.users_20ts24tu.FirstOrDefault(x => x.person_id == dbcheck.persons_id);

                    if (userDB != null)
                    {
                        userDB.updated_at = DateTime.UtcNow;
                        userDB.email = personData.persons_.email;
                        userDB.login = user.login.Trim();
                        userDB.password = user.password.Trim();
                        user.active = true;
                        user.removed = false;
                        string emp = _context.employee_types_20ts24tu.FirstOrDefault(x => x.id == personData.persons_.employee_type_id).title;
                        string usType = SessionClass.UserTypeId(emp);
                        user.user_type_id = _context.user_types_20ts24tu.FirstOrDefault(x => x.type == usType).id;
                    }
                    else
                    {
                        int num = personData.persons_.id + 2024;
                        string login = personData.persons_.firstName.Trim() + num + "@" + "tstu";
                        string password = PasswordManager.EncryptPassword(login + (personData.persons_.firstName.Trim() + num));
                        string emp = _context.employee_types_20ts24tu.FirstOrDefault(x => x.id == personData.persons_.employee_type_id).title;
                        string usType = SessionClass.UserTypeId(emp);
                        user = new User
                        {
                            login = login,
                            password = password,
                            user_type_id = _context.user_types_20ts24tu.FirstOrDefault(x => x.type == usType).id,
                            person_id = personData.persons_id,
                            status_id = personData.status_id,
                            created_at = DateTime.UtcNow,
                            active = true,
                            removed = false,
                            email = personData.persons_.email
                        };
                        _context.users_20ts24tu.Add(user);


                    }
                }


                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return false;
            }

        }

        public User GetPersonUserById(int? person_id)
        {
            try
            {
                if (person_id != null || person_id != 0)
                {
                    User user = _context.users_20ts24tu.FirstOrDefault(x => (x.status_.status != "Deleted") && x.person_id == person_id);

                    User userGet = new User
                    {
                        user_type_id = 0,
                        login = user.login,
                        password = null,
                        person_id = person_id,
                        status_id = 0
                    };

                    return userGet;
                }
                return null;

            }
            catch
            {
                return null;
            }
        }






        //PersonDataTranslation CRUD
        public IEnumerable<PersonDataTranslation> AllPersonDataTranslationSite(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var personDatasTranslation = new List<PersonDataTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    personDatasTranslation = _context.persons_data_translations_20ts24tu
                        .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    personDatasTranslation = _context.persons_data_translations_20ts24tu.Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    personDatasTranslation = _context.persons_data_translations_20ts24tu
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                          .ToList();

                }
                return personDatasTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return Enumerable.Empty<PersonDataTranslation>();
            }
        }
        public IEnumerable<PersonDataTranslation> AllPersonDataTranslationDepId(int department_uz_id, string language_code)
        {
            try
            {
                var personDatasTranslation = new List<PersonDataTranslation>();
                if (department_uz_id != 0)
                {
                    personDatasTranslation = _context.persons_data_translations_20ts24tu
                        .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Where(x => x.persons_data_.persons_.departament_id == department_uz_id)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }

                return personDatasTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return Enumerable.Empty<PersonDataTranslation>();
            }
        }
        public IEnumerable<PersonDataTranslation> AllPersonDataTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var personDatasTranslation = new List<PersonDataTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    personDatasTranslation = _context.persons_data_translations_20ts24tu.Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    personDatasTranslation = _context.persons_data_translations_20ts24tu
                        .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    personDatasTranslation = _context.persons_data_translations_20ts24tu
                        .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                          .ToList();

                }
                return personDatasTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return Enumerable.Empty<PersonDataTranslation>();
            }
        }

        public IEnumerable<PersonDataTranslation> AllPersonDataTranslationEmployeeTypeSite(int queryNum, int pageNum, string language_code, string employee_type)
        {
            try
            {
                var personDatasTranslation = new List<PersonDataTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    personDatasTranslation = _context.persons_data_translations_20ts24tu
                        .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Where(x => (x.status_translation_.status != "Deleted" && x.persons_translation_.employee_type_translation_.employee_.title == employee_type))
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    personDatasTranslation = _context.persons_data_translations_20ts24tu.Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Where(x => (x.status_translation_.status != "Deleted" && x.persons_translation_.employee_type_translation_.employee_.title == employee_type))
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    personDatasTranslation = _context.persons_data_translations_20ts24tu
                        .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Where(x => (x.status_translation_.status != "Deleted" && x.persons_translation_.employee_type_translation_.employee_.title == employee_type))
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                          .ToList();

                }
                return personDatasTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return Enumerable.Empty<PersonDataTranslation>();
            }
        }
        public IEnumerable<PersonDataTranslation> AllPersonDataTranslationEmployeeType(int queryNum, int pageNum, string language_code, string employee_type)
        {
            try
            {
                var personDatasTranslation = new List<PersonDataTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    personDatasTranslation = _context.persons_data_translations_20ts24tu.Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Where(x => x.persons_translation_.employee_type_translation_.employee_.title == employee_type)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    personDatasTranslation = _context.persons_data_translations_20ts24tu
                        .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Where(x => x.persons_translation_.employee_type_translation_.employee_.title == employee_type)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    personDatasTranslation = _context.persons_data_translations_20ts24tu
                        .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                        .Where(x => x.persons_translation_.employee_type_translation_.employee_.title == employee_type)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                          .ToList();

                }
                return personDatasTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return Enumerable.Empty<PersonDataTranslation>();
            }
        }

        public int CreatePersonDataTranslation(PersonDataTranslation personDataTranslation)
        {
            try
            {
                if (personDataTranslation == null)
                {
                    return 0;
                }

                DateTime localDateTime = DateTime.Parse(personDataTranslation.birthday.ToString());
                localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
                DateTime utcDateTime = localDateTime.ToUniversalTime();

                personDataTranslation.birthday = utcDateTime;
                personDataTranslation.persons_translation_.language_id = personDataTranslation.language_id;

                PersonData per_id_Obj = _context.persons_data_20ts24tu
                 .Where(x => x.id == personDataTranslation.persons_data_id).Select(x => new PersonData { persons_id = x.persons_id }).FirstOrDefault();
                personDataTranslation.persons_translation_.persons_id = per_id_Obj.persons_id;

                _context.persons_data_translations_20ts24tu.Add(personDataTranslation);
                _context.SaveChanges();
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(personDataTranslation));

                return personDataTranslation.id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return 0;
            }
        }

        public bool DeletePersonDataTranslation(int id)
        {
            try
            {
                var personDataTranslation = GetPersonDataTranslationById(id);
                if (personDataTranslation == null)
                {
                    return false;
                }
                personDataTranslation.status_translation_id = (_context.statuses_translations_20ts24tu
                    .FirstOrDefault(x => x.status == "Deleted" && x.language_id == personDataTranslation.language_id)).id;
                _context.persons_data_translations_20ts24tu.Update(personDataTranslation);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(personDataTranslation));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return false;
            }
        }

        public PersonDataTranslation GetPersonDataTranslationByIdSite(int id)
        {
            try
            {
                var personDataTranslation = _context.persons_data_translations_20ts24tu
                    .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .FirstOrDefault(x => x.id.Equals(id));
                return personDataTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }
        public PersonDataTranslation GetPersonDataTranslationById(int id)
        {
            try
            {
                var personDataTranslation = _context.persons_data_translations_20ts24tu
                    .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_).Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                                        .FirstOrDefault(x => x.id.Equals(id));
                return personDataTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public PersonDataTranslation GetPersonDataTranslationByPersonIdSite(int person_id, string language_code)
        {
            try
            {
                var personDataTranslation = _context.persons_data_translations_20ts24tu
                    .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where(x => x.language_.code.Equals(language_code))
                    .FirstOrDefault(x => x.persons_translation_id.Equals(person_id));
                return personDataTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }
        public PersonDataTranslation GetPersonDataTranslationByPersonId(int person_id, string language_code)
        {
            try
            {
                var personDataTranslation = _context.persons_data_translations_20ts24tu
                    .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                    .Where(x => x.language_.code.Equals(language_code))
                                        .FirstOrDefault(x => x.persons_translation_id.Equals(person_id));
                return personDataTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }
        public PersonDataTranslation GetPersonDataTranslationById(int uz_id, string language_code)
        {
            try
            {
                var personDataTranslation = _context.persons_data_translations_20ts24tu
                    .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                             .FirstOrDefault(x => x.persons_data_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return personDataTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public PersonDataTranslation GetPersonDataTranslationByIdSite(int uz_id, string language_code)
        {
            try
            {
                var personDataTranslation = _context.persons_data_translations_20ts24tu
                    .Include(x => x.status_translation_)
                        .Include(x => x.language_)
                        .Include(x => x.persons_data_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.employee_type_translation_).ThenInclude(z => z.employee_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.departament_translation_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                        .Include(x => x.persons_translation_).ThenInclude(y => y.persons_).ThenInclude(x => x.img_)
                    .Where(x => x.status_translation_.status != "Deleted")
                             .FirstOrDefault(x => x.persons_data_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return personDataTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public bool UpdatePersonDataTranslation(int id, PersonDataTranslation personData)
        {

            try
            {
                var dbcheck = GetPersonDataTranslationById(id);
                if (dbcheck is null)
                {
                    return false;
                }

                DateTime localDateTime = DateTime.Parse(personData.birthday.ToString());
                localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
                DateTime utcDateTime = localDateTime.ToUniversalTime();

                personData.birthday = utcDateTime;
                personData.persons_translation_.language_id = personData.language_id;

                PersonData per_id_Obj = _context.persons_data_20ts24tu
                 .Where(x => x.id == personData.persons_data_id).Select(x => new PersonData { persons_id = x.persons_id }).FirstOrDefault();
                personData.persons_translation_.persons_id = per_id_Obj.persons_id;



                dbcheck.persons_translation_.firstName = personData.persons_translation_.firstName;
                dbcheck.persons_translation_.lastName = personData.persons_translation_.lastName;
                dbcheck.persons_translation_.fathers_name = personData.persons_translation_.fathers_name;
                dbcheck.persons_translation_.gender_id = personData.persons_translation_.gender_id;
                dbcheck.persons_translation_.persons_id = personData.persons_translation_.persons_id;
                dbcheck.persons_translation_.language_id = personData.persons_translation_.language_id;
                dbcheck.persons_translation_.status_translation_id = personData.persons_translation_.status_translation_id;
                dbcheck.persons_translation_.departament_translation_id = personData.persons_translation_.departament_translation_id;
                dbcheck.persons_translation_.employee_type_translation_id = personData.persons_translation_.employee_type_translation_id;

                dbcheck.persons_data_id = personData.persons_data_id;
                dbcheck.biography_json = personData.biography_json;
                dbcheck.birthday = personData.birthday;
                dbcheck.degree = personData.degree;
                dbcheck.experience_year = personData.experience_year;
                dbcheck.phone_number1 = personData.phone_number1;
                dbcheck.phone_number2 = personData.phone_number2;
                dbcheck.orchid = personData.orchid;
                dbcheck.scopus_id = personData.scopus_id;
                dbcheck.address = personData.address;
                dbcheck.languages_uz = personData.languages_uz;
                dbcheck.languages_en = personData.languages_en;
                dbcheck.languages_ru = personData.languages_ru;
                dbcheck.languages_any_title = personData.languages_any_title;
                dbcheck.languages_any = personData.languages_any;
                dbcheck.experience_json = personData.experience_json;
                dbcheck.scientific_activity_json = personData.scientific_activity_json;
                dbcheck.portfolio_json = personData.portfolio_json;
                dbcheck.blog_json = personData.blog_json;
                dbcheck.language_id = personData.language_id;
                dbcheck.status_translation_id = personData.status_translation_id;



                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return false;
            }

        }
        public bool SaveChanges()
        {
            try { _context.SaveChanges(); return true; }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString()); return false;
            }
        }


    }
}
