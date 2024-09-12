using Contracts.AllRepository.DepartamentsRepository;
using Entities.Model.DepartamentsModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Entities.Model.AnyClasses;

namespace Repository.AllSqlRepository.DepartamentsSqlRepository;

public class DepartamentSqlRepository : IDepartamentRepository
{

    private readonly RepositoryContext _context;
    private readonly ILogger<DepartamentSqlRepository> _logger;
    public DepartamentSqlRepository(RepositoryContext repositoryContext, ILogger<DepartamentSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }




    //Departament CRUD
    public QueryList<Departament> AllDepartament(int queryNum, int pageNum)
    {
        try
        {
            IQueryable<Departament> query = _context.departament_20ts24tu.Include(x => x.img_)
                .Include(x => x.img_icon_).Include(x => x.departament_type_).Include(x => x.status_);
            int length = query.Count();

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1)).Take(queryNum);

            }

            QueryList<Departament> departaments = new QueryList<Departament>
            {
                length = length,
                query_list = query.ToList()
            };
            return departaments;

        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public QueryList<Departament> AllDepartamentSite(int queryNum, int pageNum)
    {
        try
        {
            IQueryable<Departament> query = _context.departament_20ts24tu.Include(x => x.img_)
                .Include(x => x.img_icon_).Include(x => x.departament_type_).Include(x => x.status_)
                .Where(x => x.status_.status != "Deleted");
            int length = query.Count();

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1)).Take(queryNum);

            }

            QueryList<Departament> departaments = new QueryList<Departament>
            {
                length = length,
                query_list = query.ToList()
            };
            return departaments;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public int CreateDepartament(Departament departament)
    {
        try
        {
            if (departament == null)
            {
                return 0;
            }
            _context.departament_20ts24tu.Add(departament);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(departament));

            return departament.id;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return 0;
        }
    }

    public bool DeleteDepartament(int id)
    {
        try
        {
            var departament = GetDepartamentById(id);
            if (departament == null)
            {
                return false;
            }
            departament.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.departament_20ts24tu.Update(departament);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(departament));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return false;
        }
    }

    public Departament GetDepartamentById(int id)
    {
        try
        {
            var departament = _context.departament_20ts24tu.Include(x => x.img_).Include(x => x.img_icon_).Include(x => x.departament_type_).Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

            return departament;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public Departament GetDepartamentByIdSite(int id)
    {
        try
        {
            var departament = _context.departament_20ts24tu.Include(x => x.img_).Include(x => x.img_icon_).Include(x => x.departament_type_).Include(x => x.status_).Where(x => x.status_.status != "Deleted").FirstOrDefault(x => x.id.Equals(id));

            return departament;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public bool UpdateDepartament(int id, Departament departament)
    {

        try
        {
            var dbcheck = GetDepartamentById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.title_short = departament.title_short;
            dbcheck.hemis_id = departament.hemis_id;
            dbcheck.title = departament.title;
            dbcheck.description = departament.description;
            dbcheck.text = departament.text;
            dbcheck.parent_id = departament.parent_id;
            dbcheck.status_id = departament.status_id;
            dbcheck.updated_at = DateTime.UtcNow;
            if (departament.img_ != null)
            {
                dbcheck.img_ = departament.img_;
            }
            if (departament.img_icon_ != null)
            {
                dbcheck.img_icon_ = departament.img_icon_;
            }


            dbcheck.position = departament.position;
            dbcheck.favorite = departament.favorite;
            dbcheck.departament_type_id = departament.departament_type_id;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return false;
        }
    }

    public IEnumerable<Departament> AllDepartamentChild(int parent_id)
    {
        try
        {
            var departaments = new List<Departament>();
            departaments = _context.departament_20ts24tu
               .Include(x => x.img_).Include(x => x.img_icon_)
               .Include(x => x.departament_type_)
               .Include(x => x.status_).Where(x => x.status_.status != "Deleted")
               .Where(x => x.parent_id == parent_id)
               .ToList();

            return departaments;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public QueryList<Departament> AllDepartamentType(string dep_type, int queryNum, int pageNum)
    {
        try
        {
            IQueryable<Departament> query = _context.departament_20ts24tu
                    .Include(x => x.img_).Include(x => x.img_icon_)
               .Include(x => x.departament_type_)
               .Include(x => x.status_)
               .Where(x => x.departament_type_.type == dep_type);

            int length = query.Count();

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);
            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1)).Take(queryNum);
            }
            QueryList<Departament> departaments = new QueryList<Departament>
            {
                length = length,
                query_list = query.ToList()
            };
            return departaments;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public QueryList<Departament> AllDepartamentTypeSite(string dep_type, int queryNum, int pageNum, bool? favorite)
    {
        try
        {
            IQueryable<Departament> query = _context.departament_20ts24tu
                    .Include(x => x.img_).Include(x => x.img_icon_)
               .Include(x => x.departament_type_)
               .Include(x => x.status_)
               .Where(x => x.departament_type_.type == dep_type)
               .Where((favorite == true) ? x => x.favorite == true : x => x != null)
               .Where(x => x.status_.status != "Deleted");

            int length = query.Count();

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1)).Take(queryNum);

            }
            QueryList<Departament> departaments = new QueryList<Departament>
            {
                length = length,
                query_list = query.ToList()
            };
            return departaments;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public IEnumerable<Departament> SelectDepartaments()
    {
        try
        {
            var departaments = new List<Departament>();
            departaments = _context.departament_20ts24tu
               .Where(x => x.status_.status != "Deleted")
               .Select(x => new Departament
               {
                   id = x.id,
                   title_short = x.title_short,
                   title = x.title
               }).ToList();


            return departaments;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public IEnumerable<Departament> AllDepartamentFacultyDirection(int faculty_id)
    {
        try
        {
            List<Departament> departaments_id = new List<Departament>();

            departaments_id = _context.departament_20ts24tu
                 .Include(x => x.img_).Include(x => x.img_icon_)
                   .Include(x => x.departament_type_)
                   .Where(x => x.status_.status != "Deleted")
                .Where(x => (x.parent_id == faculty_id)).ToList();

            List<Departament> allDirection = new List<Departament>();
            foreach (var item in departaments_id)
            {
                if (item.departament_type_.type == "Kafedra")
                {
                    List<Departament> depDirection = new List<Departament>();
                    depDirection = _context.departament_20ts24tu
                            .Include(x => x.img_).Include(x => x.img_icon_)
                       .Include(x => x.departament_type_)
                       .Where(x => x.parent_id == item.id)
                       .Where(x => x.status_.status != "Deleted")
                            .ToList();

                    allDirection.AddRange(depDirection);
                }
            }

            allDirection.AddRange(departaments_id);

            return allDirection;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public IEnumerable<Departament> AllDepartamentStructure()
    {
        try
        {
            var departaments = new List<Departament>();
            departaments = _context.departament_20ts24tu
               .Where(x => x.status_.status != "Deleted")
               .Select(x => new Departament
               {
                   id = x.id,
                   title = x.title,
                   parent_id = x.parent_id,
               })
               .ToList();

            return departaments;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return Enumerable.Empty<Departament>();
        }
    }


    public IEnumerable<Departament> SelectFaculty()
    {
        try
        {
            var departaments = new List<Departament>();
            departaments = _context.departament_20ts24tu
               .Where(x => x.status_.status != "Deleted" && x.departament_type_id == 22)
               .Select(x => new Departament
               {
                   id = x.id,
                   title_short = x.title_short,
                   title = x.title
               }).ToList();


            return departaments;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return Enumerable.Empty<Departament>();
        }
    }

    public IEnumerable<Departament> SelectFacultyDepartament(int? faculty_id)
    {
        try
        {
            if (faculty_id == 0 || faculty_id == null)
            {
                var user = _context.users_20ts24tu.Include(x => x.person_).ThenInclude(x => x.departament_).FirstOrDefault(x => x.id == SessionClass.id);
                if (user != null && user.person_.departament_.departament_type_id == 22)
                {
                    faculty_id = user.person_.departament_id.Value;
                }
                else
                {
                    return Enumerable.Empty<Departament>();
                }
            }

            var departaments = new List<Departament>();
            departaments = _context.departament_20ts24tu
               .Where(x => x.status_.status != "Deleted")
               .Where(x => x.parent_id == faculty_id && x.departament_type_id == 26)
               .Select(x => new Departament
               {
                   id = x.id,
                   title_short = x.title_short,
                   title = x.title
               }).ToList();


            return departaments;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return Enumerable.Empty<Departament>();
        }
    }





    //DepartamentTranslation CRUD
    public QueryList<DepartamentTranslation> AllDepartamentTranslation(int queryNum, int pageNum, string language_code)
    {
        try
        {
            IQueryable<DepartamentTranslation> query = _context.departament_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.img_).Include(x => x.img_icon_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.departament_type_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null);

            int length = query.Count();

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

            QueryList<DepartamentTranslation> departamentTranslations = new QueryList<DepartamentTranslation>
            {
                length = length,
                query_list = query.ToList()
            };

            return departamentTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public QueryList<DepartamentTranslation> AllDepartamentTranslationSite(int queryNum, int pageNum, string language_code)
    {
        try
        {
            IQueryable<DepartamentTranslation> query = _context.departament_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.img_).Include(x => x.img_icon_)
                    .Include(x => x.departament_type_translation_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null);

            int length = query.Count();

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1))
                    .Take(10);

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1))
                    .Take(queryNum);

            }

            QueryList<DepartamentTranslation> departamentTranslations = new QueryList<DepartamentTranslation>
            {
                length = length,
                query_list = query.ToList()
            };

            return departamentTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public int CreateDepartamentTranslation(DepartamentTranslation departamentTranslation)
    {
        try
        {
            if (departamentTranslation == null)
            {
                return 0;
            }
            _context.departament_translations_20ts24tu.Add(departamentTranslation);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(departamentTranslation));

            return departamentTranslation.id;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return 0;
        }
    }

    public bool DeleteDepartamentTranslation(int id)
    {
        try
        {
            var departamentTranslation = GetDepartamentTranslationById(id);
            if (departamentTranslation == null)
            {
                return false;
            }
            departamentTranslation.status_translation_id = (_context.statuses_translations_20ts24tu
                .FirstOrDefault(x => x.status == "Deleted" && x.language_id == departamentTranslation.language_id)).id;
            _context.departament_translations_20ts24tu.Update(departamentTranslation);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(departamentTranslation));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return false;
        }
    }

    public DepartamentTranslation GetDepartamentTranslationById(int id)
    {
        try
        {
            var departamentTranslation = _context.departament_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.img_).Include(x => x.img_icon_)
                    .Include(x => x.departament_type_translation_).FirstOrDefault(x => x.id.Equals(id));
            return departamentTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }
    public DepartamentTranslation GetDepartamentTranslationById(int uz_id, string language_code)
    {
        try
        {
            var departamentTranslation = _context.departament_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.img_).Include(x => x.img_icon_)
                    .Include(x => x.departament_type_translation_).FirstOrDefault(x => x.departament_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return departamentTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public DepartamentTranslation GetDepartamentTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var departamentTranslation = _context.departament_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.img_).Include(x => x.img_icon_)
                    .Include(x => x.departament_type_translation_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .FirstOrDefault(x => x.departament_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return departamentTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public DepartamentTranslation GetDepartamentTranslationByIdSite(int id)
    {
        try
        {
            var departamentTranslation = _context.departament_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.img_).Include(x => x.img_icon_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Include(x => x.departament_type_translation_).FirstOrDefault(x => x.id.Equals(id));
            return departamentTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public bool UpdateDepartamentTranslation(int id, DepartamentTranslation departament)
    {

        try
        {
            var dbcheck = GetDepartamentTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.title_short = departament.title_short;
            dbcheck.title = departament.title;
            dbcheck.description = departament.description;
            dbcheck.text = departament.text;
            dbcheck.parent_id = departament.parent_id;
            dbcheck.language_id = departament.language_id;
            dbcheck.updated_at = departament.updated_at;
            dbcheck.status_translation_id = departament.status_translation_id;
            if (departament.img_ != null)
            {
                dbcheck.img_ = departament.img_;
            }
            if (departament.img_icon_ != null)
            {
                dbcheck.img_icon_ = departament.img_icon_;
            }
            dbcheck.position = departament.position;
            dbcheck.favorite = departament.favorite;
            dbcheck.departament_type_translation_id = departament.departament_type_translation_id;
            dbcheck.departament_id = departament.departament_id;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return false;
        }
    }

    public bool SaveChanges()
    {
        try { _context.SaveChanges(); return true; }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message); return false;
        }
    }

    public IEnumerable<DepartamentTranslation> AllDepartamentTranslationChild(int parent_id, string language_code)
    {
        try
        {
            var departamentTranslations = new List<DepartamentTranslation>();

            departamentTranslations = _context.departament_translations_20ts24tu
                .Include(x => x.language_)
                .Include(x => x.status_translation_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                .Include(x => x.img_).Include(x => x.img_icon_)
                .Include(x => x.departament_type_translation_).ThenInclude(x => x.departament_type_)
                .Where(x => x.status_translation_.status != "Deleted")
                .Where(x => x.departament_.parent_id == parent_id)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                .ToList();



            return departamentTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public QueryList<DepartamentTranslation> AllDepartamentTranslationType(string dep_type, string language_code, int queryNum, int pageNum)
    {
        try
        {
            IQueryable<DepartamentTranslation> query = _context.departament_translations_20ts24tu
                     .Include(x => x.language_)
                .Include(x => x.status_translation_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                .Include(x => x.img_).Include(x => x.img_icon_)
                .Include(x => x.departament_type_translation_)
                .Where(x => x.departament_type_translation_.type == dep_type)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null);

            int length = query.Count();

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (queryNum - 1))
                    .Take(10);

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1))
                    .Take(queryNum);
            }

            QueryList<DepartamentTranslation> departamentTranslations = new QueryList<DepartamentTranslation>
            {
                length = length,
                query_list = query.ToList()
            };

            return departamentTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public QueryList<DepartamentTranslation> AllDepartamentTranslationTypeSite(string dep_type, string language_code, int queryNum, int pageNum, bool? favorite)
    {
        try
        {
            IQueryable<DepartamentTranslation> query = _context.departament_translations_20ts24tu
                     .Include(x => x.language_)
                .Include(x => x.status_translation_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                .Include(x => x.img_).Include(x => x.img_icon_)
                .Include(x => x.departament_type_translation_)
                .Where(x => x.departament_type_translation_.departament_type_.type == dep_type)
                .Where(x => x.status_translation_.status != "Deleted")
                .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null);

            int length = query.Count();


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

            QueryList<DepartamentTranslation> departamentTranslations = new QueryList<DepartamentTranslation>
            {
                length = length,
                query_list = query.ToList()
            };

            return departamentTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public IEnumerable<DepartamentTranslation> SelectDepartamentsTranslation(string language_code)
    {
        try
        {
            var departaments = new List<DepartamentTranslation>();
            departaments = _context.departament_translations_20ts24tu
               .Where(x => x.status_translation_.status != "Deleted")
               .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
               .Select(x => new DepartamentTranslation
               {
                   id = x.id,
                   title_short = x.title_short,
                   title = x.title,
                   departament_id = x.departament_id
               })
               .ToList();


            return departaments;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public IEnumerable<DepartamentTranslation> AllDepartamentTranslationFacultyDirection(int faculty_id, string language_code)
    {
        try
        {
            List<DepartamentTranslation> departaments_id = new List<DepartamentTranslation>();

            departaments_id = _context.departament_translations_20ts24tu
                .Include(x => x.img_)
                        .Include(x => x.img_icon_)
                        .Include(x => x.language_)
                        .Include(x => x.departament_)
                   .Include(x => x.departament_type_translation_).ThenInclude(y => y.departament_type_)
                   .Where(x => x.departament_.parent_id == faculty_id)
                   .Where(x => x.status_translation_.status != "Deleted")
                   .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null).ToList();

            List<DepartamentTranslation> allDirection = new List<DepartamentTranslation>();
            foreach (var item in departaments_id)
            {
                if (item.departament_type_translation_.departament_type_.type == "Kafedra")
                {
                    List<DepartamentTranslation> depDirection = new List<DepartamentTranslation>();
                    depDirection = _context.departament_translations_20ts24tu
                            .Include(x => x.img_)
                            .Include(x => x.img_icon_)
                            .Include(x => x.language_)
                            .Include(x => x.departament_)
                       .Include(x => x.departament_type_translation_).ThenInclude(y => y.departament_type_)
                       .Where(x => x.parent_id == item.id)
                       .Where(x => x.status_translation_.status != "Deleted")
                       .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                            .ToList();

                    allDirection.AddRange(depDirection);
                }
            }

            allDirection.AddRange(departaments_id);

            return allDirection;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public IEnumerable<DepartamentTranslation> AllDepartamentTranslationStructure(string language_code)
    {
        try
        {
            var departaments = new List<DepartamentTranslation>();
            departaments = _context.departament_translations_20ts24tu
               .Where(x => x.status_translation_.status != "Deleted")
               .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
               .Select(x => new DepartamentTranslation
               {
                   id = x.id,
                   title = x.title,
                   parent_id = x.parent_id,
                   departament_id = x.departament_id
               })
               .ToList();

            return departaments;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return Enumerable.Empty<DepartamentTranslation>();
        }


    }
}
