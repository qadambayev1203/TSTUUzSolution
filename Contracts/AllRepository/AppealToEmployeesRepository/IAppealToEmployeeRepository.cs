

using Entities.DTO.UserCrudDTOS;
using Entities.Model.AppealToEmployeeModel;

namespace Contracts.AllRepository.AppealToEmployeesRepository
{
    public interface IAppealToEmployeeRepository
    {
        //AppealToEmployee CRUD
        public IEnumerable<AppealToEmployee> AllAppealToEmployee(int queryNum, int pageNum);
        public AppealToEmployee GetAppealToEmployeeById(int id);

        public IEnumerable<AppealToEmployee> AllAppealToEmployeeAdmin(int queryNum, int pageNum);
        public AppealToEmployee GetAppealToEmployeeByIdAdmin(int id);

        public int CreateAppealToEmployee(AppealToEmployee appealToEmployee, int person_id);
        public bool UpdateAppealToEmployee(int id, AppealToEmployee appealToEmployee);
        public bool DeleteAppealToEmployee(int id);



        //AppealToEmployeeTranslation CRUD
        public IEnumerable<AppealToEmployeeTranslation> AllAppealToEmployeeTranslation(int queryNum, int pageNum, string language_code);
        public AppealToEmployeeTranslation GetAppealToEmployeeTranslationById(int id);

        public IEnumerable<AppealToEmployeeTranslation> AllAppealToEmployeeTranslationAdmin(int queryNum, int pageNum, string language_code);
        public AppealToEmployeeTranslation GetAppealToEmployeeTranslationByIdAdmin(int id);

        public int CreateAppealToEmployeeTranslation(AppealToEmployeeTranslation appealToEmployeeTranslation, int person_id);
        public bool UpdateAppealToEmployeeTranslation(int id, AppealToEmployeeTranslation appealToEmployeeTranslation);
        public bool DeleteAppealToEmployeeTranslation(int id);


        public bool SaveChanges();
    }
}
