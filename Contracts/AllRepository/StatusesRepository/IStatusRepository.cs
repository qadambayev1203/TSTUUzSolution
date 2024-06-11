using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.StatusesRepository
{
    public interface IStatusRepository
    {
        //Status CRUD
        public IEnumerable<Status> AllStatus(int queryNum, int pageNum);
        public IEnumerable<Status> AllStatusSelect(int queryNum, int pageNum);
        public Status GetStatusById(int id);
        public Status GetStatusByIdSelect(int id);
        public int CreateStatus(Status status);
        public bool UpdateStatus(int id, Status status);
        public bool DeleteStatus(int id);



        //StatusTranslation CRUD
        public IEnumerable<StatusTranslation> AllStatusTranslation(int queryNum, int pageNum, string language_code);
        public IEnumerable<StatusTranslation> AllStatusTranslationSelect(int queryNum, int pageNum, string language_code);
        public StatusTranslation GetStatusTranslationById(int id);
        public StatusTranslation GetStatusTranslationById(int uz_id, string language_code);
        public StatusTranslation GetStatusTranslationByIdSite(int uz_id, string language_code);
        public StatusTranslation GetStatusTranslationByIdSelect(int id);
        public int CreateStatusTranslation(StatusTranslation statusTranslation);
        public bool UpdateStatusTranslation(int id, StatusTranslation status);
        public bool DeleteStatusTranslation(int id);
        public bool SaveChanges();

    }
}
