using Contracts.AllRepository.AppealsToRectorRepository;
using Entities;
using Entities.Model.AppealsToTheRectorsModel;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.AppealsToRectorSqlRepository
{
    public class AppealToRectorSqlRepository : IAppealToRectorRepository
    {
        private readonly RepositoryContext _context;
        public AppealToRectorSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        #region AppealToRector CRUD
        public IEnumerable<AppealToRector> AllAppealToRector(int queryNum, int pageNum)
        {
            try
            {
                var AppealToRectors = new List<AppealToRector>();
                if (queryNum == 0 && pageNum != 0)
                {
                    AppealToRectors = _context.appeals_to_rectors_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.country_)
                        .Include(x => x.territorie_)
                        .Include(x => x.district_)
                        .Include(x => x.neighborhood_)
                        .Include(x => x.gender_)
                        .Include(x => x.employe_)
                        .Include(x => x.file_)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    AppealToRectors = _context.appeals_to_rectors_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.country_)
                        .Include(x => x.territorie_)
                        .Include(x => x.district_)
                        .Include(x => x.neighborhood_)
                        .Include(x => x.gender_)
                        .Include(x => x.employe_)
                        .Include(x => x.file_)
                        .Take(queryNum).ToList();

                }
                else
                {
                    AppealToRectors = _context.appeals_to_rectors_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.country_)
                        .Include(x => x.territorie_)
                        .Include(x => x.district_)
                        .Include(x => x.neighborhood_)
                        .Include(x => x.gender_)
                        .Include(x => x.employe_)
                        .Include(x => x.file_)
                        .Take(200).ToList();

                }
                return AppealToRectors;
            }
            catch
            {
                return null;
            }
        }

        public int CreateAppealToRector(AppealToRector AppealToRector)
        {
            try
            {
                if (AppealToRector == null)
                {
                    return 0;
                }
                _context.appeals_to_rectors_20ts24tu.Add(AppealToRector);
                _context.SaveChanges();
                int id = AppealToRector.id;
                return id;
            }
            catch
            {
                return 0;
            }
        }

        public bool DeleteAppealToRector(int id)
        {
            try
            {
                var AppealToRector = GetAppealToRectorById(id);
                if (AppealToRector == null)
                {
                    return false;
                }
                AppealToRector.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.appeals_to_rectors_20ts24tu.Update(AppealToRector);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public AppealToRector GetAppealToRectorById(int id)
        {
            try
            {
                var AppealToRector = _context.appeals_to_rectors_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.country_)
                        .Include(x => x.territorie_)
                        .Include(x => x.district_)
                        .Include(x => x.neighborhood_)
                        .Include(x => x.gender_)
                        .Include(x => x.employe_)
                        .Include(x => x.file_)
                        .FirstOrDefault(x => x.id.Equals(id));

                return AppealToRector;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateAppealToRector(int id, AppealToRector AppealToRector)
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


        #endregion




        #region AppealToRectorTranslation CRUD
        public IEnumerable<AppealToRectorTranslation> AllAppealToRectorTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var AppealToRectorTranslations = new List<AppealToRectorTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    AppealToRectorTranslations = _context.appeals_to_rectors_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.appeal_to_rector_)
                        .Include(x => x.country_translation_)
                        .Include(x => x.territorie_translation_id)
                        .Include(x => x.district_translation_)
                        .Include(x => x.neighborhood_translation_)
                        .Include(x => x.gender_translation_)
                        .Include(x => x.employe_translation_)
                        .Include(x => x.file_translation_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    AppealToRectorTranslations = _context.appeals_to_rectors_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.appeal_to_rector_)
                        .Include(x => x.country_translation_)
                        .Include(x => x.territorie_translation_id)
                        .Include(x => x.district_translation_)
                        .Include(x => x.neighborhood_translation_)
                        .Include(x => x.gender_translation_)
                        .Include(x => x.employe_translation_)
                        .Include(x => x.file_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    AppealToRectorTranslations = _context.appeals_to_rectors_translations_20ts24tu
                       .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.appeal_to_rector_)
                        .Include(x => x.country_translation_)
                        .Include(x => x.territorie_translation_id)
                        .Include(x => x.district_translation_)
                        .Include(x => x.neighborhood_translation_)
                        .Include(x => x.gender_translation_)
                        .Include(x => x.employe_translation_)
                        .Include(x => x.file_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Take(200).ToList();

                }
                return AppealToRectorTranslations;
            }
            catch
            {
                return null;
            }
        }

        public int CreateAppealToRectorTranslation(AppealToRectorTranslation AppealToRectorTranslation)
        {
            try
            {
                if (AppealToRectorTranslation == null)
                {
                    return 0;
                }
                _context.appeals_to_rectors_translations_20ts24tu.Add(AppealToRectorTranslation);
                _context.SaveChanges();
                int id = AppealToRectorTranslation.id;
                return id;
            }
            catch
            {
                return 0;
            }
        }

        public bool DeleteAppealToRectorTranslation(int id)
        {
            try
            {
                var AppealToRectorTranslation = GetAppealToRectorTranslationById(id);
                if (AppealToRectorTranslation == null)
                {
                    return false;
                }
                AppealToRectorTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.appeals_to_rectors_translations_20ts24tu.Update(AppealToRectorTranslation);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public AppealToRectorTranslation GetAppealToRectorTranslationById(int id)
        {
            try
            {
                var AppealToRectorTranslation = _context.appeals_to_rectors_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.appeal_to_rector_)
                        .Include(x => x.country_translation_)
                        .Include(x => x.territorie_translation_id)
                        .Include(x => x.district_translation_)
                        .Include(x => x.neighborhood_translation_)
                        .Include(x => x.gender_translation_)
                        .Include(x => x.employe_translation_)
                        .Include(x => x.file_translation_).FirstOrDefault(x => x.id.Equals(id));
                return AppealToRectorTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateAppealToRectorTranslation(int id, AppealToRectorTranslation AppealToRectorTranslation)
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
        #endregion



        public bool SaveChanges()
        {
            try { _context.SaveChanges(); return true; } catch { return false; }
        }
    }
}
