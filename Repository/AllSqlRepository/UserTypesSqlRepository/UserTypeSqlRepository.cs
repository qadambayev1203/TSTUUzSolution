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
        public IEnumerable<UserType> AllUserType()
        {
            var userTypes = new List<UserType>();
            userTypes = _context.user_types_20ts24tu.Include(x=>x.status_).ToList();
            return userTypes;
        }

        public bool CreateUserType(UserType userType)
        {
            if (userType == null)
            {
                return false;
            }
            _context.user_types_20ts24tu.Add(userType);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteUserType(int id)
        {
            var userType = GetUserTypeById(id);
            if (userType == null)
            {
                return false;
            }
            _context.user_types_20ts24tu.Update(userType);
            _context.SaveChanges();

            return true;
        }

        public UserType GetUserTypeById(int id)
        {
            var userType = _context.user_types_20ts24tu.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
            return userType;
        }

        public bool UpdateUserType(int id, UserType userType)
        {
            var userTypeCheck = GetUserTypeById(id);
            if (userTypeCheck == null)
            {
                return false;
            }
            _context.user_types_20ts24tu.Update(userType);
            _context.SaveChanges();

            return true;
        }






        //UserTypeTranslation CRUD
        public IEnumerable<UserTypeTranslation> AllUserTypeTranslation()
        {
            var userTypesTranslation = new List<UserTypeTranslation>();
            userTypesTranslation = _context.user_types_translations_20ts24tu.Include(x=>x.user_types_).Include(x => x.languages_).Include(x => x.status_translation_).ToList();
            return userTypesTranslation;
        }

        public bool CreateUserTypeTranslation(UserTypeTranslation userTypeTranslation)
        {
            if (userTypeTranslation == null)
            {
                return false;
            }
            _context.user_types_translations_20ts24tu.Add(userTypeTranslation);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteUserTypeTranslation(int id)
        {
            var userTypeTranslation = GetUserTypeTranslationById(id);
            if (userTypeTranslation == null)
            {
                return false;
            }
            _context.user_types_translations_20ts24tu.Update(userTypeTranslation);
            _context.SaveChanges();

            return true;
        }

        public UserTypeTranslation GetUserTypeTranslationById(int id)
        {
            var userTypeTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_).Include(x => x.languages_).Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
            return userTypeTranslation;
        }

        public bool UpdateUserTypeTranslation(int id, UserTypeTranslation userTypeTranslation)
        {
            var userTypeTranslationCheck = GetUserTypeTranslationById(id);
            if (userTypeTranslationCheck == null)
            {
                return false;
            }
            _context.user_types_translations_20ts24tu.Update(userTypeTranslation);
            _context.SaveChanges();

            return true;
        }
    }
}
