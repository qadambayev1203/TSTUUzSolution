using Entities.Model.DocumentTeacher110Model;
using Entities.Model.PersonModel;

namespace Contracts.AllRepository.DocumentTeacher110Repository;

public interface IDocumentTeacher110SetRepository
{
    //Teacher
    public IEnumerable<DocumentTeacher110Set> AllDocumentTeacher110Set(int oldYear, int newYear);
    public double? GetTeacherDocumentScore(int oldYear, int newYear);
    public DocumentTeacher110Set GetDocumentTeacher110SetById(int id);
    public IEnumerable<DocumentTeacher110Set> GetDocumentTeacher110SetByDocumentId(int oldYear, int newYear, int document_id);
    public int CreateDocumentTeacher110Set(DocumentTeacher110Set documentTeacher110Set);
    public bool UpdateDocumentTeacher110Set(int id, DocumentTeacher110Set documentTeacher110Set);
    public bool DeleteDocumentTeacher110Set(int id);


    //Admin
    public IEnumerable<Person> AllDocumentTeacher110SetAdmin(int oldYear, int newYear);
    public DocumentTeacher110SetList DocumentTeacher110SetAdmin(int oldYear, int newYear, int person_id);
    public DocumentTeacher110Set GetDocumentTeacher110SetByIdAdmin(int id);


    // Head of Departament
    public IEnumerable<Person> AllDocumentTeacher110SetConfirmationDepartament(int oldYear, int newYear);

    public DocumentTeacher110SetList DocumentTeacher110SetConfirmDep(int oldYear, int newYear, int person_id);

    public bool ConfirmDocumentTeacher110Set(int id, bool confirm, string? reason_for_rejection);

    //Faculty Council
    public IEnumerable<Person> AllDocumentTeacher110SetConfirmationFacultyCouncil(int oldYear, int newYear);

    public DocumentTeacher110SetList DocumentTeacher110SetConfirmFacultyCouncil(int oldYear, int newYear, int person_id);

    public bool ConfirmDocumentTeacher110SetFacultyCouncil(int id, bool confirm, DocumentTeacher110Set teacher110Set);


    //Study department
    public IEnumerable<Person> AllDocumentTeacher110SetConfirmationStudyDep(int oldYear, int newYear);

    public DocumentTeacher110SetList DocumentTeacher110SetConfirmStudyDep(int oldYear, int newYear, int person_id);



}
