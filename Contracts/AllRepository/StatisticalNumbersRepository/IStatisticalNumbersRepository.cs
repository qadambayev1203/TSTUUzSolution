using Entities.Model.StatisticalNumbersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.StatisticalNumbersRepository
{
    public interface IStatisticalNumbersRepository
    {
        //StatisticalNumbers CRUD
        public IEnumerable<StatisticalNumbers> AllStatisticalNumbers(int queryNum, int pageNum);
        public IEnumerable<StatisticalNumbers> AllStatisticalNumbersSite(int queryNum, int pageNum);
        public StatisticalNumbers GetStatisticalNumbersById(int id);
        public StatisticalNumbers GetStatisticalNumbersByIdSite(int id);
        public int CreateStatisticalNumbers(StatisticalNumbers statisticalNumbers);
        public bool UpdateStatisticalNumbers(int id, StatisticalNumbers statisticalNumbers);
        public bool DeleteStatisticalNumbers(int id);



        //StatisticalNumbersTranslation CRUD
        public IEnumerable<StatisticalNumbersTranslation> AllStatisticalNumbersTranslation(int queryNum, int pageNum, string language_code);
        public IEnumerable<StatisticalNumbersTranslation> AllStatisticalNumbersTranslationSite(int queryNum, int pageNum, string language_code);
        public StatisticalNumbersTranslation GetStatisticalNumbersTranslationById(int id);
        public StatisticalNumbersTranslation GetStatisticalNumbersTranslationById(int uz_id, string language_code);
        public StatisticalNumbersTranslation GetStatisticalNumbersTranslationByIdSite(int uz_id, string language_code);
        public StatisticalNumbersTranslation GetStatisticalNumbersTranslationByIdSite(int id);
        public int CreateStatisticalNumbersTranslation(StatisticalNumbersTranslation statisticalNumberstranslation);
        public bool UpdateStatisticalNumbersTranslation(int id, StatisticalNumbersTranslation statisticalNumbers);
        public bool DeleteStatisticalNumbersTranslation(int id);


        public bool SaveChanges();
    }
}
