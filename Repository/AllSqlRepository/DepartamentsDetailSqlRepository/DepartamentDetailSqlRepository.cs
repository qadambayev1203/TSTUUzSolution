using Entities.Model.DepartamentDetailsModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contracts.AllRepository.DepartamentDetailsRepository;

namespace Repository.AllSqlRepository.DepartamentsDetailSqlRepository
{
    public class DepartamentDetailSqlRepository : IDepartamentDetailRepository
    {
        private readonly RepositoryContext _context;
        public DepartamentDetailSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        //DepartamentDetail CRUD
        public IEnumerable<DepartamentDetail> AllDepartamentDetail(int queryNum, int pageNum)
        {
            try
            {
                var departamentDetails = new List<DepartamentDetail>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departamentDetails = _context.departament_details_20ts24tu
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.status_)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentDetails = _context.departament_details_20ts24tu
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    departamentDetails = _context.departament_details_20ts24tu
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.status_).ToList();

                }
                return departamentDetails;
            }
            catch
            {
                return null;
            }
        }

        public int CreateDepartamentDetail(DepartamentDetail departamentDetail)
        {
            try
            {
                if (departamentDetail == null)
                {
                    return 0;
                }
                _context.departament_details_20ts24tu.Add(departamentDetail);
                _context.SaveChanges();

                return departamentDetail.id;
            }
            catch
            {
                return 0;
            }
        }

        public bool DeleteDepartamentDetail(int id)
        {
            try
            {
                var departamentDetail = GetDepartamentDetailById(id);
                if (departamentDetail == null)
                {
                    return false;
                }
                departamentDetail.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.departament_details_20ts24tu.Update(departamentDetail);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DepartamentDetail GetDepartamentDetailById(int id)
        {
            try
            {
                var departamentDetail = _context.departament_details_20ts24tu
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

                return departamentDetail;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateDepartamentDetail()
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







        //DepartamentDetailTranslation CRUD
        public IEnumerable<DepartamentDetailTranslation> AllDepartamentDetailTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var departamentDetailTranslations = new List<DepartamentDetailTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departamentDetailTranslations = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_translation_type_)
                        .Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (queryNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentDetailTranslations = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_translation_type_).Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (queryNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    departamentDetailTranslations = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_translation_type_).Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null).ToList();

                }
                return departamentDetailTranslations;
            }
            catch
            {
                return null;
            }
        }

        public int CreateDepartamentDetailTranslation(DepartamentDetailTranslation departamentDetailTranslation)
        {
            try
            {
                if (departamentDetailTranslation == null)
                {
                    return 0;
                }
                _context.departament_details_translations_20ts24tu.Add(departamentDetailTranslation);
                _context.SaveChanges();

                return departamentDetailTranslation.id;
            }
            catch
            {
                return 0;
            }
        }

        public bool DeleteDepartamentDetailTranslation(int id)
        {
            try
            {
                var departamentDetailTranslation = GetDepartamentDetailTranslationById(id);
                if (departamentDetailTranslation == null)
                {
                    return false;
                }
                departamentDetailTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.departament_details_translations_20ts24tu.Update(departamentDetailTranslation);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DepartamentDetailTranslation GetDepartamentDetailTranslationById(int id)
        {
            try
            {
                var departamentDetailTranslation = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_translation_type_).Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
                return departamentDetailTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateDepartamentDetailTranslation()
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
