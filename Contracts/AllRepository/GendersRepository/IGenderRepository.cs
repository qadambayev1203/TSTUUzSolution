using Entities.Model.GenderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.GendersRepository
{
    public interface IGenderRepository
    {

        //Gender CRUD
        public IEnumerable<Gender> AllGender(int queryNum, int pageNum);
        public Gender GetGenderById(int id);
        public int CreateGender(Gender gender);
        public bool UpdateGender();
        public bool DeleteGender(int id);



        //GenderTranslation CRUD
        public IEnumerable<GenderTranslation> AllGenderTranslation(int queryNum, int pageNum, string language_code);
        public GenderTranslation GetGenderTranslationById(int id);
        public int CreateGenderTranslation(GenderTranslation genderTranslation);
        public bool UpdateGenderTranslation();
        public bool DeleteGenderTranslation(int id);

        public bool SaveChanges();

    }
}
