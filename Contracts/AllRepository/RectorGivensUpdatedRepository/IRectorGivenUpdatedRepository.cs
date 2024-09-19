using Entities.Model;
using Entities.Model.DepartamentsModel;
using Entities.Model.PersonDataModel;

namespace Contracts.AllRepository.RectorGivensUpdatedRepository;

public interface IRectorGivenUpdatedRepository
{
    //RectorData CRUD
    public List<PersonData> GetRectoratData();
    public PersonData GetByIdRectoratData(int id);
    public bool UpdateRectorData(PersonData rectorData, int id);

    //PersonDataTranslation CRUD
    public List<PersonDataTranslation> GetRectoratDataTranslation(string language_code);
    public PersonDataTranslation GetByIdRectoratDataTranslation(int uz_id, string language_code);
    public bool UpdateRectoratDataTranslation(PersonDataTranslation rectorData, int id);


}
