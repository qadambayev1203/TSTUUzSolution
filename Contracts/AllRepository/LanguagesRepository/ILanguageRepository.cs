using Entities.Model.LanguagesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.LanguagesRepository
{
    public interface ILanguageRepository
    {
        //Language CRUD
        public IEnumerable<Language> AllLanguage();
        public Language GetLanguageById(int id);
        public bool CreateLanguage(Language language);
        public bool UpdateLanguage();
        public bool DeleteLanguage(int id);



       
    }
}
