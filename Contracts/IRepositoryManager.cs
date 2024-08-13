namespace Contracts;

public interface IRepositoryManager
{
    IUserRepositoryy User { get; }
    Task SaveAsync();
}
