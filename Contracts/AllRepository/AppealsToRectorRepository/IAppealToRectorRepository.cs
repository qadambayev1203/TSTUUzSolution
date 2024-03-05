using Entities.Model.AppealsToTheRectorsModel;
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
        public bool CreateAppealToRector(AppealToRector appealToRector);
        public bool UpdateAppealToRector(int id, AppealToRector appealToRector);
        public bool DeleteAppealToRector(int id);



        //AppealToRectorTranslation CRUD
        public IEnumerable<AppealToRectorTranslation> AllAppealToRectorTranslation(int queryNum, int pageNum, string language_code);
        public AppealToRectorTranslation GetAppealToRectorTranslationById(int id);
        public bool CreateAppealToRectorTranslation(AppealToRectorTranslation appealToRectorTranslation);
        public bool UpdateAppealToRectorTranslation(int id, AppealToRectorTranslation appealToRectorTranslation);
        public bool DeleteAppealToRectorTranslation(int id);
    }
}
