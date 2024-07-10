using Entities.Model;
using Entities.Model.BlogsCategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.ProfilsRepository
{
    public interface IProfilRepository
    {
        public bool UpdateUserProfil(User user, string oldPassword);
        public User GetByIdUser(int id);
    }
}
