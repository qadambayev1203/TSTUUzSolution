﻿using Contracts.AllRepository.PersonsDataRepository.PersonBlogRepository;
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
    private readonly List<string> userType = SessionClass.userTypeConfirm;
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
            if (person_data_id == null || person_data_id == 0)
            {
                var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                var person_data_ = _context.persons_data_20ts24tu.FirstOrDefault(x => x.persons_id == user.person_id);
                if (person_data_ != null)
                {
                    person_data_id = person_data_.id;
                }
            }

            IQueryable<PersonBlog> query = _context.person_blog_20ts24tu
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
            return Enumerable.Empty<PersonBlog>();
        }
    }

    public IEnumerable<PersonBlog> AllPersonBlogSite(int queryNum, int pageNum, int person_data_id)
    {
        try
        {
            IQueryable<PersonBlog> query = _context.person_blog_20ts24tu
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

            personBlog.confirmed = 0;
            if (personBlog.person_data_id == 0 || personBlog.person_data_id is null)
            {
                User user = _context.users_20ts24tu.Include(x => x.user_type_).FirstOrDefault(x => x.id == SessionClass.id);
                PersonData personData = _context.persons_data_20ts24tu.FirstOrDefault(x => x.persons_id == user.person_id);
                if (personData == null) return 0;
                personBlog.person_data_id = personData.id;
                if (userType.Contains(user.user_type_.type))
                {
                    personBlog.confirmed = 1;
                }
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
                .Where(x => x.id.Equals(id))
                .Include(x => x.person_data_).ThenInclude(x => x.persons_)
                .Include(x => x.status_);

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

    public PersonBlog GetByIdPersonBlogSite(int id)
    {
        try
        {
            var res = _context.person_blog_20ts24tu
                .Where(x => x.status_.status != "Deleted")
                .Where(x => x.id.Equals(id))
                .Where(x => x.confirmed.Equals(1))
                .FirstOrDefault();

            return res ?? new PersonBlog();
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

            dbcheck.confirmed = 0;

            User user = _context.users_20ts24tu.Include(x => x.user_type_).FirstOrDefault(x => x.id == SessionClass.id);
            if (user != null && user.user_type_.type != null)
            {
                if (userType.Contains(user.user_type_.type))
                {
                    dbcheck.confirmed = 1;
                }

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

            int confirmed = 0;
            if (personBlog.person_data_id == 0 || personBlog.person_data_id is null)
            {
                User user = _context.users_20ts24tu.Include(x => x.user_type_).FirstOrDefault(x => x.id == SessionClass.id);
                PersonDataTranslation personData = _context.persons_data_translations_20ts24tu
                    .FirstOrDefault(x => x.persons_data_.persons_id == user.person_id && x.language_id == personBlog.language_id);
                if (personData == null) return 0;
                personBlog.person_data_id = personData.id;

                if (userType.Contains(user.user_type_.type))
                {
                    confirmed = 1;
                }
            }

            var person_blog_ = _context.person_blog_20ts24tu.FirstOrDefault(x => x.id == personBlog.person_blog_id);
            person_blog_.confirmed = confirmed;

            personBlog.person_blog_ = person_blog_;

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
            if (person_data_id == null || person_data_id == 0)
            {
                var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                var person_data_ = _context.persons_data_20ts24tu.FirstOrDefault(x => x.persons_id == user.person_id);
                if (person_data_ != null)
                {
                    person_data_id = person_data_.id;
                }
            }

            IQueryable<PersonBlogTranslation> query = _context.person_blog_translation_20ts24tu
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
            return Enumerable.Empty<PersonBlogTranslation>();
        }
    }
    public IEnumerable<PersonBlogTranslation> AllPersonBlogTranslationSite(int queryNum, int pageNum, int person_data_id, string language_code)
    {
        try
        {
            IQueryable<PersonBlogTranslation> query = _context.person_blog_translation_20ts24tu
                .Include(x => x.language_)
                .Where(x => x.person_data_.persons_data_id == person_data_id)
                .Where(x => x.person_blog_.confirmed == 1)
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
            return Enumerable.Empty<PersonBlogTranslation>();
        }
    }

    public PersonBlogTranslation GetByIdPersonBlogTranslation(int id, bool isAdmin)
    {
        try
        {
            IQueryable<PersonBlogTranslation> query = _context.person_blog_translation_20ts24tu
                .Where(x => x.id.Equals(id))
                .Include(x => x.language_)
                .Include(x => x.person_blog_)
                .Include(x => x.status_);

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

    public PersonBlogTranslation GetByIdPersonBlogTranslationSite(int id)
    {
        try
        {
            var res = _context.person_blog_translation_20ts24tu
                .Where(x => x.id.Equals(id))
                .Where(x => x.person_blog_.confirmed.Equals(1))
                .Where(x => x.status_.status != "Deleted")
                .Include(x => x.language_)
                .FirstOrDefault();

            return res ?? new PersonBlogTranslation();
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
                .Where(x => x.person_blog_id.Equals(uz_id))
                .Where(x => x.language_.code.Equals(language_code))
                .Include(x => x.language_)
                .Include(x => x.person_blog_)
                .Include(x => x.status_);

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
    public PersonBlogTranslation GetByIdPersonBlogTranslationSite(int uz_id, string language_code)
    {
        try
        {
            var res = _context.person_blog_translation_20ts24tu
                 .Where(x => x.person_blog_id.Equals(uz_id))
                 .Where(x => x.person_blog_.confirmed.Equals(1))
                 .Where(x => x.status_.status != "Deleted")
                 .Include(x => x.language_)
                 .FirstOrDefault();

            return res ?? new PersonBlogTranslation();
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

            dbcheck.person_blog_.confirmed = 0;

            User user = _context.users_20ts24tu.Include(x => x.user_type_).FirstOrDefault(x => x.id == SessionClass.id);

            if (userType.Contains(user.user_type_.type))
            {
                dbcheck.person_blog_.confirmed = 1;
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




    public IEnumerable<PersonData> AllPersonBlogCreated()
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

    public IEnumerable<PersonBlog> AllPersonBlogDep(int queryNum, int pageNum, int person_data_id)
    {
        try
        {
            IQueryable<PersonBlog> query = _context.person_blog_20ts24tu
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
            return Enumerable.Empty<PersonBlog>();
        }
    }

    public bool ConfirmDocumentTeacher110Set(int id, bool confirm)
    {
        try
        {
            var dbcheck = GetByIdPersonBlog(id, false);

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
