using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepositoryy
    {
        Task<User> LoginAsync(string login, string password, bool tracking, CancellationToken cancellationToken = default);
        Task<User> LoginAsyncHemis(string passportNumber, string pinfl, bool tracking, CancellationToken cancellationToken = default);

    }
}
