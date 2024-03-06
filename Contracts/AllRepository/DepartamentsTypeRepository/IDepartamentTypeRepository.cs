using Entities.Model.DepartamentsTypeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.DepartamentsTypeRepository
{
    public interface IDepartamentTypeRepository
    {
        //DepartamentType CRUD
        public IEnumerable<DepartamentType> AllDepartamentType(int queryNum, int pageNum);
        public DepartamentType GetDepartamentTypeById(int id);
        public int CreateDepartamentType(DepartamentType departamentType);
        public bool UpdateDepartamentType();
        public bool DeleteDepartamentType(int id);



        //DepartamentTypeTranslation CRUD
        public IEnumerable<DepartamentTypeTranslation> AllDepartamentTypeTranslation(int queryNum, int pageNum, string language_code);
        public DepartamentTypeTranslation GetDepartamentTypeTranslationById(int id);
        public int CreateDepartamentTypeTranslation(DepartamentTypeTranslation departamentTypeTranslation);
        public bool UpdateDepartamentTypeTranslation();
        public bool DeleteDepartamentTypeTranslation(int id);

        public bool SaveChanges();

    }
}
