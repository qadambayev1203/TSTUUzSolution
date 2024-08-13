using Entities.DTO.PersonDTOS;

namespace Entities.DTO.DocumentTeacher110SetDTOS;

public class DocumentTeacher110SetListReadedDTO<T>
{
    public PersonUserDTO person_ { get; set; }
    public List<T> documents_teacher_ { get; set; }
}
