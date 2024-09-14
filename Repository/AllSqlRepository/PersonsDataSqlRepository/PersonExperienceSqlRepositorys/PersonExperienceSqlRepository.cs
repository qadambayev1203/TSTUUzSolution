using Contracts.AllRepository.PersonsDataRepository.PersonExperienceRepository;
using Entities.Model.AnyClasses;
using Entities.Model.PersonDataModel.PersonExperienceModel;
using Entities.Model.PersonDataModel;
using Entities.Model;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Repository.AllSqlRepository.PersonsDataSqlRepository.PersonExperienceSqlRepositorys;

public class PersonExperienceSqlRepository : IPersonExperienceRepository
{
    private readonly RepositoryContext _context;
    private readonly ILogger<PersonExperienceSqlRepository> _logger;
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
            IQueryable<PersonExperience> query = _context.person_experience_20ts24tu.Include(x => x.status_);

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

    public int CreatePersonExperience(PersonExperience personExperience)
    {
        try
        {
            if (personExperience == null)
            {
                return 0;
            }

            if (personExperience.person_data_id == 0 || personExperience.person_data_id is null)
            {
                User user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                PersonData personData = _context.persons_data_20ts24tu.FirstOrDefault(x => x.persons_id == user.person_id);
                if (personData == null) return 0;
                personExperience.person_data_id = personData.id;
            }

            _context.person_experience_20ts24tu.Add(personExperience);
            _context.SaveChanges();

            int id = personExperience.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(personExperience));

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
            var personExperience = GetByIdPersonExperience(id, false);
            if (personExperience == null)
            {
                return false;
            }
            personExperience.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.person_experience_20ts24tu.Update(personExperience);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(personExperience));
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
                .Where(x => x.id.Equals(id)).Include(x => x.status_);

            if (isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonExperience personExperience = query.FirstOrDefault();

            return personExperience ?? new PersonExperience();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonExperience();
        }
    }

    public bool UpdatePersonExperience(int id, PersonExperience personExperience, bool isAdmin)
    {
        try
        {
            var dbcheck = GetByIdPersonExperience(id, false);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.title = personExperience.title;
            dbcheck.description = personExperience.description;
            dbcheck.text = personExperience.text;
            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.status_id = personExperience.status_id;

            if (isAdmin)
            {
                dbcheck.person_data_id = personExperience.person_data_id;
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

    public int CreatePersonExperienceTranslation(PersonExperienceTranslation personExperience)
    {
        try
        {
            if (personExperience == null)
            {
                return 0;
            }

            if (personExperience.person_data_id == 0 || personExperience.person_data_id is null)
            {
                User user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                PersonDataTranslation personData = _context.persons_data_translations_20ts24tu
                    .FirstOrDefault(x => x.persons_data_.persons_id == user.person_id && x.language_id == personExperience.language_id);
                if (personData == null) return 0;
                personExperience.person_data_id = personData.id;
            }

            _context.person_experience_translation_20ts24tu.Add(personExperience);
            _context.SaveChanges();

            int id = personExperience.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(personExperience));

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
            IQueryable<PersonExperienceTranslation> query = _context.person_experience_translation_20ts24tu
                .Include(x => x.language_).Include(x => x.status_)
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

    public PersonExperienceTranslation GetByIdPersonExperienceTranslation(int id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonExperienceTranslation> query = _context.person_experience_translation_20ts24tu
                .Where(x => x.id.Equals(id)).Include(x => x.status_)
                .Include(x => x.language_);

            if (!isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonExperienceTranslation personExperience = query.FirstOrDefault();

            return personExperience ?? new PersonExperienceTranslation();
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

            PersonExperienceTranslation personExperience = query.FirstOrDefault();

            return personExperience ?? new PersonExperienceTranslation();
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
            var personExperience = GetByIdPersonExperienceTranslation(id, false);
            if (personExperience == null)
            {
                return false;
            }
            personExperience.status_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.person_experience_translation_20ts24tu.Update(personExperience);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(personExperience));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public bool UpdatePersonExperienceTranslation(int id, PersonExperienceTranslation personExperience, bool isAdmin)
    {
        try
        {
            var dbcheck = GetByIdPersonExperienceTranslation(id, false);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.title = personExperience.title;
            dbcheck.description = personExperience.description;
            dbcheck.text = personExperience.text;
            dbcheck.language_id = personExperience.language_id;
            dbcheck.person_experience_id = personExperience.person_experience_id;
            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.status_id = personExperience.status_id;

            if (isAdmin)
            {
                dbcheck.person_data_id = personExperience.person_data_id;
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

}
