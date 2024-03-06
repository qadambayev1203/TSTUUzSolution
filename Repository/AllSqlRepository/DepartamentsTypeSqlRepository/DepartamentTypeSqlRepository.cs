using Contracts.AllRepository.DepartamentsTypeRepository;
using Entities.Model.DepartamentsTypeModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.DepartamentsTypeSqlRepository
{
    public class DepartamentTypeSqlRepository : IDepartamentTypeRepository
    {
        private readonly RepositoryContext _context;
        public DepartamentTypeSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        //DepartamentType CRUD
        public IEnumerable<DepartamentType> AllDepartamentType(int queryNum, int pageNum)
        {
            try
            {
                var departamentTypes = new List<DepartamentType>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departamentTypes = _context.departament_types_20ts24tu.Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentTypes = _context.departament_types_20ts24tu.Include(x => x.status_).Take(queryNum).ToList();

                }
                else
                {
                    departamentTypes = _context.departament_types_20ts24tu.Include(x => x.status_).Take(200).ToList();

                }
                return departamentTypes;
            }
            catch
            {
                return null;
            }
        }

        public int CreateDepartamentType(DepartamentType departamentType)
        {
            try
            {
                if (departamentType == null)
                {
                    return 0;
                }
                _context.departament_types_20ts24tu.Add(departamentType);
                _context.SaveChanges();

                return departamentType.id;
            }
            catch
            {
                return 0;
            }
        }

        public bool DeleteDepartamentType(int id)
        {
            try
            {
                var departamentType = GetDepartamentTypeById(id);
                if (departamentType == null)
                {
                    return false;
                }
                departamentType.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.departament_types_20ts24tu.Update(departamentType);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DepartamentType GetDepartamentTypeById(int id)
        {
            try
            {
                var departamentType = _context.departament_types_20ts24tu.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

                return departamentType;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateDepartamentType()
        {

            try
            {

                return true;
            }
            catch
            {
                return false;
            }
        }







        //DepartamentTypeTranslation CRUD
        public IEnumerable<DepartamentTypeTranslation> AllDepartamentTypeTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var departamentTypeTranslations = new List<DepartamentTypeTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departamentTypeTranslations = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_type_).Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (queryNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentTypeTranslations = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_type_).Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    departamentTypeTranslations = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_type_).Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null).Take(200).ToList();

                }
                return departamentTypeTranslations;
            }
            catch
            {
                return null;
            }
        }

        public int CreateDepartamentTypeTranslation(DepartamentTypeTranslation departamentTypeTranslation)
        {
            try
            {
                if (departamentTypeTranslation == null)
                {
                    return 0;
                }
                _context.departament_types_translations_20ts24tu.Add(departamentTypeTranslation);
                _context.SaveChanges();

                return departamentTypeTranslation.id;
            }
            catch
            {
                return 0;
            }
        }

        public bool DeleteDepartamentTypeTranslation(int id)
        {
            try
            {
                var departamentTypeTranslation = GetDepartamentTypeTranslationById(id);
                if (departamentTypeTranslation == null)
                {
                    return false;
                }
                departamentTypeTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.departament_types_translations_20ts24tu.Update(departamentTypeTranslation);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DepartamentTypeTranslation GetDepartamentTypeTranslationById(int id)
        {
            try
            {
                var departamentTypeTranslation = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_type_).Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
                return departamentTypeTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateDepartamentTypeTranslation()
        {

            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SaveChanges()
        {
            try { _context.SaveChanges(); return true; } catch { return false; }
        }

        
    }
}
