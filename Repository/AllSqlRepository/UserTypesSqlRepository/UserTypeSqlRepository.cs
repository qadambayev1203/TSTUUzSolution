using Contracts.AllRepository.UserTypesRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.UserTypesSqlRepository
{
    public class UserTypeSqlRepository : IUserTypeRepository
    {
        private readonly RepositoryContext _context;
        public UserTypeSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }


        //UserType CRUD
        public IEnumerable<UserType> AllUserType(int queryNum,int pageNum)
        {
            try
            {
                var userTypes = new List<UserType>();
                if (queryNum == 0 && pageNum != 0)
                {
                    userTypes = _context.user_types_20ts24tu.Include(x => x.status_).Skip(10*(pageNum-1)).Take(10).ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    userTypes = _context.user_types_20ts24tu.Include(x => x.status_).Take(queryNum).ToList();

                }
                else
                {
                    userTypes = _context.user_types_20ts24tu.Include(x => x.status_).Take(200).ToList();

                }
                return userTypes;
            }
            catch 
            {
                return null;
            }
        }

        public bool CreateUserType(UserType userType)
        {
            try
            {
                if (userType == null)
                {
                    return false;
                }
                _context.user_types_20ts24tu.Add(userType);
                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeleteUserType(int id)
        {
            try
            {
                var userType = GetUserTypeById(id);
                if (userType == null)
                {
                    return false;
                }
                userType.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.user_types_20ts24tu.Update(userType);
                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public UserType GetUserTypeById(int id)
        {
            try
            {
                var userType = _context.user_types_20ts24tu.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
                return userType;
            }
            catch 
            {
                return null;
            }
        }

        public bool UpdateUserType()
        {
            try
            {

                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }






        //UserTypeTranslation CRUD
        public IEnumerable<UserTypeTranslation> AllUserTypeTranslation(int queryNum,int pageNum, string language_code)
        {
            try
            {
                var userTypesTranslation = new List<UserTypeTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    userTypesTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_)
                        .Include(x => x.language_).Include(x => x.status_translation_)
                        .Where(x => x.language_.code.Equals(language_code))
                        .Skip(10*(queryNum-1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    userTypesTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_)
                        .Include(x => x.language_).Include(x => x.status_translation_).Where(x => x.language_.code.Equals(language_code))
                        .Take(queryNum).ToList();

                }
                else
                {
                    userTypesTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_)
                        .Include(x => x.language_).Include(x => x.status_translation_).Where(x => x.language_.code.Equals(language_code))
                        .Take(200).ToList();

                }
                return userTypesTranslation;
            }
            catch 
            {
                return null;
            }
        }

        public bool CreateUserTypeTranslation(UserTypeTranslation userTypeTranslation)
        {
            try
            {
                if (userTypeTranslation == null)
                {
                    return false;
                }
                _context.user_types_translations_20ts24tu.Add(userTypeTranslation);
                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeleteUserTypeTranslation(int id)
        {
            try
            {
                var userTypeTranslation = GetUserTypeTranslationById(id);
                if (userTypeTranslation == null)
                {
                    return false;
                }
                userTypeTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.user_types_translations_20ts24tu.Update(userTypeTranslation);
                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public UserTypeTranslation GetUserTypeTranslationById(int id)
        {
            try
            {
                var userTypeTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_).Include(x => x.language_).Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
                return userTypeTranslation;
            }
            catch 
            {
                return null;
            }
        }

        public bool UpdateUserTypeTranslation()
        {
            try
            {

                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
