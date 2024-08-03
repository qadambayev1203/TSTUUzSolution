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
    public class DocumentTeacher110SetListReadedDTO<T>
    {
        public PersonUserDTO person_ { get; set; }
        public List<T> documents_teacher_ { get; set; }
    }
}
