using Contracts.AllRepository.PersonsDataRepository.PersonBlogRepository;
using Entities.Model.AnyClasses;
using Entities.Model.PersonDataModel.PersonBlogModel;
using Entities.Model.PersonDataModel;
using Entities.Model;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Repository.AllSqlRepository.PersonsDataSqlRepository.PersonBlogSqlRepositorys;

public class PersonBlogSqlRepository : IPersonBlogRepository
{
    private readonly RepositoryContext _context;
    private readonly ILogger<PersonBlogSqlRepository> _logger;
    public PersonBlogSqlRepository(RepositoryContext repositoryContext, ILogger<PersonBlogSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }

    #region PersonBlog CRUD

    public IEnumerable<PersonBlog> AllPersonBlog(int queryNum, int pageNum, int person_data_id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonBlog> query = _context.person_blog_20ts24tu.Include(x => x.status_);

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
            return Enumerable.Empty<PersonBlog>();
        }
    }

    public int CreatePersonBlog(PersonBlog personBlog)
    {
        try
        {
            if (personBlog == null)
            {
                return 0;
            }

            if (personBlog.person_data_id == 0 || personBlog.person_data_id is null)
            {
                User user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                PersonData personData = _context.persons_data_20ts24tu.FirstOrDefault(x => x.persons_id == user.person_id);
                if (personData == null) return 0;
                personBlog.person_data_id = personData.id;
            }

            _context.person_blog_20ts24tu.Add(personBlog);
            _context.SaveChanges();

            int id = personBlog.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(personBlog));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeletePersonBlog(int id)
    {
        try
        {
            var personBlog = GetByIdPersonBlog(id, false);
            if (personBlog == null)
            {
                return false;
            }
            personBlog.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.person_blog_20ts24tu.Update(personBlog);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(personBlog));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public PersonBlog GetByIdPersonBlog(int id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonBlog> query = _context.person_blog_20ts24tu
                .Where(x => x.id.Equals(id)).Include(x => x.status_);

            if (!isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonBlog personBlog = query.FirstOrDefault();

            return personBlog ?? new PersonBlog();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonBlog();
        }
    }

    public bool UpdatePersonBlog(int id, PersonBlog personBlog, bool isAdmin)
    {
        try
        {
            var dbcheck = GetByIdPersonBlog(id, false);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.title = personBlog.title;
            dbcheck.description = personBlog.description;
            dbcheck.text = personBlog.text;
            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.status_id = personBlog.status_id;

            if (isAdmin)
            {
                dbcheck.person_data_id = personBlog.person_data_id;
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


    #region PersonBlogTranslation CRUD

    public int CreatePersonBlogTranslation(PersonBlogTranslation personBlog)
    {
        try
        {
            if (personBlog == null)
            {
                return 0;
            }

            if (personBlog.person_data_id == 0 || personBlog.person_data_id is null)
            {
                User user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                PersonDataTranslation personData = _context.persons_data_translations_20ts24tu
                    .FirstOrDefault(x => x.persons_data_.persons_id == user.person_id && x.language_id == personBlog.language_id);
                if (personData == null) return 0;
                personBlog.person_data_id = personData.id;
            }

            _context.person_blog_translation_20ts24tu.Add(personBlog);
            _context.SaveChanges();

            int id = personBlog.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(personBlog));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public IEnumerable<PersonBlogTranslation> AllPersonBlogTranslation(int queryNum, int pageNum, int person_data_id, bool isAdmin, string language_code)
    {
        try
        {
            IQueryable<PersonBlogTranslation> query = _context.person_blog_translation_20ts24tu
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
            return Enumerable.Empty<PersonBlogTranslation>();
        }
    }

    public PersonBlogTranslation GetByIdPersonBlogTranslation(int id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonBlogTranslation> query = _context.person_blog_translation_20ts24tu
                .Where(x => x.id.Equals(id))
                .Include(x => x.language_).Include(x => x.status_);

            if (!isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonBlogTranslation personBlog = query.FirstOrDefault();

            return personBlog ?? new PersonBlogTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonBlogTranslation();
        }
    }

    public PersonBlogTranslation GetByIdPersonBlogTranslation(int uz_id, string language_code, bool isAdmin)
    {
        try
        {
            IQueryable<PersonBlogTranslation> query = _context.person_blog_translation_20ts24tu
                .Where(x => x.person_blog_.Equals(uz_id))
                .Where(x => x.language_.code.Equals(language_code))
                .Include(x => x.language_).Include(x => x.status_);

            if (!isAdmin)
            {
                query = query.Where(x => x.status_.status != "Deleted");
            }

            PersonBlogTranslation personBlog = query.FirstOrDefault();

            return personBlog ?? new PersonBlogTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonBlogTranslation();
        }
    }

    public bool DeletePersonBlogTranslation(int id)
    {
        try
        {
            var personBlog = GetByIdPersonBlogTranslation(id, false);
            if (personBlog == null)
            {
                return false;
            }
            personBlog.status_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.person_blog_translation_20ts24tu.Update(personBlog);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(personBlog));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public bool UpdatePersonBlogTranslation(int id, PersonBlogTranslation personBlog, bool isAdmin)
    {
        try
        {
            var dbcheck = GetByIdPersonBlogTranslation(id, false);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.title = personBlog.title;
            dbcheck.description = personBlog.description;
            dbcheck.text = personBlog.text;
            dbcheck.language_id = personBlog.language_id;
            dbcheck.person_blog_id = personBlog.person_blog_id;
            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.status_id = personBlog.status_id;

            if (isAdmin)
            {
                dbcheck.person_data_id = personBlog.person_data_id;
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
