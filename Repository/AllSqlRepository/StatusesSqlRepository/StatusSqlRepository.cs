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
        public IEnumerable<Status> AllStatus()
        {
            var statuses = new List<Status>();
            statuses = _context.statuses_20ts24tu.ToList();
            return statuses;
        }

        public bool CreateStatus(Status status)
        {
            if (status == null)
            {
                return false;
            }
            _context.statuses_20ts24tu.Add(status);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteStatus(int id)
        {
            var status = GetStatusById(id);
            if (status == null)
            {
                return false;
            }
            status.is_deleted = false;
            _context.statuses_20ts24tu.Update(status);
            _context.SaveChanges();

            return true;
        }

        public Status GetStatusById(int id)
        {
            var status = _context.statuses_20ts24tu.FirstOrDefault(x => x.id.Equals(id));
            return status;
        }

        public bool UpdateStatus(int id, Status status)
        {
            var statusCheck = GetStatusById(id);
            if (statusCheck == null)
            {
                return false;
            }
            statusCheck=status;
            _context.statuses_20ts24tu.Update(statusCheck);
            _context.SaveChanges();
            return true;
        }






        //StatusTranslation CRUD
        public IEnumerable<StatusTranslation> AllStatusTranslation()
        {
            var statusesTranslation = new List<StatusTranslation>();
            statusesTranslation = _context.statuses_translations_20ts24tu.Include(x=>x.status_).Include(x => x.languages_).ToList();
            return statusesTranslation;
        }

        public bool CreateStatusTranslation(StatusTranslation statusTranslation)
        {
            if (statusTranslation == null)
            {
                return false;
            }
            _context.statuses_translations_20ts24tu.Add(statusTranslation);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteStatusTranslation(int id)
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

        public StatusTranslation GetStatusTranslationById(int id)
        {
            var status = _context.statuses_translations_20ts24tu.Include(x => x.status_).Include(x => x.languages_).FirstOrDefault(x => x.id.Equals(id));
            return status;
        }

        public bool UpdateStatusTranslation(int id, StatusTranslation statusTranslation)
        {
            var statusTranslationCheck = GetStatusTranslationById(id);
            if (statusTranslationCheck == null)
            {
                return false;
            }
            _context.statuses_translations_20ts24tu.Update(statusTranslation);
            _context.SaveChanges();

            return true;
        }
    }
}
