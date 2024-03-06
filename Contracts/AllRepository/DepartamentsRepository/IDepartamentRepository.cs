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
        public int CreateDepartament(Departament departament);
        public bool UpdateDepartament();
        public bool DeleteDepartament(int id);



        //DepartamentTranslation CRUD
        public IEnumerable<DepartamentTranslation> AllDepartamentTranslation(int queryNum, int pageNum, string language_code);
        public DepartamentTranslation GetDepartamentTranslationById(int id);
        public int CreateDepartamentTranslation(DepartamentTranslation departamentTranslation);
        public bool UpdateDepartamentTranslation();
        public bool DeleteDepartamentTranslation(int id);
        public bool SaveChanges();

    }
}
