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
        public bool CreateDepartamentType(DepartamentType departamentType);
        public bool UpdateDepartamentType(int id, DepartamentType departamentType);
        public bool DeleteDepartamentType(int id);



        //DepartamentTypeTranslation CRUD
        public IEnumerable<DepartamentTypeTranslation> AllDepartamentTypeTranslation(int queryNum, int pageNum);
        public DepartamentTypeTranslation GetDepartamentTypeTranslationById(int id);
        public bool CreateDepartamentTypeTranslation(DepartamentTypeTranslation departamentTypeTranslation);
        public bool UpdateDepartamentTypeTranslation(int id, DepartamentTypeTranslation departamentTypeTranslation);
        public bool DeleteDepartamentTypeTranslation(int id);
    }
}
