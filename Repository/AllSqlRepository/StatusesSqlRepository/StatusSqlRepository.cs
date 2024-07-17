using Contracts.AllRepository.StatusesRepository;
using Entities.Model.StatusModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace Repository.AllSqlRepository.StatusesSqlRepository
{
    public class StatusSqlRepository : IStatusRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<StatusSqlRepository> _logger;
        public StatusSqlRepository(RepositoryContext repositoryContext, ILogger<StatusSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }


        //Status CRUD
        public IEnumerable<Status> AllStatusSelect(int queryNum, int pageNum)
        {
            try
            {
                var statuses = new List<Status>();
                if (queryNum == 0 && pageNum != 0)
                {
                    statuses = _context.statuses_20ts24tu.Where(x => x.is_deleted != true).Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    statuses = _context.statuses_20ts24tu.Where(x => x.is_deleted != true).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    statuses = _context.statuses_20ts24tu.Where(x => x.is_deleted != true).ToList();

                }
                return statuses;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }
        public IEnumerable<Status> AllStatus(int queryNum, int pageNum)
        {
            try
            {
                var statuses = new List<Status>();
                if (queryNum == 0 && pageNum != 0)
                {
                    statuses = _context.statuses_20ts24tu.Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    statuses = _context.statuses_20ts24tu.Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    statuses = _context.statuses_20ts24tu.ToList();

                }
                return statuses;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }

        public int CreateStatus(Status status)
        {
            try
            {

                if (status == null)
                {
                    return 0;
                }
                status.is_deleted = false;
                _context.statuses_20ts24tu.Add(status);
                _context.SaveChanges();
                _logger.LogInformation($"Created Status " + JsonConvert.SerializeObject(status));
                return status.id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return 0;
            }
        }

        public bool DeleteStatus(int id)
        {
            try
            {
                var status = GetStatusById(id);
                if (status == null)
                {
                    return false;
                }
                status.is_deleted = true;
                _context.statuses_20ts24tu.Update(status);
                _logger.LogInformation("Deleted Status" + JsonConvert.SerializeObject(status));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return false;
            }
        }

        public Status GetStatusByIdSelect(int id)
        {
            try
            {
                var status = _context.statuses_20ts24tu.Where(x => x.is_deleted != true).FirstOrDefault(x => x.id.Equals(id));
                if (status != null)
                {

                }
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }
        public Status GetStatusById(int id)
        {
            try
            {
                var status = _context.statuses_20ts24tu.FirstOrDefault(x => x.id.Equals(id));
                if (status != null)
                {

                }
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }


        public bool UpdateStatus(int id, Status status)
        {
            try
            {
                var statuscheck = GetStatusById(id);
                if (statuscheck is null)
                {
                    return false;
                }
                statuscheck.status = status.status;
                statuscheck.name = status.name;
                statuscheck.is_deleted = status.is_deleted;
                _logger.LogInformation("Status Updated" + JsonConvert.SerializeObject(statuscheck));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return false;
            }
        }






        //StatusTranslation CRUD
        public IEnumerable<StatusTranslation> AllStatusTranslationSelect(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var statusesTranslation = new List<StatusTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    statusesTranslation = _context.statuses_translations_20ts24tu.Where(x => x.is_deleted != true).Include(x => x.status_)
                        .Include(x => x.language_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    statusesTranslation = _context.statuses_translations_20ts24tu.Where(x => x.is_deleted != true).Include(x => x.status_)
                        .Include(x => x.language_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    statusesTranslation = _context.statuses_translations_20ts24tu.Where(x => x.is_deleted != true).Include(x => x.status_)
                        .Include(x => x.language_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)

                        .ToList();

                }
                return statusesTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }
        public IEnumerable<StatusTranslation> AllStatusTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var statusesTranslation = new List<StatusTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    statusesTranslation = _context.statuses_translations_20ts24tu.Include(x => x.status_)
                        .Include(x => x.language_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    statusesTranslation = _context.statuses_translations_20ts24tu.Include(x => x.status_)
                        .Include(x => x.language_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    statusesTranslation = _context.statuses_translations_20ts24tu.Include(x => x.status_)
                        .Include(x => x.language_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)

                        .ToList();

                }
                return statusesTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }

        public int CreateStatusTranslation(StatusTranslation statusTranslation)
        {
            try
            {
                if (statusTranslation == null)
                {
                    return 0;
                }
                statusTranslation.is_deleted = false;
                _context.statuses_translations_20ts24tu.Add(statusTranslation);
                _context.SaveChanges();
                _logger.LogInformation("Status Created" + JsonConvert.SerializeObject(statusTranslation));

                return statusTranslation.id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return 0;
            }
        }

        public bool DeleteStatusTranslation(int id)
        {
            try
            {
                var statusTranslation = GetStatusTranslationById(id);
                if (statusTranslation == null)
                {
                    return false;
                }
                statusTranslation.is_deleted = true;
                _context.statuses_translations_20ts24tu.Update(statusTranslation);
                _logger.LogInformation("Status Deleted" + JsonConvert.SerializeObject(statusTranslation));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return false;
            }
        }

        public StatusTranslation GetStatusTranslationByIdSelect(int id)
        {
            try
            {
                var status = _context.statuses_translations_20ts24tu.Where(x => x.is_deleted != true).Include(x => x.status_).Include(x => x.language_).FirstOrDefault(x => x.id.Equals(id));
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }
        public StatusTranslation GetStatusTranslationById(int id)
        {
            try
            {
                var status = _context.statuses_translations_20ts24tu.Include(x => x.status_).Include(x => x.language_).FirstOrDefault(x => x.id.Equals(id));
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }
        public StatusTranslation GetStatusTranslationById(int uz_id, string language_code)
        {
            try
            {
                var status = _context.statuses_translations_20ts24tu.Include(x => x.status_).Include(x => x.language_)
                    .FirstOrDefault(x => x.status_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }

        public StatusTranslation GetStatusTranslationByIdSite(int uz_id, string language_code)
        {
            try
            {
                var status = _context.statuses_translations_20ts24tu.Include(x => x.status_).Include(x => x.language_)
                    .Where(x => x.is_deleted != true)
                    .FirstOrDefault(x => x.status_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }

        public bool UpdateStatusTranslation(int id, StatusTranslation status)
        {
            try
            {
                var statuscheck = GetStatusTranslationById(id);
                if (statuscheck is null)
                {
                    return false;
                }
                statuscheck.status = status.status;
                statuscheck.is_deleted = status.is_deleted;
                statuscheck.name = status.name;
                statuscheck.language_id = status.language_id;
                statuscheck.status_id = status.status_id;

                _logger.LogInformation("Status Updated" + JsonConvert.SerializeObject(statuscheck));
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
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return false;
            }
        }
    }
}
