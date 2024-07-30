using Entities.Model.DocumentTeacher110Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.DocumentTeacher110Repository
{
    public interface IDocumentTeacher110SetRepository
    {
        public IEnumerable<DocumentTeacher110Set> AllDocumentTeacher110Set(int person_id);
        public IEnumerable<DocumentTeacher110Set> AllDocumentTeacher110SetAdmin(int person_id);
        public DocumentTeacher110Set GetDocumentTeacher110SetById(int id);
        public DocumentTeacher110Set GetDocumentTeacher110SetByIdAdmin(int id);
        public int CreateDocumentTeacher110Set(DocumentTeacher110Set documentTeacher110Set);
        public bool UpdateDocumentTeacher110Set(int id, DocumentTeacher110Set documentTeacher110Set);
        public bool DeleteDocumentTeacher110Set(int id);
    }
}
