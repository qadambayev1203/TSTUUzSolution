using Contracts.AllRepository.ProfilsRepository;
using Entities;
using Entities.Model;
using Entities.Model.AnyClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.ProfilsSqlRepopsitory;

public class ProfilSqlRepository : IProfilRepository
{

    private readonly RepositoryContext _context;
    private readonly ILogger<ProfilSqlRepository> _logger;
    public ProfilSqlRepository(RepositoryContext repositoryContext, ILogger<ProfilSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }

    public User GetByIdUser(int id)
    {
        try
        {
            var user = _context.users_20ts24tu.Include(u => u.user_type_)
            .Include(u => u.person_).ThenInclude(x => x.img_)
            .Include(u => u.person_).ThenInclude(x => x.employee_type_)
            .Include(u => u.person_).ThenInclude(x => x.departament_).ThenInclude(x => x.departament_type_)
            .FirstOrDefault(u => (u.status_.status != "Deleted" && u.id == id));

            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public bool UpdateUserProfil(User user, string oldPassword)
    {
        try
        {
            User userDb = GetByIdUser(SessionClass.id);

            string passwordOn = PasswordManager.EncryptPassword(userDb.login + oldPassword);
            if (passwordOn == userDb.password)
            {
                userDb.login = user.login;
                userDb.password = PasswordManager.EncryptPassword(user.login + user.password);
                userDb.person_.firstName = user.person_.firstName;
                userDb.person_.lastName = user.person_.lastName;
                userDb.person_.fathers_name = user.person_.fathers_name;
                userDb.person_.email = user.person_.email;
                userDb.updated_at = DateTime.UtcNow;

                if (user.person_.img_ != null)
                {
                    userDb.person_.img_ = user.person_.img_;
                }
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }
}
