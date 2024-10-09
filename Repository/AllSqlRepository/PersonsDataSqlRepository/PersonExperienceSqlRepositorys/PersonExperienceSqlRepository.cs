using Contracts.AllRepository.PersonsDataRepository.PersonExperienceRepository;
using Entities.Model.AnyClasses;
using Entities.Model.PersonDataModel.PersonExperienceModel;
using Entities.Model.PersonDataModel;
using Entities.Model;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Entities.Model.PersonModel;
using Entities.Model.PersonDataModel.PersonPortfolioModel;
using Entities.Model.PersonDataModel.PersonBlogModel;

namespace Repository.AllSqlRepository.PersonsDataSqlRepository.PersonExperienceSqlRepositorys;

public class PersonExperienceSqlRepository : IPersonExperienceRepository
{
    private readonly RepositoryContext _context;
    private readonly ILogger<PersonExperienceSqlRepository> _logger;
    private readonly List<string> userType = SessionClass.userTypeConfirm;
    public PersonExperienceSqlRepository(RepositoryContext repositoryContext, ILogger<PersonExperienceSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }

    #region PersonExperience CRUD

    public IEnumerable<PersonExperience> AllPersonExperience(int queryNum, int pageNum, int person_data_id, bool isAdmin)
    {
        try
        {
            if (person_data_id == null || person_data_id == 0)
            {
                var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                var person_data_ = _context.persons_data_20ts24tu.FirstOrDefault(x => x.persons_id == user.person_id);
                if (person_data_ != null)
                {
                    person_data_id = person_data_.id;
                }
            }

            IQueryable<PersonExperience> query = _context.person_experience_20ts24tu
                .Where(x => x.person_data_id == person_data_id)
                .Include(x => x.status_);

            if (!isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);

            }

            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1))
                    .Take(queryNum);

            }

            return query.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<PersonExperience>();
        }
    }

    public IEnumerable<PersonExperience> AllPersonExperienceSite(int queryNum, int pageNum, int person_data_id)
    {
        try
        {
            IQueryable<PersonExperience> query = _context.person_experience_20ts24tu
            .Where(x => x.person_data_id == person_data_id)
            .Where(x => x.confirmed == 1)
            .Where(x => x.status_.status != "Deleted");

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);

            }

            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1))
                    .Take(queryNum);

            }

            return query.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<PersonExperience>();
        }
    }

    public int CreatePersonExperience(PersonExperience PersonExperience)
    {
        try
        {
            if (PersonExperience == null)
            {
                return 0;
            }

            PersonExperience.confirmed = 0;
            if (PersonExperience.person_data_id == 0 || PersonExperience.person_data_id is null)
            {
                User user = _context.users_20ts24tu.Include(x => x.user_type_).FirstOrDefault(x => x.id == SessionClass.id);
                PersonData personData = _context.persons_data_20ts24tu.FirstOrDefault(x => x.persons_id == user.person_id);
                if (personData == null) return 0;
                PersonExperience.person_data_id = personData.id;

                if (userType.Contains(user.user_type_.type))
                {
                    PersonExperience.confirmed = 1;
                }
            }


            _context.person_experience_20ts24tu.Add(PersonExperience);
            _context.SaveChanges();

            int id = PersonExperience.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(PersonExperience));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeletePersonExperience(int id)
    {
        try
        {
            var PersonExperience = GetByIdPersonExperience(id, false);
            if (PersonExperience == null)
            {
                return false;
            }
            PersonExperience.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.person_experience_20ts24tu.Update(PersonExperience);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(PersonExperience));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public PersonExperience GetByIdPersonExperience(int id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonExperience> query = _context.person_experience_20ts24tu
                .Where(x => x.id.Equals(id))
                .Include(x => x.person_data_).ThenInclude(x => x.persons_)
                .Include(x => x.status_);

            if (!isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonExperience PersonExperience = query.FirstOrDefault();

            return PersonExperience ?? new PersonExperience();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonExperience();
        }
    }

    public PersonExperience GetByIdPersonExperienceSite(int id)
    {
        try
        {
            var res = _context.person_experience_20ts24tu
                .Where(x => x.status_.status != "Deleted")
                .Where(x => x.id.Equals(id))
                .Where(x => x.confirmed.Equals(1))
                .FirstOrDefault();

            return res ?? new PersonExperience();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonExperience();
        }
    }

    public bool UpdatePersonExperience(int id, PersonExperience PersonExperience, bool isAdmin)
    {
        try
        {
            var dbcheck = GetByIdPersonExperience(id, false);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.confirmed = 0;

            User user = _context.users_20ts24tu.Include(x => x.user_type_).FirstOrDefault(x => x.id == SessionClass.id);
            if (user != null && user.user_type_.type != null)
            {
                if (userType.Contains(user.user_type_.type))
                {
                    dbcheck.confirmed = 1;
                }

            }


            dbcheck.title = PersonExperience.title;
            dbcheck.description = PersonExperience.description;
            dbcheck.text = PersonExperience.text;
            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.status_id = PersonExperience.status_id;

            if (isAdmin)
            {
                dbcheck.person_data_id = PersonExperience.person_data_id;
            }
            _context.SaveChanges();

            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    #endregion


    #region PersonExperienceTranslation CRUD

    public int CreatePersonExperienceTranslation(PersonExperienceTranslation PersonExperience)
    {
        try
        {
            if (PersonExperience == null)
            {
                return 0;
            }

            int confirmed = 0;
            if (PersonExperience.person_data_id == 0 || PersonExperience.person_data_id is null)
            {
                User user = _context.users_20ts24tu.Include(x => x.user_type_).FirstOrDefault(x => x.id == SessionClass.id);
                PersonDataTranslation personData = _context.persons_data_translations_20ts24tu
                    .FirstOrDefault(x => x.persons_data_.persons_id == user.person_id && x.language_id == PersonExperience.language_id);
                if (personData == null) return 0;
                PersonExperience.person_data_id = personData.id;

                if (userType.Contains(user.user_type_.type))
                {
                    confirmed = 1;
                }
            }

            var person_experience_ = _context.person_experience_20ts24tu.FirstOrDefault(x => x.id == PersonExperience.person_experience_id);
            person_experience_.confirmed = 0;

            PersonExperience.person_experience_ = person_experience_;

            _context.person_experience_translation_20ts24tu.Add(PersonExperience);
            _context.SaveChanges();

            int id = PersonExperience.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(PersonExperience));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public IEnumerable<PersonExperienceTranslation> AllPersonExperienceTranslation(int queryNum, int pageNum, int person_data_id, bool isAdmin, string language_code)
    {
        try
        {
            if (person_data_id == null || person_data_id == 0)
            {
                var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                var person_data_ = _context.persons_data_20ts24tu.FirstOrDefault(x => x.persons_id == user.person_id);
                if (person_data_ != null)
                {
                    person_data_id = person_data_.id;
                }
            }

            IQueryable<PersonExperienceTranslation> query = _context.person_experience_translation_20ts24tu
                .Include(x => x.language_).Include(x => x.status_)
                .Where(x => x.person_data_.persons_data_id == person_data_id)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null);

            if (!isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);

            }

            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1))
                    .Take(queryNum);
            }

            return query.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<PersonExperienceTranslation>();
        }
    }
    public IEnumerable<PersonExperienceTranslation> AllPersonExperienceTranslationSite(int queryNum, int pageNum, int person_data_id, string language_code)
    {
        try
        {
            IQueryable<PersonExperienceTranslation> query = _context.person_experience_translation_20ts24tu
                .Include(x => x.language_)
                .Where(x => x.person_data_.persons_data_id == person_data_id)
                .Where(x => x.person_experience_.confirmed == 1)
                .Where(x => x.status_.status != "Deleted")
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null);

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);

            }

            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1))
                    .Take(queryNum);
            }

            return query.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<PersonExperienceTranslation>();
        }
    }

    public PersonExperienceTranslation GetByIdPersonExperienceTranslation(int id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonExperienceTranslation> query = _context.person_experience_translation_20ts24tu
                .Where(x => x.id.Equals(id))
                .Include(x => x.language_)
                .Include(x => x.person_experience_)
                .Include(x => x.status_);

            if (!isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonExperienceTranslation PersonExperience = query.FirstOrDefault();

            return PersonExperience ?? new PersonExperienceTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonExperienceTranslation();
        }
    }

    public PersonExperienceTranslation GetByIdPersonExperienceTranslationSite(int id)
    {
        try
        {
            var res = _context.person_experience_translation_20ts24tu
                .Where(x => x.id.Equals(id))
                .Where(x => x.person_experience_.confirmed.Equals(1))
                .Where(x => x.status_.status != "Deleted")
                .Include(x => x.language_)
                .FirstOrDefault();

            return res ?? new PersonExperienceTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonExperienceTranslation();
        }
    }

    public PersonExperienceTranslation GetByIdPersonExperienceTranslation(int uz_id, string language_code, bool isAdmin)
    {
        try
        {
            IQueryable<PersonExperienceTranslation> query = _context.person_experience_translation_20ts24tu
                .Where(x => x.person_experience_id.Equals(uz_id))
                .Where(x => x.language_.code.Equals(language_code))
                .Include(x => x.language_).Include(x => x.status_);

            if (!isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonExperienceTranslation PersonExperience = query.FirstOrDefault();

            return PersonExperience ?? new PersonExperienceTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonExperienceTranslation();
        }
    }
    public PersonExperienceTranslation GetByIdPersonExperienceTranslationSite(int uz_id, string language_code)
    {
        try
        {
            var res = _context.person_experience_translation_20ts24tu
                 .Where(x => x.person_experience_id.Equals(uz_id))
                 .Where(x => x.person_experience_.confirmed.Equals(1))
                 .Where(x => x.status_.status != "Deleted")
                 .Include(x => x.language_)
                 .FirstOrDefault();

            return res ?? new PersonExperienceTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonExperienceTranslation();
        }
    }

    public bool DeletePersonExperienceTranslation(int id)
    {
        try
        {
            var PersonExperience = GetByIdPersonExperienceTranslation(id, false);
            if (PersonExperience == null)
            {
                return false;
            }
            PersonExperience.status_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.person_experience_translation_20ts24tu.Update(PersonExperience);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(PersonExperience));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public bool UpdatePersonExperienceTranslation(int id, PersonExperienceTranslation PersonExperience, bool isAdmin)
    {
        try
        {
            var dbcheck = GetByIdPersonExperienceTranslation(id, false);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.person_experience_.confirmed = 0;

            User user = _context.users_20ts24tu.Include(x => x.user_type_).FirstOrDefault(x => x.id == SessionClass.id);

            if (userType.Contains(user.user_type_.type))
            {
                dbcheck.person_experience_.confirmed = 1;
            }

            dbcheck.title = PersonExperience.title;
            dbcheck.description = PersonExperience.description;
            dbcheck.text = PersonExperience.text;
            dbcheck.language_id = PersonExperience.language_id;
            dbcheck.person_experience_id = PersonExperience.person_experience_id;
            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.status_id = PersonExperience.status_id;

            if (isAdmin)
            {
                dbcheck.person_data_id = PersonExperience.person_data_id;
            }
            _context.SaveChanges();

            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }




    public IEnumerable<PersonData> AllPersonExperienceCreated()
    {
        try
        {
            var user = _context.users_20ts24tu
                .Include(x => x.person_)
                .FirstOrDefault(x => x.id == SessionClass.id);
            if (user != null)
            {
                List<PersonData> personsIdList = _context.persons_data_20ts24tu
                .Where(x => x.persons_.departament_id == user.person_.departament_id)
                .Where(x => x.persons_id != user.person_id)
                .Where(x => x.status_.status != "Deleted")
                .Include(x => x.persons_)
                .ToList();
                return personsIdList;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<PersonData>();
        }
    }

    public IEnumerable<PersonExperience> AllPersonExperienceDep(int queryNum, int pageNum, int person_data_id)
    {
        try
        {
            IQueryable<PersonExperience> query = _context.person_experience_20ts24tu
                .Where(x => x.person_data_id == person_data_id)
                .Where(x => x.status_.status != "Deleted");

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);

            }

            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1))
                    .Take(queryNum);

            }

            return query.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<PersonExperience>();
        }
    }

    public bool ConfirmDocumentTeacher110Set(int id, bool confirm)
    {
        try
        {
            var dbcheck = GetByIdPersonExperience(id, false);

            if (dbcheck is null || dbcheck.confirmed == 1)
            {
                return false;
            }

            var headDepartamentId = _context.users_20ts24tu
               .Where(x => x.id == SessionClass.id)
               .Select(x => x.person_.departament_id).FirstOrDefault();

            if (dbcheck.person_data_.persons_.departament_id != headDepartamentId)
            {
                return false;
            }

            if (!confirm)
            {
                dbcheck.confirmed = 2;
            }
            else if (confirm)
            {
                dbcheck.confirmed = 1;

            }
            _context.Update(dbcheck);
            _context.SaveChanges();
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    #endregion

}
