using Entities.DTO.PersonDTOS;
using Entities.Model.DocumentTeacher110Model;
using Entities.Model.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DocumentTeacher110SetDTOS
{
    public class DocumentTeacher110SetListReadedDTO
    {
        public PersonUserDTO person_ { get; set; }
        public List<DocumentTeacher110SetAdminReadedDTO> documents_teacher_ { get; set; }
    }
}
