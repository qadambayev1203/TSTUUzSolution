using Contracts.AllRepository.DepartamentsRepository;
using Entities.Model.DepartamentsModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Entities.Model.StatusModel;
using Newtonsoft.Json;
using Entities.Model.BlogsModel;

namespace Repository.AllSqlRepository.DepartamentsSqlRepository
{
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
        public IEnumerable<Departament> AllDepartament(int queryNum, int pageNum)
        {
            try
            {
                var departaments = new List<Departament>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departaments = _context.departament_20ts24tu.Include(x => x.img_).Include(x => x.img_icon_).Include(x => x.departament_type_).Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departaments = _context.departament_20ts24tu.Include(x => x.img_).Include(x => x.img_icon_).Include(x => x.departament_type_).Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    departaments = _context.departament_20ts24tu.Include(x => x.img_).Include(x => x.img_icon_).Include(x => x.departament_type_).Include(x => x.status_).ToList();

                }
                return departaments;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public IEnumerable<Departament> AllDepartamentSite(int queryNum, int pageNum)
        {
            try
            {
                var departaments = new List<Departament>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departaments = _context.departament_20ts24tu.Include(x => x.img_).Include(x => x.img_icon_).Include(x => x.departament_type_).Include(x => x.status_).Where(x => x.status_.status != "Deleted").Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departaments = _context.departament_20ts24tu.Include(x => x.img_).Include(x => x.img_icon_).Include(x => x.departament_type_).Include(x => x.status_).Where(x => x.status_.status != "Deleted").Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    departaments = _context.departament_20ts24tu.Include(x => x.img_).Include(x => x.img_icon_).Include(x => x.departament_type_).Include(x => x.status_).Where(x => x.status_.status != "Deleted").ToList();

                }
                return departaments;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
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
                dbcheck.title = departament.title;
                dbcheck.description = departament.description;
                dbcheck.text = departament.text;
                dbcheck.parent_id = departament.parent_id;
                dbcheck.status_id = departament.status_id;
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
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public IEnumerable<Departament> AllDepartamentType(string dep_type, int queryNum, int pageNum)
        {
            try
            {
                var departaments = new List<Departament>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departaments = _context.departament_20ts24tu
                        .Include(x => x.img_).Include(x => x.img_icon_)
                   .Include(x => x.departament_type_)
                   .Include(x => x.status_)
                   .Where(x => x.departament_type_.type == dep_type)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departaments = _context.departament_20ts24tu
                        .Include(x => x.img_).Include(x => x.img_icon_)
                   .Include(x => x.departament_type_)
                   .Include(x => x.status_)
                   .Where(x => x.departament_type_.type == dep_type)
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    departaments = _context.departament_20ts24tu
                        .Include(x => x.img_).Include(x => x.img_icon_)
                   .Include(x => x.departament_type_)
                   .Include(x => x.status_)
                   .Where(x => x.departament_type_.type == dep_type)
                  .ToList();

                }
                return departaments;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public IEnumerable<Departament> AllDepartamentTypeSite(string dep_type, int queryNum, int pageNum, bool? favorite)
        {
            try
            {
                var departaments = new List<Departament>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departaments = _context.departament_20ts24tu
                        .Include(x => x.img_).Include(x => x.img_icon_)
                   .Include(x => x.departament_type_)
                   .Include(x => x.status_)
                   .Where(x => x.departament_type_.type == dep_type)
                   .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                   .Where(x => x.status_.status != "Deleted")
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departaments = _context.departament_20ts24tu
                        .Include(x => x.img_).Include(x => x.img_icon_)
                   .Include(x => x.departament_type_)
                   .Include(x => x.status_)
                   .Where(x => x.departament_type_.type == dep_type)
                   .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                   .Where(x => x.status_.status != "Deleted")
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    departaments = _context.departament_20ts24tu
                        .Include(x => x.img_).Include(x => x.img_icon_)
                   .Include(x => x.departament_type_)
                   .Include(x => x.status_)
                   .Where(x => x.departament_type_.type == dep_type)
                   .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                   .Where(x => x.status_.status != "Deleted").ToList();

                }
                return departaments;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public IEnumerable<Departament> AllDepartamentFacultyDirection(int faculty_id)
        {
            try
            {
                List<Departament> departaments_id = new List<Departament>();

                departaments_id = _context.departament_20ts24tu.
                    Where(x => (x.parent_id == faculty_id && x.departament_type_.type == "Kafedra"))
                    .Where(x => x.status_.status != "Deleted")
                   .Select(x => new Departament
                   {
                       id = x.id,
                   }).ToList();
                List<Departament> allDirection = new List<Departament>();
                foreach (var item in departaments_id)
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

                return allDirection;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }





        //DepartamentTranslation CRUD
        public IEnumerable<DepartamentTranslation> AllDepartamentTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var departamentTranslations = new List<DepartamentTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departamentTranslations = _context.departament_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.img_).Include(x => x.img_icon_)
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.departament_type_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (queryNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentTranslations = _context.departament_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.img_).Include(x => x.img_icon_)
                        .Include(x => x.departament_type_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (queryNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    departamentTranslations = _context.departament_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.img_).Include(x => x.img_icon_)
                        .Include(x => x.departament_type_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return departamentTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public IEnumerable<DepartamentTranslation> AllDepartamentTranslationSite(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var departamentTranslations = new List<DepartamentTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departamentTranslations = _context.departament_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.img_).Include(x => x.img_icon_)
                        .Include(x => x.departament_type_translation_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (queryNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentTranslations = _context.departament_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.img_).Include(x => x.img_icon_)
                        .Include(x => x.departament_type_translation_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (queryNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    departamentTranslations = _context.departament_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.img_).Include(x => x.img_icon_)
                        .Include(x => x.departament_type_translation_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return departamentTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
                return false;
            }
        }

        public bool SaveChanges()
        {
            try { _context.SaveChanges(); return true; }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString()); return false;
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
                    .Where(x => x.parent_id == parent_id)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();



                return departamentTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public IEnumerable<DepartamentTranslation> AllDepartamentTranslationType(string dep_type, string language_code, int queryNum, int pageNum)
        {
            try
            {
                var departamentTranslations = new List<DepartamentTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departamentTranslations = _context.departament_translations_20ts24tu
                         .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.img_).Include(x => x.img_icon_)
                    .Include(x => x.departament_type_translation_)
                    .Where(x => x.departament_type_translation_.type == dep_type)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (queryNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentTranslations = _context.departament_translations_20ts24tu
                         .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.img_).Include(x => x.img_icon_)
                    .Include(x => x.departament_type_translation_)
                    .Where(x => x.departament_type_translation_.type == dep_type)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (queryNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    departamentTranslations = _context.departament_translations_20ts24tu
                         .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.img_).Include(x => x.img_icon_)
                    .Include(x => x.departament_type_translation_)
                    .Where(x => x.departament_type_translation_.type == dep_type)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return departamentTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public IEnumerable<DepartamentTranslation> AllDepartamentTranslationTypeSite(string dep_type, string language_code, int queryNum, int pageNum, bool? favorite)
        {
            try
            {
                var departamentTranslations = new List<DepartamentTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departamentTranslations = _context.departament_translations_20ts24tu
                         .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.img_).Include(x => x.img_icon_)
                    .Include(x => x.departament_type_translation_)
                    .Where(x => x.departament_type_translation_.departament_type_.type == dep_type)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (queryNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentTranslations = _context.departament_translations_20ts24tu
                         .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.img_).Include(x => x.img_icon_)
                    .Include(x => x.departament_type_translation_)
                    .Where(x => x.departament_type_translation_.departament_type_.type == dep_type)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (queryNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    departamentTranslations = _context.departament_translations_20ts24tu
                         .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.img_).Include(x => x.img_icon_)
                    .Include(x => x.departament_type_translation_)
                    .Where(x => x.departament_type_translation_.departament_type_.type == dep_type)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return departamentTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
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
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }



        public IEnumerable<DepartamentTranslation> AllDepartamentTranslationFacultyDirection(int faculty_id, string language_code)
        {
            try
            {
                List<DepartamentTranslation> departaments_id = new List<DepartamentTranslation>();

                departaments_id = _context.departament_translations_20ts24tu.
                    Where(x => (x.departament_.parent_id == faculty_id && x.departament_type_translation_.departament_type_.type == "Kafedra"))
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                   .Select(x => new DepartamentTranslation
                   {
                       id = x.id,
                   }).ToList();
                List<DepartamentTranslation> allDirection = new List<DepartamentTranslation>();
                foreach (var item in departaments_id)
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

                return allDirection;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }
    }
}
