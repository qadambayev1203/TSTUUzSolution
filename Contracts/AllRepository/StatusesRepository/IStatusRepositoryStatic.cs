using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.StatusesRepository
{
    public interface IStatusRepositoryStatic
    {
        public int GetStatusId(string status);        
        public int GetStatusTranslationId(string status, int language_id);     
        public bool SaveChanges();
    }
}
