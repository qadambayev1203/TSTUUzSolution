using Contracts.AllRepository.PersonsDataRepository.PersonPortfolioRepository;
using Entities.Model.AnyClasses;
using Entities.Model.PersonDataModel.PersonPortfolioModel;
using Entities.Model.PersonDataModel;
using Entities.Model;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
            IQueryable<PersonPortfolio> query = _context.person_portfolio_20ts24tu;

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
            return Enumerable.Empty<PersonPortfolio>();
        }
    }

    public int CreatePersonPortfolio(PersonPortfolio personPortfolio)
    {
        try
        {
            if (personPortfolio == null)
            {
                return 0;
            }

            if (personPortfolio.person_data_id == 0 || personPortfolio.person_data_id is null)
            {
                User user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                PersonData personData = _context.persons_data_20ts24tu.FirstOrDefault(x => x.persons_id == user.person_id);
                if (personData == null) return 0;
                personPortfolio.person_data_id = personData.id;
            }

            _context.person_portfolio_20ts24tu.Add(personPortfolio);
            _context.SaveChanges();

            int id = personPortfolio.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(personPortfolio));

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
            var personPortfolio = GetByIdPersonPortfolio(id, false);
            if (personPortfolio == null)
            {
                return false;
            }
            personPortfolio.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.person_portfolio_20ts24tu.Update(personPortfolio);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(personPortfolio));
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
                .Where(x => x.id.Equals(id));

            if (isAdmin)
            {
                query = query.Include(x => x.status_);
            }
            else
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonPortfolio personPortfolio = query.FirstOrDefault();

            return personPortfolio ?? new PersonPortfolio();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonPortfolio();
        }
    }

    public bool UpdatePersonPortfolio(int id, PersonPortfolio personPortfolio, bool isAdmin)
    {
        try
        {
            var dbcheck = GetByIdPersonPortfolio(id, false);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.title = personPortfolio.title;
            dbcheck.description = personPortfolio.description;
            dbcheck.text = personPortfolio.text;
            dbcheck.updated_at = DateTime.UtcNow;

            if (isAdmin)
            {
                dbcheck.status_id = personPortfolio.status_id;
                dbcheck.person_data_id = personPortfolio.person_data_id;
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

    public int CreatePersonPortfolioTranslation(PersonPortfolioTranslation personPortfolio)
    {
        try
        {
            if (personPortfolio == null)
            {
                return 0;
            }

            if (personPortfolio.person_data_id == 0 || personPortfolio.person_data_id is null)
            {
                User user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                PersonDataTranslation personData = _context.persons_data_translations_20ts24tu
                    .FirstOrDefault(x => x.persons_data_.persons_id == user.person_id && x.language_id == personPortfolio.language_id);
                if (personData == null) return 0;
                personPortfolio.person_data_id = personData.id;
            }

            _context.person_portfolio_translation_20ts24tu.Add(personPortfolio);
            _context.SaveChanges();

            int id = personPortfolio.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(personPortfolio));

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
            IQueryable<PersonPortfolioTranslation> query = _context.person_portfolio_translation_20ts24tu
                .Include(x => x.language_)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null);

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
            return Enumerable.Empty<PersonPortfolioTranslation>();
        }
    }

    public PersonPortfolioTranslation GetByIdPersonPortfolioTranslation(int id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonPortfolioTranslation> query = _context.person_portfolio_translation_20ts24tu
                .Where(x => x.id.Equals(id))
                .Include(x => x.language_);

            if (isAdmin)
            {
                query = query.Include(x => x.status_);
            }
            else
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonPortfolioTranslation personPortfolio = query.FirstOrDefault();

            return personPortfolio ?? new PersonPortfolioTranslation();
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
                .Where(x => x.person_portfolio_.Equals(uz_id))
                .Where(x => x.language_.code.Equals(language_code))
                .Include(x => x.language_);

            if (isAdmin)
            {
                query = query.Include(x => x.status_);
            }
            else
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonPortfolioTranslation personPortfolio = query.FirstOrDefault();

            return personPortfolio ?? new PersonPortfolioTranslation();
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
            var personPortfolio = GetByIdPersonPortfolioTranslation(id, false);
            if (personPortfolio == null)
            {
                return false;
            }
            personPortfolio.status_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.person_portfolio_translation_20ts24tu.Update(personPortfolio);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(personPortfolio));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public bool UpdatePersonPortfolioTranslation(int id, PersonPortfolioTranslation personPortfolio, bool isAdmin)
    {
        try
        {
            var dbcheck = GetByIdPersonPortfolioTranslation(id, false);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.title = personPortfolio.title;
            dbcheck.description = personPortfolio.description;
            dbcheck.text = personPortfolio.text;
            dbcheck.language_id = personPortfolio.language_id;
            dbcheck.person_portfolio_id = personPortfolio.person_portfolio_id;
            dbcheck.updated_at = DateTime.UtcNow;

            if (isAdmin)
            {
                dbcheck.status_id = personPortfolio.status_id;
                dbcheck.person_data_id = personPortfolio.person_data_id;
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
