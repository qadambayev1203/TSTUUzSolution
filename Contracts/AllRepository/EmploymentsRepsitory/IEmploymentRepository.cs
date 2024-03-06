using Entities.Model.EmploymentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.EmploymentsRepsitory
{
    public interface IEmploymentRepository
    {
        //Employment CRUD
        public IEnumerable<Employment> AllEmployment(int queryNum, int pageNum);
        public Employment GetEmploymentById(int id);
        public int CreateEmployment(Employment employment);
        public bool UpdateEmployment();
        public bool DeleteEmployment(int id);



        //EmploymentTranslation CRUD
        public IEnumerable<EmploymentTranslation> AllEmploymentTranslation(int queryNum, int pageNum, string language_code);
        public EmploymentTranslation GetEmploymentTranslationById(int id);
        public int CreateEmploymentTranslation(EmploymentTranslation employmentTranslation);
        public bool UpdateEmploymentTranslation();
        public bool DeleteEmploymentTranslation(int id);


        public bool SaveChanges();
    }
}
