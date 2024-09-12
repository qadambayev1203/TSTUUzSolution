using Contracts.AllRepository.PagesRepository;
using Entities.Model.PagesModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.PagesSqlRepository;

public class PageSqlRepository : IPageRepository
{
    private readonly RepositoryContext _context;
    private readonly ILogger<PageSqlRepository> _logger;
    public PageSqlRepository(RepositoryContext repositoryContext, ILogger<PageSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }



    //Page CRUD
    public IEnumerable<Pages> AllPage(int queryNum, int pageNum)
    {
        try
        {
            var pages = new List<Pages>();
            if (queryNum == 0 && pageNum != 0)
            {
                pages = _context.pages_20ts24tu.Include(x => x.img_).Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                pages = _context.pages_20ts24tu.Include(x => x.img_).Include(x => x.user_).ThenInclude(y => y.user_type_).Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                pages = _context.pages_20ts24tu.Include(x => x.img_).Include(x => x.user_).ThenInclude(y => y.user_type_).Include(x => x.status_).ToList();

            }
            return pages;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<Pages> AllPageSelect()
    {
        try
        {
            var pages = new List<Pages>();


            pages = _context.pages_20ts24tu
                .Select(x => new Pages
                {
                    id = x.id,
                    title_short = x.title_short,
                    title = x.title,
                    description = x.description,
                    status_ = x.status_
                })
                .ToList();

            return pages;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<Pages> AllPageSite(int queryNum, int pageNum)
    {
        try
        {
            var pages = new List<Pages>();
            if (queryNum == 0 && pageNum != 0)
            {
                pages = _context.pages_20ts24tu.Include(x => x.img_).Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.status_).Where(x => x.status_.status != "Deleted").Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                pages = _context.pages_20ts24tu.Include(x => x.img_).Where(x => x.status_.status != "Deleted").Include(x => x.user_).ThenInclude(y => y.user_type_)
                .Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                pages = _context.pages_20ts24tu.Include(x => x.img_).Where(x => x.status_.status != "Deleted").Include(x => x.user_).ThenInclude(y => y.user_type_)
                .Include(x => x.status_).ToList();

            }
            return pages;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreatePage(Pages page)
    {
        try
        {
            if (page == null)
            {
                return 0;
            }
            _context.pages_20ts24tu.Add(page);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(page));

            return page.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeletePage(int id)
    {
        try
        {
            var page = GetPageById(id);
            if (page == null)
            {
                return false;
            }
            page.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.pages_20ts24tu.Update(page);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(page));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public Pages GetPageById(int id)
    {
        try
        {
            var page = _context.pages_20ts24tu.Include(x => x.img_).Include(x => x.user_).ThenInclude(y => y.user_type_).Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

            return page;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public Pages GetPageByIdSite(int id)
    {
        try
        {
            var page = _context.pages_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.img_).Include(x => x.user_).ThenInclude(y => y.user_type_).Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

            return page;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdatePage(int id, Pages pages)
    {

        try
        {
            var dbcheck = GetPageById(id);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.title_short = pages.title_short;
            dbcheck.title = pages.title;
            dbcheck.description = pages.description;
            dbcheck.text = pages.text;
            dbcheck.status_id = pages.status_id;
            if (pages.img_ != null)
            {
                dbcheck.img_ = pages.img_;
            }

            dbcheck.position = pages.position;
            dbcheck.favorite = pages.favorite;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }







    //PageTranslation CRUD
    public IEnumerable<PageTranslation> AllPageTranslation(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var pageTranslations = new List<PageTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                pageTranslations = _context.pages_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.img_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.page_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                pageTranslations = _context.pages_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.img_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.page_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();

            }
            else
            {
                pageTranslations = _context.pages_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.img_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.page_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();

            }
            return pageTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<PageTranslation> AllPageTranslationSelect(string language_code)
    {
        try
        {
            var pages = new List<PageTranslation>();


            pages = _context.pages_translations_20ts24tu
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                .Select(x => new PageTranslation
                {
                    id = x.id,
                    title_short = x.title_short,
                    title = x.title,
                    description = x.description,
                    status_translation_ = x.status_translation_,
                    page_id = x.page_id
                })
                .ToList();

            return pages;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public IEnumerable<PageTranslation> AllPageTranslationSite(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var pageTranslations = new List<PageTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                pageTranslations = _context.pages_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.img_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.page_).Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                pageTranslations = _context.pages_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.img_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.page_).Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();

            }
            else
            {
                pageTranslations = _context.pages_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.img_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.page_).Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();

            }
            return pageTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreatePageTranslation(PageTranslation pageTranslation)
    {
        try
        {
            if (pageTranslation == null)
            {
                return 0;
            }
            _context.pages_translations_20ts24tu.Add(pageTranslation);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(pageTranslation));

            return pageTranslation.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeletePageTranslation(int id)
    {
        try
        {
            var pageTranslation = GetPageTranslationById(id);
            if (pageTranslation == null)
            {
                return false;
            }
            pageTranslation.status_translation_id = (_context.statuses_translations_20ts24tu
                .FirstOrDefault(x => x.status == "Deleted" && x.language_id == pageTranslation.language_id)).id;
            _context.pages_translations_20ts24tu.Update(pageTranslation);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(pageTranslation));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public PageTranslation GetPageTranslationByIdSite(int id)
    {
        try
        {
            var pageTranslation = _context.pages_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.img_translation_).Where(x => x.status_translation_.status != "Deleted")
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.page_).FirstOrDefault(x => x.id.Equals(id));
            return pageTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public PageTranslation GetPageTranslationById(int id)
    {
        try
        {
            var pageTranslation = _context.pages_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.img_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.page_).FirstOrDefault(x => x.id.Equals(id));
            return pageTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public PageTranslation GetPageTranslationById(int uz_id, string language_code)
    {
        try
        {
            var pageTranslation = _context.pages_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.img_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.page_).FirstOrDefault(x => x.page_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return pageTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public PageTranslation GetPageTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var pageTranslation = _context.pages_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.img_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.page_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .FirstOrDefault(x => x.page_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return pageTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdatePageTranslation(int id, PageTranslation pageTranslation)
    {

        try
        {
            var dbcheck = GetPageTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.title_short = pageTranslation.title_short;
            dbcheck.title = pageTranslation.title;
            dbcheck.description = pageTranslation.description;
            dbcheck.text = pageTranslation.text;
            dbcheck.page_id = pageTranslation.page_id;
            dbcheck.status_translation_id = pageTranslation.status_translation_id;
            if (pageTranslation.img_translation_ != null)
            {
                dbcheck.img_translation_ = pageTranslation.img_translation_;
            }
            dbcheck.position = pageTranslation.position;
            dbcheck.favorite = pageTranslation.favorite;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }
    public bool SaveChanges()
    {
        try { _context.SaveChanges(); return true; }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message); return false;
        }
    }

}
