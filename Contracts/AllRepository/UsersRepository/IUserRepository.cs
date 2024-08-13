using Entities.Model;

namespace Contracts.AllRepository.UsersRepository;

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
