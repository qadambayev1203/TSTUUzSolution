using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DocumentTeacher110SetDTOS
{
    public class DocumentTeacher110SetCreatedDTO
    {
        public int? old_year { get; set; }
        public int? new_year { get; set; }
        public int? document_id { get; set; }
        public IFormFile? file_up { get; set; }
        public string? comment { get; set; }
    }
}
