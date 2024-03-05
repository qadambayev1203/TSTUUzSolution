using Contracts.AllRepository.EmploymentsRepsitory;
using Entities.Model.EmploymentModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.EmploymentsSqlRepository
{
    public class EmploymentSqlRepository : IEmploymentRepsitory
    {
        private readonly RepositoryContext _context;
        public EmploymentSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        #region Employment CRUD
        public IEnumerable<Employment> AllEmployment(int queryNum, int pageNum)
        {
            try
            {
                var Employments = new List<Employment>();
                if (queryNum == 0 && pageNum != 0)
                {
                    Employments = _context.employments_20ts24tu
                        
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    Employments = _context.employments_20ts24tu
                        .Take(queryNum).ToList();

                }
                else
                {
                    Employments = _context.employments_20ts24tu
                       .Take(200).ToList();

                }
                return Employments;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateEmployment(Employment Employment)
        {
            try
            {
                if (Employment == null)
                {
                    return false;
                }
                _context.employments_20ts24tu.Add(Employment);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteEmployment(int id)
        {
            return true;
        }

        public Employment GetEmploymentById(int id)
        {
            try
            {
                var Employment = _context.employments_20ts24tu
                        .FirstOrDefault(x => x.id.Equals(id));

                return Employment;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateEmployment(int id, Employment Employment)
        {

            try
            {
                var dep = GetEmploymentById(id);
                if (dep == null)
                {
                    return false;
                }
                Employment.id = dep.id;
                _context.employments_20ts24tu.Update(Employment);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion




        #region EmploymentTranslation CRUD
        public IEnumerable<EmploymentTranslation> AllEmploymentTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var EmploymentTranslations = new List<EmploymentTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    EmploymentTranslations = _context.employments_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.employment_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    EmploymentTranslations = _context.employments_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.employment_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    EmploymentTranslations = _context.employments_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.employment_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Take(200).ToList();

                }
                return EmploymentTranslations;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateEmploymentTranslation(EmploymentTranslation EmploymentTranslation)
        {
            try
            {
                if (EmploymentTranslation == null)
                {
                    return false;
                }
                _context.employments_translations_20ts24tu.Add(EmploymentTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteEmploymentTranslation(int id)
        {
                return true;
        }

        public EmploymentTranslation GetEmploymentTranslationById(int id)
        {
            try
            {
                var EmploymentTranslation = _context.employments_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.employment_).FirstOrDefault(x => x.id.Equals(id));
                return EmploymentTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateEmploymentTranslation(int id, EmploymentTranslation EmploymentTranslation)
        {

            try
            {
                var deptr = GetEmploymentById(id);
                if (deptr == null)
                {
                    return false;
                }
                EmploymentTranslation.id = deptr.id;
                _context.employments_translations_20ts24tu.Update(EmploymentTranslation);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
