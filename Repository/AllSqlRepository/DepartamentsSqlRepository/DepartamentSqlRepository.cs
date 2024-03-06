using Contracts.AllRepository.DepartamentsRepository;
using Entities.Model.DepartamentsModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.DepartamentsSqlRepository
{
    public class DepartamentSqlRepository : IDepartamentRepository
    {
        private readonly RepositoryContext _context;
        public DepartamentSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        //Departament CRUD
        public IEnumerable<Departament> AllDepartament(int queryNum, int pageNum)
        {
            try
            {
                var departaments = new List<Departament>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departaments = _context.departament_20ts24tu.Include(x => x.img_).Include(x => x.departament_type_).Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departaments = _context.departament_20ts24tu.Include(x => x.img_).Include(x => x.departament_type_).Include(x => x.status_).Take(queryNum).ToList();

                }
                else
                {
                    departaments = _context.departament_20ts24tu.Include(x => x.img_).Include(x => x.departament_type_).Include(x => x.status_).Take(200).ToList();

                }
                return departaments;
            }
            catch
            {
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

                return departament.id;
            }
            catch
            {
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

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Departament GetDepartamentById(int id)
        {
            try
            {
                var departament = _context.departament_20ts24tu.Include(x => x.img_).Include(x => x.departament_type_).Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

                return departament;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateDepartament()
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
                        .Include(x => x.img_)
                        .Include(x => x.departament_translation_type_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (queryNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentTranslations = _context.departament_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.img_)
                        .Include(x => x.departament_translation_type_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    departamentTranslations = _context.departament_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.img_)
                        .Include(x => x.departament_translation_type_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Take(200).ToList();

                }
                return departamentTranslations;
            }
            catch
            {
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

                return departamentTranslation.id;
            }
            catch
            {
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
                departamentTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.departament_translations_20ts24tu.Update(departamentTranslation);

                return true;
            }
            catch
            {
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
                        .Include(x => x.img_)
                        .Include(x => x.departament_translation_type_).FirstOrDefault(x => x.id.Equals(id));
                return departamentTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateDepartamentTranslation()
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
