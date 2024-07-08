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
        public IEnumerable<Departament> AllDepartamentSite(int queryNum, int pageNum);
        public IEnumerable<Departament> AllDepartamentChild(int parent_id);
        public IEnumerable<Departament> AllDepartamentFacultyDirection(int faculty_id);
        public IEnumerable<Departament> AllDepartamentType(string dep_type, int queryNum, int pageNum);
        public IEnumerable<Departament> AllDepartamentTypeSite(string dep_type, int queryNum, int pageNum, bool? favorite);
        public IEnumerable<Departament> SelectDepartaments();
        public Departament GetDepartamentById(int id);
        public Departament GetDepartamentByIdSite(int id);
        public int CreateDepartament(Departament departament);
        public bool UpdateDepartament(int id, Departament departament);
        public bool DeleteDepartament(int id);



        //DepartamentTranslation CRUD
        public IEnumerable<DepartamentTranslation> AllDepartamentTranslation(int queryNum, int pageNum, string language_code);
        public IEnumerable<DepartamentTranslation> SelectDepartamentsTranslation(string language_code);
        public IEnumerable<DepartamentTranslation> AllDepartamentTranslationSite(int queryNum, int pageNum, string language_code);
        public IEnumerable<DepartamentTranslation> AllDepartamentTranslationChild(int parent_id, string language_code);
        public IEnumerable<DepartamentTranslation> AllDepartamentTranslationFacultyDirection(int faculty_id, string language_code);
        public IEnumerable<DepartamentTranslation> AllDepartamentTranslationType(string dep_type, string language_code, int queryNum, int pageNum);
        public IEnumerable<DepartamentTranslation> AllDepartamentTranslationTypeSite(string dep_type, string language_code, int queryNum, int pageNum, bool? favorite);
        public DepartamentTranslation GetDepartamentTranslationById(int id);
        public DepartamentTranslation GetDepartamentTranslationById(int uz_id, string language_code);
        public DepartamentTranslation GetDepartamentTranslationByIdSite(int uz_id, string language_code);
        public DepartamentTranslation GetDepartamentTranslationByIdSite(int id);
        public int CreateDepartamentTranslation(DepartamentTranslation departamentTranslation);
        public bool UpdateDepartamentTranslation(int id, DepartamentTranslation departament);
        public bool DeleteDepartamentTranslation(int id);
        public bool SaveChanges();

    }
}
