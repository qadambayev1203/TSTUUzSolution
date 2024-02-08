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
        public IEnumerable<Gender> AllGender();
        public Gender GetGenderById(int id);
        public bool CreateGender(Gender gender);
        public bool UpdateGender(int id,Gender gender);
        public bool DeleteGender(int id);



        //GenderTranslation CRUD
        public IEnumerable<GenderTranslation> AllGenderTranslation();
        public GenderTranslation GetGenderTranslationById(int id);
        public bool CreateGenderTranslation(GenderTranslation genderTranslation);
        public bool UpdateGenderTranslation(int id, GenderTranslation genderTranslation);
        public bool DeleteGenderTranslation(int id);
    }
}
