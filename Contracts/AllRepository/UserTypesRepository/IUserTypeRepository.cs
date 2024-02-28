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
        public IEnumerable<UserType> AllUserType(int queryNum,int pageNum);
        public UserType GetUserTypeById(int id);
        public bool CreateUserType(UserType userType);
        public bool UpdateUserType();
        public bool DeleteUserType(int id);


        //UserTypeTranslation CRUD
        public IEnumerable<UserTypeTranslation> AllUserTypeTranslation(int queryNum, int pageNum, string language_code);
        public UserTypeTranslation GetUserTypeTranslationById(int id);
        public bool CreateUserTypeTranslation(UserTypeTranslation userTypeTranslation);
        public bool UpdateUserTypeTranslation();
        public bool DeleteUserTypeTranslation(int id);



    }
}
