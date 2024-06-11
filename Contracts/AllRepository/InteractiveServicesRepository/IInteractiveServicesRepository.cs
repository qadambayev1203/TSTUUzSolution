using Entities.Model.InteractiveServicesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.InteractiveServicesRepository
{
    public interface IInteractiveServicesRepository
    {
        //InteractiveServices CRUD
        public IEnumerable<InteractiveServices> AllInteractiveServices(int queryNum, int pageNum);
        public IEnumerable<InteractiveServices> AllInteractiveServicesSite(int queryNum, int pageNum);
        public InteractiveServices GetInteractiveServicesById(int id);
        public InteractiveServices GetInteractiveServicesByIdSite(int id);
        public int CreateInteractiveServices(InteractiveServices interactiveservices);
        public bool UpdateInteractiveServices(int id, InteractiveServices interactiveservices);
        public bool DeleteInteractiveServices(int id);



        //InteractiveServicesTranslation CRUD
        public IEnumerable<InteractiveServicesTranslation> AllInteractiveServicesTranslation(int queryNum, int pageNum, string language_code);
        public IEnumerable<InteractiveServicesTranslation> AllInteractiveServicesTranslationSite(int queryNum, int pageNum, string language_code);
        public InteractiveServicesTranslation GetInteractiveServicesTranslationById(int id);
        public InteractiveServicesTranslation GetInteractiveServicesTranslationById(int uz_id, string language_code);
        public InteractiveServicesTranslation GetInteractiveServicesTranslationByIdSite(int uz_id, string language_code);
        public InteractiveServicesTranslation GetInteractiveServicesTranslationByIdSite(int id);
        public int CreateInteractiveServicesTranslation(InteractiveServicesTranslation interactiveservicestranslation);
        public bool UpdateInteractiveServicesTranslation(int id, InteractiveServicesTranslation interactiveservices);
        public bool DeleteInteractiveServicesTranslation(int id);


        public bool SaveChanges();
    }
}
