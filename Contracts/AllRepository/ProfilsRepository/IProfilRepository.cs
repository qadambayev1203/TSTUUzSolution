using Entities.Model;

namespace Contracts.AllRepository.ProfilsRepository;

public interface IProfilRepository
{
    public bool UpdateUserProfil(User user, string oldPassword);
    public User GetByIdUser(int id);
}
