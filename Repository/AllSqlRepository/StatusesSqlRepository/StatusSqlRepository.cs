using Contracts.AllRepository.StatusesRepository;
using Entities.Model.StatusModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.StatusesSqlRepository
{
    public class StatusSqlRepository : IStatusRepository
    {
        private readonly RepositoryContext _context;
        public StatusSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }


        //Status CRUD
        public IEnumerable<Status> AllStatus(int queryNum,int pageNum)
        {
            try
            {
                var statuses = new List<Status>();
                if (queryNum == 0 && pageNum != 0)
                {
                    statuses = _context.statuses_20ts24tu.Skip(10*(pageNum-1)).Take(10).ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    statuses = _context.statuses_20ts24tu.Take(queryNum).ToList();

                }
                else
                {
                    statuses = _context.statuses_20ts24tu.Take(200).ToList();

                }
                return statuses;

            }
            catch
            {
                return null;
            }
        }

        public bool CreateStatus(Status status)
        {
            try
            {
                if (status == null)
                {
                    return false;
                }
                _context.statuses_20ts24tu.Add(status);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
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
                _context.SaveChanges();

                return true;
            }
            catch
            {

                return false;
            }
        }

        public Status GetStatusById(int id)
        {
            try
            {
                var status = _context.statuses_20ts24tu.FirstOrDefault(x => x.id.Equals(id));
                return status;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateStatus()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }






        //StatusTranslation CRUD
        public IEnumerable<StatusTranslation> AllStatusTranslation(int queryNum, int pageNum)
        {
            try
            {
                var statusesTranslation = new List<StatusTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    statusesTranslation = _context.statuses_translations_20ts24tu.Include(x => x.status_)
                        .Include(x => x.language_)
                        .Skip(10*(pageNum-1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    statusesTranslation = _context.statuses_translations_20ts24tu.Include(x => x.status_)
                        .Include(x => x.language_)
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    statusesTranslation = _context.statuses_translations_20ts24tu.Include(x => x.status_)
                        .Include(x => x.language_)
                        .Take(200)
                        .ToList();

                }
                return statusesTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateStatusTranslation(StatusTranslation statusTranslation)
        {
            try
            {
                if (statusTranslation == null)
                {
                    return false;
                }
                _context.statuses_translations_20ts24tu.Add(statusTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
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
                _context.statuses_translations_20ts24tu.Update(statusTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public StatusTranslation GetStatusTranslationById(int id)
        {
            try
            {
                var status = _context.statuses_translations_20ts24tu.Include(x => x.status_).Include(x => x.language_).FirstOrDefault(x => x.id.Equals(id));
                return status;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateStatusTranslation()
        {
            try
            {
                
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
