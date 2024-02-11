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
        public IEnumerable<Status> AllStatus();
        public Status GetStatusById(int id);
        public bool CreateStatus(Status status);
        public bool UpdateStatus();
        public bool DeleteStatus(int id);



        //StatusTranslation CRUD
        public IEnumerable<StatusTranslation> AllStatusTranslation();
        public StatusTranslation GetStatusTranslationById(int id);
        public bool CreateStatusTranslation(StatusTranslation statusTranslation);
        public bool UpdateStatusTranslation();
        public bool DeleteStatusTranslation(int id);
    }
}
