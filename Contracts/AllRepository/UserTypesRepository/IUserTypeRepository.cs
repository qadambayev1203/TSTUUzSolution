using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.UserTypesRepository
{
    public interface IUserTypeRepository
    {
        //UserType CRUD
        public IEnumerable<UserType> AllUserType();
        public UserType GetUserTypeById(int id);
        public bool CreateUserType(UserType userType);
        public bool UpdateUserType(int id, UserType userType);
        public bool DeleteUserType(int id);


        //UserTypeTranslation CRUD
        public IEnumerable<UserTypeTranslation> AllUserTypeTranslation();
        public UserTypeTranslation GetUserTypeTranslationById(int id);
        public bool CreateUserTypeTranslation(UserTypeTranslation userTypeTranslation);
        public bool UpdateUserTypeTranslation(int id, UserTypeTranslation userTypeTranslation);
        public bool DeleteUserTypeTranslation(int id);



    }
}
