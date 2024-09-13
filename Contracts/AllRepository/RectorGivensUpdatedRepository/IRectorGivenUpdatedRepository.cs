using Entities.Model;
using Entities.Model.DepartamentsModel;
using Entities.Model.PersonDataModel;

namespace Contracts.AllRepository.RectorGivensUpdatedRepository;

public interface IRectorGivenUpdatedRepository
{
    //RectorGiven CRUD
    public Departament GetRectorGiven();
    public bool UpdateRectorGiven(Departament departament);

    //RectorGivenTranslation CRUD
    public DepartamentTranslation GetRectorGivenTranslation(string language_code);
    public bool UpdateRectorGivenTranslation(DepartamentTranslation departament, string language_code);



    //RectorData CRUD
    public PersonData GetRectorData();
    public bool UpdateRectorData(PersonData rectorData);

    //PersonDataTranslation CRUD
    public PersonDataTranslation GetRectorDataTranslation(string language_code);
    public bool UpdateRectorDataTranslation(PersonDataTranslation rectorData, string language_code);


}
