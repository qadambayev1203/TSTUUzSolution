using Entities.Model.DepartamentDetailsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.DepartamentDetailsRepository
{
    public interface IDepartamentDetailRepository
    {
        //departamentDetail CRUD
        public IEnumerable<DepartamentDetail> AllDepartamentDetail(int queryNum, int pageNum);
        public DepartamentDetail GetDepartamentDetailById(int id);
        public int CreateDepartamentDetail(DepartamentDetail departamentDetail);
        public bool UpdateDepartamentDetail();
        public bool DeleteDepartamentDetail(int id);



        //departamentDetailTranslation CRUD
        public IEnumerable<DepartamentDetailTranslation> AllDepartamentDetailTranslation(int queryNum, int pageNum, string language_code);
        public DepartamentDetailTranslation GetDepartamentDetailTranslationById(int id);
        public int CreateDepartamentDetailTranslation(DepartamentDetailTranslation departamentDetailTranslation);
        public bool UpdateDepartamentDetailTranslation();
        public bool DeleteDepartamentDetailTranslation(int id);
        public bool SaveChanges();

    }
}
