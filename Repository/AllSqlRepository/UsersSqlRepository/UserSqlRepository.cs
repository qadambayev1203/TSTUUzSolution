using Entities;
using Contracts.AllRepository.UsersRepository;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.UsersSqlRepository;

public class UserSqlRepository : IUserRepository
{

    private readonly RepositoryContext _context;
    private readonly ILogger<UserSqlRepository> _logger;
    public UserSqlRepository(RepositoryContext repositoryContext, ILogger<UserSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }


    public IEnumerable<User> AllUser(int queryNum, int pageNum)
    {
        try
        {
            var users = new List<User>();
            if (queryNum == 0 && pageNum != 0)
            {
                users = _context.users_20ts24tu.Include(x => x.user_type_)
                    .Include(x => x.person_).ThenInclude(y => y.img_)
                    .Include(x => x.person_).ThenInclude(y => y.departament_).ThenInclude(y=>y.departament_type_)
                    .Include(x => x.person_).ThenInclude(y => y.gender_)
                    .Include(x => x.person_).ThenInclude(y => y.employee_type_)
                    .Include(x => x.status_)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                users = _context.users_20ts24tu.Include(x => x.user_type_)
                    .Include(x => x.person_).ThenInclude(y => y.img_)
                    .Include(x => x.person_).ThenInclude(y => y.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.person_).ThenInclude(y => y.gender_)
                    .Include(x => x.person_).ThenInclude(y => y.employee_type_)
                    .Include(x => x.status_)
                     .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();

            }
            else
            {
                users = _context.users_20ts24tu.Include(x => x.user_type_)
                    .Include(x => x.person_).ThenInclude(y => y.img_)
                    .Include(x => x.person_).ThenInclude(y => y.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.person_).ThenInclude(y => y.gender_)
                    .Include(x => x.person_).ThenInclude(y => y.employee_type_)
                    .Include(x => x.status_)
                    .ToList();

            }
            return users;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateUser(User user)
    {
        try
        {
            if (user == null)
            {
                return 0;
            }
            user.created_at = DateTime.UtcNow;
            user.removed = false;
            user.active = true;
            _context.users_20ts24tu.Add(user);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(user));

            return user.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
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
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(user));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public User GetUserById(int id)
    {
        try
        {
            var user = _context.users_20ts24tu.Include(x => x.user_type_)
                    .Include(x => x.person_).ThenInclude(y => y.img_)
                    .Include(x => x.person_).ThenInclude(y => y.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.person_).ThenInclude(y => y.gender_)
                    .Include(x => x.person_).ThenInclude(y => y.employee_type_)
                    .Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool SaveChanges()
    {
        try
        {
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public bool UpdateUser(int id, User user)
    {

        try
        {
            var dbcheck = GetUserById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.login = user.login;
            dbcheck.password = user.password;
            dbcheck.email = user.email;
            dbcheck.user_type_id = user.user_type_id;
            dbcheck.person_id = user.person_id;
            dbcheck.status_id = user.status_id;
            dbcheck.removed = user.removed;
            dbcheck.active = user.active;
            dbcheck.updated_at = DateTime.UtcNow;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }
}
