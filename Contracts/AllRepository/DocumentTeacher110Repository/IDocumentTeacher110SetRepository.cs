using Entities.Model.DocumentTeacher110Model;
using Entities.Model.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.DocumentTeacher110Repository
{
    public interface IDocumentTeacher110SetRepository
    {
        public IEnumerable<DocumentTeacher110Set> AllDocumentTeacher110Set(int oldYear, int newYear);
        public IEnumerable<Person> AllDocumentTeacher110SetAdmin(int oldYear, int newYear);
        public IEnumerable<Person> AllDocumentTeacher110SetConfirmationDepartament(int oldYear, int newYear);
        public DocumentTeacher110SetList DocumentTeacher110SetAdmin(int oldYear, int newYear, int person_id);
        public DocumentTeacher110SetList DocumentTeacher110SetConfirmDep(int oldYear, int newYear, int person_id);
        public DocumentTeacher110Set GetDocumentTeacher110SetById(int id);
        public DocumentTeacher110Set GetDocumentTeacher110SetByIdAdmin(int id);
        public int CreateDocumentTeacher110Set(DocumentTeacher110Set documentTeacher110Set);
        public bool UpdateDocumentTeacher110Set(int id, DocumentTeacher110Set documentTeacher110Set);
        public bool ConfirmDocumentTeacher110Set(int id, bool confirm, string? reason_for_rejection);
        public bool DeleteDocumentTeacher110Set(int id);
    }
}
