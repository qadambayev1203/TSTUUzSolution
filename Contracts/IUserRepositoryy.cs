using Entities.Model;

namespace Contracts;

public interface IUserRepositoryy
{
    Task<User> LoginAsync(string login, string password, bool tracking, CancellationToken cancellationToken = default);
    Task<User> LoginAsyncHemis(string passportNumber, string pinfl, bool tracking, CancellationToken cancellationToken = default);
    Task<User> RefreshToken(int user_id, bool tracking, CancellationToken cancellationToken = default);

}
