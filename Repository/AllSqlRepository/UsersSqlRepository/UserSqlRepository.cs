using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.AllRepository.UsersRepository;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.UsersSqlRepository
{
    public class UserSqlRepository : IUserRepository
    {
        private readonly RepositoryContext _context;
        public UserSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }


        public IEnumerable<User> AllUser()
        {
            var users = new List<User>();
            users = _context.users_20ts24tu.Include(x=>x.user_type_).Include(x=>x.person_).Include(x=>x.status_).ToList();
            return users;
        }

        public bool CreateUser(User user)
        {
            if (user == null)
            {
                return false;
            }
            _context.users_20ts24tu.Add(user);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user == null)
            {
                return false;
            }
            _context.users_20ts24tu.Update(user);
            _context.SaveChanges();

            return true;
        }

        public User GetUserById(int id)
        {
            var user = _context.users_20ts24tu.Include(x => x.user_type_).Include(x => x.person_).Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
            return user;
        }

        public bool UpdateUser(int id, User user)
        {
            var userCheck = GetUserById(id);
            if (userCheck == null)
            {
                return false;
            }
            _context.users_20ts24tu.Update(user);
            _context.SaveChanges();

            return true;
        }
    }
}
