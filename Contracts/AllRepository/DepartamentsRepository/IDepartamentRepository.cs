using Entities.Model.DepartamentsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.DepartamentsRepository
{
    public interface IDepartamentRepository
    {
        //Departament CRUD
        public IEnumerable<Departament> AllDepartament(int queryNum, int pageNum);
        public Departament GetDepartamentById(int id);
        public bool CreateDepartament(Departament departament);
        public bool UpdateDepartament(int id, Departament departament);
        public bool DeleteDepartament(int id);



        //DepartamentTranslation CRUD
        public IEnumerable<DepartamentTranslation> AllDepartamentTranslation(int queryNum, int pageNum);
        public DepartamentTranslation GetDepartamentTranslationById(int id);
        public bool CreateDepartamentTranslation(DepartamentTranslation departamentTranslation);
        public bool UpdateDepartamentTranslation(int id, DepartamentTranslation departamentTranslation);
        public bool DeleteDepartamentTranslation(int id);
    }
}
