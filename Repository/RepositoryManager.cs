using Contracts;
using Entities;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext repositoryContext;
    private IUserRepositoryy userRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        this.repositoryContext = repositoryContext;
    }
    public IUserRepositoryy User
    {

        get
        {
            if (userRepository == null)
            {
                userRepository = new UserRepository(repositoryContext);
            }
            return userRepository;
        }
    }

    public Task SaveAsync() => repositoryContext.SaveChangesAsync();
}
