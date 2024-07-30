using Entities.Model.DocumentTeacher110Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.DocumentTeacher110Repository
{
    public interface IDocumentTeacher110Repository
    {
        //DocumentTeacher110 CRUD
        public IEnumerable<DocumentTeacher110> AllDocumentTeacher110(int? parent_id, bool parent);
        public IEnumerable<DocumentTeacher110> AllDocumentTeacher110Admin(int? parent_id, bool parent);
        public DocumentTeacher110 GetDocumentTeacher110ById(int id);
        public DocumentTeacher110 GetDocumentTeacher110ByIdAdmin(int id);
        public int CreateDocumentTeacher110(DocumentTeacher110 documentTeacher110);
        public bool UpdateDocumentTeacher110(int id, DocumentTeacher110 documentTeacher110);
        public bool DeleteDocumentTeacher110(int id);
    }
}
