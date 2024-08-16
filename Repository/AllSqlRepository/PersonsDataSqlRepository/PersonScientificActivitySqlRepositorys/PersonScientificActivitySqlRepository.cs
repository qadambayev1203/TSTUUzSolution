using Contracts.AllRepository.PersonsDataRepository.PersonScientificActivityRepository;
using Entities;
using Entities.Model;
using Entities.Model.AnyClasses;
using Entities.Model.PersonDataModel;
using Entities.Model.PersonDataModel.PersonScientificActivityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Repository.AllSqlRepository.PersonsDataSqlRepository.PersonScientificActivitySqlRepositorys;

public class PersonScientificActivitySqlRepository : IPersonScientificActivityRepository
{
    private readonly RepositoryContext _context;
    private readonly ILogger<PersonScientificActivitySqlRepository> _logger;
    public PersonScientificActivitySqlRepository(RepositoryContext repositoryContext, ILogger<PersonScientificActivitySqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }

    #region PersonScientificActivity CRUD

    public IEnumerable<PersonScientificActivity> AllPersonScientificActivity(int queryNum, int pageNum, int person_data_id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonScientificActivity> query = _context.person_scientific_activity_20ts24tu;

            if (isAdmin)
            {
                query = query.Include(x => x.status_);
            }
            else
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
                query = query.Take(queryNum);

            }

            return query.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<PersonScientificActivity>();
        }
    }

    public int CreatePersonScientificActivity(PersonScientificActivity personScientificActivity)
    {
        try
        {
            if (personScientificActivity == null)
            {
                return 0;
            }

            if (personScientificActivity.person_data_id == 0 || personScientificActivity.person_data_id is null)
            {
                User user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                PersonData personData = _context.persons_data_20ts24tu.FirstOrDefault(x => x.persons_id == user.person_id);
                if (personData == null) return 0;
                personScientificActivity.person_data_id = personData.id;
            }



            _context.person_scientific_activity_20ts24tu.Add(personScientificActivity);
            _context.SaveChanges();

            int id = personScientificActivity.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(personScientificActivity));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeletePersonScientificActivity(int id)
    {
        try
        {
            var personScientificActivity = GetByIdPersonScientificActivity(id, false);
            if (personScientificActivity == null)
            {
                return false;
            }
            personScientificActivity.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.person_scientific_activity_20ts24tu.Update(personScientificActivity);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(personScientificActivity));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public PersonScientificActivity GetByIdPersonScientificActivity(int id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonScientificActivity> query = _context.person_scientific_activity_20ts24tu
                .Where(x => x.id.Equals(id));

            if (isAdmin)
            {
                query = query.Include(x => x.status_);
            }
            else
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonScientificActivity personScientificActivity = query.FirstOrDefault();

            return personScientificActivity ?? new PersonScientificActivity();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonScientificActivity();
        }
    }

    public bool UpdatePersonScientificActivity(int id, PersonScientificActivity personScientificActivity, bool isAdmin)
    {
        try
        {
            var dbcheck = GetByIdPersonScientificActivity(id, false);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.since_when = personScientificActivity.since_when;
            dbcheck.until_when = personScientificActivity.until_when;
            dbcheck.whom = personScientificActivity.whom;
            dbcheck.where = personScientificActivity.where;

            if (isAdmin)
            {
                dbcheck.person_data_id = personScientificActivity.person_data_id;
                dbcheck.status_id = personScientificActivity.status_id;
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


    #region PersonScientificActivityTranslation CRUD

    public int CreatePersonScientificActivityTranslation(PersonScientificActivityTranslation personScientificActivity)
    {
        try
        {
            if (personScientificActivity == null)
            {
                return 0;
            }

            if (personScientificActivity.person_data_translation_id == 0 || personScientificActivity.person_data_translation_id is null)
            {
                User user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                PersonDataTranslation personData = _context.persons_data_translations_20ts24tu
                    .FirstOrDefault(x => x.persons_data_.persons_id == user.person_id && x.language_id == personScientificActivity.language_id);
                if (personData == null) return 0;
                personScientificActivity.person_data_translation_id = personData.id;
            }

            _context.person_scientific_activity_translation_20ts24tu.Add(personScientificActivity);
            _context.SaveChanges();

            int id = personScientificActivity.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(personScientificActivity));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public IEnumerable<PersonScientificActivityTranslation> AllPersonScientificActivityTranslation(int queryNum, int pageNum, int person_data_id, bool isAdmin, string language_code)
    {
        try
        {
            IQueryable<PersonScientificActivityTranslation> query = _context.person_scientific_activity_translation_20ts24tu
                .Include(x => x.language_)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null);

            if (isAdmin)
            {
                query = query.Include(x => x.status_translation_);
            }
            else
            {
                query = query.Where(x => x.status_translation_.status != "Deleted");
            }

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);

            }

            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Take(queryNum);

            }

            return query.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<PersonScientificActivityTranslation>();
        }
    }

    public PersonScientificActivityTranslation GetByIdPersonScientificActivityTranslation(int id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonScientificActivityTranslation> query = _context.person_scientific_activity_translation_20ts24tu
                .Where(x => x.id.Equals(id))
                .Include(x => x.language_);

            if (isAdmin)
            {
                query = query.Include(x => x.status_translation_);
            }
            else
            {
                query = query.Where(x => x.status_translation_.status != "Deleted");
            }

            PersonScientificActivityTranslation personScientificActivity = query.FirstOrDefault();

            return personScientificActivity ?? new PersonScientificActivityTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonScientificActivityTranslation();
        }
    }

    public PersonScientificActivityTranslation GetByIdPersonScientificActivityTranslation(int uz_id, string language_code, bool isAdmin)
    {
        try
        {
            IQueryable<PersonScientificActivityTranslation> query = _context.person_scientific_activity_translation_20ts24tu
                .Where(x => x.person_scientific_activity_.Equals(uz_id))
                .Where(x => x.language_.code.Equals(language_code))
                .Include(x => x.language_);

            if (isAdmin)
            {
                query = query.Include(x => x.status_translation_);
            }
            else
            {
                query = query.Where(x => x.status_translation_.status != "Deleted");
            }

            PersonScientificActivityTranslation personScientificActivity = query.FirstOrDefault();

            return personScientificActivity ?? new PersonScientificActivityTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonScientificActivityTranslation();
        }
    }

    public bool DeletePersonScientificActivityTranslation(int id)
    {
        try
        {
            var personScientificActivity = GetByIdPersonScientificActivityTranslation(id, false);
            if (personScientificActivity == null)
            {
                return false;
            }
            personScientificActivity.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.person_scientific_activity_translation_20ts24tu.Update(personScientificActivity);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(personScientificActivity));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public bool UpdatePersonScientificActivityTranslation(int id, PersonScientificActivityTranslation personScientificActivity, bool isAdmin)
    {
        try
        {
            var dbcheck = GetByIdPersonScientificActivityTranslation(id, false);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.since_when = personScientificActivity.since_when;
            dbcheck.until_when = personScientificActivity.until_when;
            dbcheck.whom = personScientificActivity.whom;
            dbcheck.where = personScientificActivity.where;
            dbcheck.person_scientific_activity_id = personScientificActivity.person_scientific_activity_id;
            dbcheck.language_id = personScientificActivity.language_id;

            if (isAdmin)
            {
                dbcheck.person_data_translation_id = personScientificActivity.person_data_translation_id;
                dbcheck.status_translation_id = personScientificActivity.status_translation_id;
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
