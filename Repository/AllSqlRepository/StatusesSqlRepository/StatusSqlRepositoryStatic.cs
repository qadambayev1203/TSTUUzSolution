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
    public class StatusSqlRepositoryStatic : IStatusRepositoryStatic
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<StatusSqlRepository> _logger;
        public StatusSqlRepositoryStatic(RepositoryContext repositoryContext, ILogger<StatusSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }

        public int GetStatusId(string status)
        {
            try
            {
                int id = _context.statuses_20ts24tu.Where(x => x.is_deleted != true).FirstOrDefault(x => x.status.Equals(status)).id;
                if (id == 0)
                {
                    Status st = new Status() { status = "Active", name = "Faol", is_deleted = false };
                    try
                    {
                        _context.statuses_20ts24tu.Add(st);
                        return st.id;
                    }
                    catch
                    {
                        return 0;
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return 0;
            }
        }

        public int GetStatusTranslationId(string status, int language_id)
        {
            try
            {
                int id = _context.statuses_translations_20ts24tu.Where(x => x.is_deleted != true).FirstOrDefault(x => x.status.Equals(status) && x.language_.id.Equals(language_id)).id;
                if (id == 0)
                {
                    StatusTranslation st = new StatusTranslation() { status = "Active", status_id = 1, name = "Active", language_id = 1, is_deleted = false };
                    try
                    {
                        _context.statuses_translations_20ts24tu.Add(st);
                        return st.id;
                    }
                    catch
                    {
                        return 0;
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return 0;
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
                _logger.LogError($"Error" + ex.ToString());
                return false;
            }
        }
    }
}
