﻿using Contracts.AllRepository.AppealsToRectorRepository;
using Entities;
using Entities.Model.AppealsToTheRectorsModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Repository.AllSqlRepository.AppealsToRectorSqlRepository;

public class AppealToRectorSqlRepository : IAppealToRectorRepository
{
    private readonly RepositoryContext _context;
    private readonly ILogger<AppealToRectorSqlRepository> _logger;
    public AppealToRectorSqlRepository(RepositoryContext repositoryContext, ILogger<AppealToRectorSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }



    #region AppealToRector CRUD
    public IEnumerable<AppealToRector> AllAppealToRector(int queryNum, int pageNum, DateTime? start_time, DateTime? end_time)
    {
        try
        {
            if (start_time.HasValue)
            {
                var time = start_time.Value.ToUniversalTime();
                start_time = new DateTime(time.Year, time.Month, time.Day, 0, 0, 0, DateTimeKind.Utc);
            }

            if (end_time.HasValue)
            {
                var time = end_time.Value.ToUniversalTime();
                end_time = new DateTime(time.Year, time.Month, time.Day, 23, 59, 59, DateTimeKind.Utc);
            }


            IQueryable<AppealToRector> AppealToRectors = _context.appeals_to_rectors_20ts24tu
                    .Include(x => x.country_)
                    .Include(x => x.territorie_)
                    .Include(x => x.district_)
                    .Include(x => x.neighborhood_)
                    .Include(x => x.gender_)
                    .Include(x => x.employe_)
                    .Include(x => x.file_);




            if (start_time != null && end_time != null)
            {
                AppealToRectors = AppealToRectors.Where(x => x.created_at >= start_time && x.created_at <= end_time);
            }
            if (queryNum == 0 && pageNum != 0)
            {

                AppealToRectors = AppealToRectors.Skip(10 * (pageNum - 1)).Take(10);

            }

            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                AppealToRectors = AppealToRectors.Skip(queryNum * (pageNum - 1)).Take(queryNum);

            }
            return AppealToRectors.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return Enumerable.Empty<AppealToRector>(); ;
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

            if (AppealToRector.birthday.HasValue)
            {
                if (AppealToRector.birthday.Value.Kind != DateTimeKind.Utc)
                {
                    AppealToRector.birthday = AppealToRector.birthday.Value.ToUniversalTime();
                }
            }

            AppealToRector.created_at = DateTime.UtcNow;


            _context.appeals_to_rectors_20ts24tu.Add(AppealToRector);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(AppealToRector));
            int id = AppealToRector.id;
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return 0;
        }
    }

    public AppealToRector GetAppealToRectorById(int id)
    {
        try
        {
            var AppealToRector = _context.appeals_to_rectors_20ts24tu
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
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public bool UpdateAppealToRector(int id, AppealToRector AppealToRector)
    {

        try
        {
            var AppealToRectorcheck = GetAppealToRectorById(id);
            if (AppealToRectorcheck is null)
            {
                return false;
            }
            AppealToRectorcheck.confirm = AppealToRector.confirm;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(AppealToRector));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return false;
        }
    }
    public IEnumerable<AppealToRector> GetByAppealStatus(string email)
    {
        try
        {
            List<AppealToRector> appealToRectorsStatus = new List<AppealToRector>();
            appealToRectorsStatus = _context.appeals_to_rectors_20ts24tu.Where(x => x.email == email)
                .Select(y => new AppealToRector
                {
                    id = y.id,
                    appeal = y.appeal,
                    confirm = y.confirm
                }).ToList();
            return appealToRectorsStatus;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    #endregion




    #region AppealToRectorTranslation CRUD
    public IEnumerable<AppealToRectorTranslation> AllAppealToRectorTranslation(int queryNum, int pageNum, string language_code, DateTime? start_time, DateTime? end_time)
    {
        try
        {
            if (start_time.HasValue)
            {
                var time = start_time.Value.ToUniversalTime();
                start_time = new DateTime(time.Year, time.Month, time.Day, 0, 0, 0, DateTimeKind.Utc);
            }

            if (end_time.HasValue)
            {
                var time = end_time.Value.ToUniversalTime();
                end_time = new DateTime(time.Year, time.Month, time.Day, 23, 59, 59, DateTimeKind.Utc);
            }

            IQueryable<AppealToRectorTranslation> AppealToRectorTranslations = _context.appeals_to_rectors_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.country_translation_)
                    .Include(x => x.territorie_translation_id)
                    .Include(x => x.district_translation_)
                    .Include(x => x.neighborhood_translation_)
                    .Include(x => x.gender_translation_)
                    .Include(x => x.employe_translation_)
                    .Include(x => x.file_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null);


            if (start_time != null && end_time != null)
            {
                AppealToRectorTranslations = AppealToRectorTranslations.Where(x => x.created_at >= start_time && x.created_at <= end_time);
            }

            if (queryNum == 0 && pageNum != 0)
            {

                AppealToRectorTranslations = AppealToRectorTranslations.Skip(10 * (pageNum - 1))
                    .Take(10);
            }

            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                AppealToRectorTranslations = AppealToRectorTranslations.Skip(queryNum * (pageNum - 1))
                    .Take(queryNum);
            }

            return AppealToRectorTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return Enumerable.Empty<AppealToRectorTranslation>();
        }
    }

    public int CreateAppealToRectorTranslation(AppealToRectorTranslation AppealToRectorTranslation)
    {
        try
        {
            AppealToRectorTranslation.confirm = false;

            if (AppealToRectorTranslation == null)
            {
                return 0;
            }
            if (AppealToRectorTranslation.birthday.HasValue)
            {

                if (AppealToRectorTranslation.birthday.Value.Kind != DateTimeKind.Utc)
                {
                    AppealToRectorTranslation.birthday = AppealToRectorTranslation.birthday.Value.ToUniversalTime();
                }
            }

            AppealToRectorTranslation.created_at = DateTime.UtcNow;

            _context.appeals_to_rectors_translations_20ts24tu.Add(AppealToRectorTranslation);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(AppealToRectorTranslation));
            int id = AppealToRectorTranslation.id;
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return 0;
        }
    }


    public AppealToRectorTranslation GetAppealToRectorTranslationById(int id)
    {
        try
        {
            var AppealToRectorTranslation = _context.appeals_to_rectors_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.country_translation_)
                    .Include(x => x.territorie_translation_id)
                    .Include(x => x.district_translation_)
                    .Include(x => x.neighborhood_translation_)
                    .Include(x => x.gender_translation_)
                    .Include(x => x.employe_translation_)
                    .Include(x => x.file_translation_).FirstOrDefault(x => x.id.Equals(id));
            return AppealToRectorTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public bool UpdateAppealToRectorTranslation(int id, AppealToRectorTranslation AppealToRectorTranslation)
    {

        try
        {
            var AppealToRectorcheck = GetAppealToRectorTranslationById(id);
            if (AppealToRectorcheck is null)
            {
                return false;
            }
            AppealToRectorcheck.confirm = AppealToRectorTranslation.confirm;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(AppealToRectorTranslation));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return false;
        }
    }

    public IEnumerable<AppealToRectorTranslation> GetByAppealStatusTranslation(string email, string language_code)
    {
        try
        {
            List<AppealToRectorTranslation> appealToRectorsStatus = new List<AppealToRectorTranslation>();
            appealToRectorsStatus = _context.appeals_to_rectors_translations_20ts24tu.Where(x => x.email == email)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                .Select(y => new AppealToRectorTranslation
                {
                    id = y.id,
                    appeal = y.appeal,
                    confirm = y.confirm
                }).ToList();
            return appealToRectorsStatus;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }
    #endregion



    public bool SaveChanges()
    {
        try { _context.SaveChanges(); return true; }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message); return false;
        }
    }



}
