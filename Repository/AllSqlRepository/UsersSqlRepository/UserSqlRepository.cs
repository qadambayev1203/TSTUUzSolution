using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.AllRepository.UsersRepository;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Entities.Model.PersonModel;

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
            try
            {
                var users = new List<User>();
                users = _context.users_20ts24tu.Include(x => x.user_type_).Include(x => x.person_).Include(x => x.status_).ToList();
                return users;
            }
            catch 
            {
                return null;
            }
        }

        public bool CreateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return false;
                }
                user.created_at = DateTime.UtcNow;
                _context.users_20ts24tu.Add(user);
                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                var user = GetUserById(id);
                if (user == null)
                {
                    return false;
                }
                user.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.users_20ts24tu.Update(user);
                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                var user = _context.users_20ts24tu.Include(x => x.user_type_).Include(x => x.person_).Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
                return user;
            }
            catch 
            {
                return null;
            }
        }

        public bool UpdateUser()
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
