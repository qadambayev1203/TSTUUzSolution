using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.AppealsToRectorRepository
{
    public interface IAppealToRectorRepository
    {
        //AppealToRector CRUD
        public IEnumerable<AppealToRector> AllAppealToRector(int queryNum, int pageNum);
        public AppealToRector GetAppealToRectorById(int id);
        public int CreateAppealToRector(AppealToRector appealToRector);
        public bool UpdateAppealToRector(int id, AppealToRector appealToRector);
        public bool DeleteAppealToRector(int id);
        public IEnumerable<AppealToRector> GetByAppealStatus(string email);



        //AppealToRectorTranslation CRUD
        public IEnumerable<AppealToRectorTranslation> AllAppealToRectorTranslation(int queryNum, int pageNum, string language_code);
        public AppealToRectorTranslation GetAppealToRectorTranslationById(int id);
        public int CreateAppealToRectorTranslation(AppealToRectorTranslation appealToRectorTranslation);
        public bool UpdateAppealToRectorTranslation(int id, AppealToRectorTranslation appealToRectorTranslation);
        public bool DeleteAppealToRectorTranslation(int id);
        public IEnumerable<AppealToRectorTranslation> GetByAppealStatusTranslation(string email, string language_code);


        public bool SaveChanges();
    }
}
