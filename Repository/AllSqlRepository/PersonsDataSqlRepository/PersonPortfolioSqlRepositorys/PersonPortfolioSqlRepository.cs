using Contracts.AllRepository.PersonsDataRepository.PersonPortfolioRepository;
using Entities.Model.AnyClasses;
using Entities.Model.PersonDataModel.PersonPortfolioModel;
using Entities.Model.PersonDataModel;
using Entities.Model;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Entities.Model.PersonModel;

namespace Repository.AllSqlRepository.PersonsDataSqlRepository.PersonPortfolioSqlRepositorys;

public class PersonPortfolioSqlRepository : IPersonPortfolioRepository
{
    private readonly RepositoryContext _context;
    private readonly ILogger<PersonPortfolioSqlRepository> _logger;
    public PersonPortfolioSqlRepository(RepositoryContext repositoryContext, ILogger<PersonPortfolioSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }

    #region PersonPortfolio CRUD

    public IEnumerable<PersonPortfolio> AllPersonPortfolio(int queryNum, int pageNum, int person_data_id, bool isAdmin)
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

            IQueryable<PersonPortfolio> query = _context.person_portfolio_20ts24tu
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
            return Enumerable.Empty<PersonPortfolio>();
        }
    }

    public IEnumerable<PersonPortfolio> AllPersonPortfolioSite(int queryNum, int pageNum, int person_data_id)
    {
        try
        {
            IQueryable<PersonPortfolio> query = _context.person_portfolio_20ts24tu
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
            return Enumerable.Empty<PersonPortfolio>();
        }
    }

    public int CreatePersonPortfolio(PersonPortfolio PersonPortfolio)
    {
        try
        {
            if (PersonPortfolio == null)
            {
                return 0;
            }

            if (PersonPortfolio.person_data_id == 0 || PersonPortfolio.person_data_id is null)
            {
                User user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                PersonData personData = _context.persons_data_20ts24tu.FirstOrDefault(x => x.persons_id == user.person_id);
                if (personData == null) return 0;
                PersonPortfolio.person_data_id = personData.id;
            }

            PersonPortfolio.confirmed = 0;

            _context.person_portfolio_20ts24tu.Add(PersonPortfolio);
            _context.SaveChanges();

            int id = PersonPortfolio.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(PersonPortfolio));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeletePersonPortfolio(int id)
    {
        try
        {
            var PersonPortfolio = GetByIdPersonPortfolio(id, false);
            if (PersonPortfolio == null)
            {
                return false;
            }
            PersonPortfolio.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.person_portfolio_20ts24tu.Update(PersonPortfolio);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(PersonPortfolio));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public PersonPortfolio GetByIdPersonPortfolio(int id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonPortfolio> query = _context.person_portfolio_20ts24tu
                .Where(x => x.id.Equals(id))
                .Include(x => x.person_data_).ThenInclude(x => x.persons_)
                .Include(x => x.status_);

            if (!isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonPortfolio PersonPortfolio = query.FirstOrDefault();

            return PersonPortfolio ?? new PersonPortfolio();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonPortfolio();
        }
    }

    public PersonPortfolio GetByIdPersonPortfolioSite(int id)
    {
        try
        {
            var res = _context.person_portfolio_20ts24tu
                .Where(x => x.status_.status != "Deleted")
                .Where(x => x.id.Equals(id))
                .Where(x => x.confirmed.Equals(1))
                .FirstOrDefault();

            return res ?? new PersonPortfolio();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonPortfolio();
        }
    }

    public bool UpdatePersonPortfolio(int id, PersonPortfolio PersonPortfolio, bool isAdmin)
    {
        try
        {
            var dbcheck = GetByIdPersonPortfolio(id, false);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.confirmed = 0;
            dbcheck.title = PersonPortfolio.title;
            dbcheck.description = PersonPortfolio.description;
            dbcheck.text = PersonPortfolio.text;
            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.status_id = PersonPortfolio.status_id;

            if (isAdmin)
            {
                dbcheck.person_data_id = PersonPortfolio.person_data_id;
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


    #region PersonPortfolioTranslation CRUD

    public int CreatePersonPortfolioTranslation(PersonPortfolioTranslation PersonPortfolio)
    {
        try
        {
            if (PersonPortfolio == null)
            {
                return 0;
            }

            if (PersonPortfolio.person_data_id == 0 || PersonPortfolio.person_data_id is null)
            {
                User user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                PersonDataTranslation personData = _context.persons_data_translations_20ts24tu
                    .FirstOrDefault(x => x.persons_data_.persons_id == user.person_id && x.language_id == PersonPortfolio.language_id);
                if (personData == null) return 0;
                PersonPortfolio.person_data_id = personData.id;
            }

            var person_portfolio_ = _context.person_portfolio_20ts24tu.FirstOrDefault(x => x.id == PersonPortfolio.person_portfolio_id);
            person_portfolio_.confirmed = 0;

            PersonPortfolio.person_portfolio_ = person_portfolio_;

            _context.person_portfolio_translation_20ts24tu.Add(PersonPortfolio);
            _context.SaveChanges();

            int id = PersonPortfolio.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(PersonPortfolio));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public IEnumerable<PersonPortfolioTranslation> AllPersonPortfolioTranslation(int queryNum, int pageNum, int person_data_id, bool isAdmin, string language_code)
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

            IQueryable<PersonPortfolioTranslation> query = _context.person_portfolio_translation_20ts24tu
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
            return Enumerable.Empty<PersonPortfolioTranslation>();
        }
    }
    public IEnumerable<PersonPortfolioTranslation> AllPersonPortfolioTranslationSite(int queryNum, int pageNum, int person_data_id, string language_code)
    {
        try
        {
            IQueryable<PersonPortfolioTranslation> query = _context.person_portfolio_translation_20ts24tu
                .Include(x => x.language_)
                .Where(x => x.person_data_.persons_data_id == person_data_id)
                .Where(x => x.person_portfolio_.confirmed == 1)
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
            return Enumerable.Empty<PersonPortfolioTranslation>();
        }
    }

    public PersonPortfolioTranslation GetByIdPersonPortfolioTranslation(int id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonPortfolioTranslation> query = _context.person_portfolio_translation_20ts24tu
                .Where(x => x.id.Equals(id))
                .Include(x => x.language_)
                .Include(x => x.person_portfolio_)
                .Include(x => x.status_);

            if (!isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonPortfolioTranslation PersonPortfolio = query.FirstOrDefault();

            return PersonPortfolio ?? new PersonPortfolioTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonPortfolioTranslation();
        }
    }

    public PersonPortfolioTranslation GetByIdPersonPortfolioTranslationSite(int id)
    {
        try
        {
            var res = _context.person_portfolio_translation_20ts24tu
                .Where(x => x.id.Equals(id))
                .Where(x => x.person_portfolio_.confirmed.Equals(1))
                .Where(x => x.status_.status != "Deleted")
                .Include(x => x.language_)
                .FirstOrDefault();

            return res ?? new PersonPortfolioTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonPortfolioTranslation();
        }
    }

    public PersonPortfolioTranslation GetByIdPersonPortfolioTranslation(int uz_id, string language_code, bool isAdmin)
    {
        try
        {
            IQueryable<PersonPortfolioTranslation> query = _context.person_portfolio_translation_20ts24tu
                .Where(x => x.person_portfolio_id.Equals(uz_id))
                .Where(x => x.language_.code.Equals(language_code))
                .Include(x => x.language_).Include(x => x.status_);

            if (!isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonPortfolioTranslation PersonPortfolio = query.FirstOrDefault();

            return PersonPortfolio ?? new PersonPortfolioTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonPortfolioTranslation();
        }
    }
    public PersonPortfolioTranslation GetByIdPersonPortfolioTranslationSite(int uz_id, string language_code)
    {
        try
        {
            var res = _context.person_portfolio_translation_20ts24tu
                 .Where(x => x.person_portfolio_id.Equals(uz_id))
                 .Where(x => x.person_portfolio_.confirmed.Equals(1))
                 .Where(x => x.status_.status != "Deleted")
                 .Include(x => x.language_)
                 .FirstOrDefault();

            return res ?? new PersonPortfolioTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonPortfolioTranslation();
        }
    }

    public bool DeletePersonPortfolioTranslation(int id)
    {
        try
        {
            var PersonPortfolio = GetByIdPersonPortfolioTranslation(id, false);
            if (PersonPortfolio == null)
            {
                return false;
            }
            PersonPortfolio.status_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.person_portfolio_translation_20ts24tu.Update(PersonPortfolio);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(PersonPortfolio));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public bool UpdatePersonPortfolioTranslation(int id, PersonPortfolioTranslation PersonPortfolio, bool isAdmin)
    {
        try
        {
            var dbcheck = GetByIdPersonPortfolioTranslation(id, false);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.person_portfolio_.confirmed = 0;

            dbcheck.title = PersonPortfolio.title;
            dbcheck.description = PersonPortfolio.description;
            dbcheck.text = PersonPortfolio.text;
            dbcheck.language_id = PersonPortfolio.language_id;
            dbcheck.person_portfolio_id = PersonPortfolio.person_portfolio_id;
            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.status_id = PersonPortfolio.status_id;

            if (isAdmin)
            {
                dbcheck.person_data_id = PersonPortfolio.person_data_id;
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




    public IEnumerable<PersonData> AllPersonPortfolioCreated()
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

    public IEnumerable<PersonPortfolio> AllPersonPortfolioDep(int queryNum, int pageNum, int person_data_id)
    {
        try
        {
            IQueryable<PersonPortfolio> query = _context.person_portfolio_20ts24tu
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
            return Enumerable.Empty<PersonPortfolio>();
        }
    }

    public bool ConfirmDocumentTeacher110Set(int id, bool confirm)
    {
        try
        {
            var dbcheck = GetByIdPersonPortfolio(id, false);

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
