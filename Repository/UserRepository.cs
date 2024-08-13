using Contracts;
using Entities.Model;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class UserRepository : RepositoryBase<User>, IUserRepositoryy
{
    public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    { }

    public async Task<User> LoginAsync(string login, string password, bool tracking, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(
                x => x.login.Equals(login) && x.password.Equals(password), tracking)
            .Include(u => u.user_type_)
            .Include(u => u.person_).ThenInclude(x => x.img_)
            .Include(u => u.person_).ThenInclude(x => x.employee_type_)
            .Include(u => u.person_).ThenInclude(x => x.departament_).ThenInclude(x => x.departament_type_)
            .Where(u => u.status_.status != "Deleted")
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<User> LoginAsyncHemis(string passportNumber, string pinfl, bool tracking, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(
                x => x.person_.pinfl.Equals(pinfl) && (x.person_.passport_text + x.person_.passport_number).Equals(passportNumber), tracking)
            .Include(u => u.user_type_)
            .Include(u => u.person_).ThenInclude(x => x.img_)
            .Include(u => u.person_).ThenInclude(x => x.employee_type_)
            .Include(u => u.person_).ThenInclude(x => x.departament_).ThenInclude(x => x.departament_type_)
            .Where(u => u.status_.status != "Deleted")
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<User> RefreshToken(int user_id, bool tracking, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(
                x => x.id.Equals(user_id), tracking)
            .Include(u => u.user_type_)
            .Include(u => u.person_).ThenInclude(x => x.img_)
            .Include(u => u.person_).ThenInclude(x => x.employee_type_)
            .Include(u => u.person_).ThenInclude(x => x.departament_).ThenInclude(x => x.departament_type_)
            .Where(u => u.status_.status != "Deleted")
            .SingleOrDefaultAsync(cancellationToken);
    }
}
