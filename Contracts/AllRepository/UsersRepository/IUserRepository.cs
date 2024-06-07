using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.UsersRepository
{
    public interface IUserRepository
    {
        //User CRUD
        public IEnumerable<User> AllUser(int queryNum, int pageNum);
        public User GetUserById(int id);
        public int CreateUser(User user);
        public bool UpdateUser(int id, User user);
        public bool SaveChanges();
        public bool DeleteUser(int id);

    }
}
