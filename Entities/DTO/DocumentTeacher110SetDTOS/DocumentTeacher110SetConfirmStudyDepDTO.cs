using Entities.Model.DocumentTeacher110Model;
using Entities.Model.FileModel;
using Entities.Model.PersonModel;
using Entities.Model.StatusModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DocumentTeacher110SetDTOS
{
    public class DocumentTeacher110SetConfirmStudyDepDTO
    {
        public bool confirm { get; set; }
        public double? score { get; set; }
        public string? reason_for_rejection { get; set; }

    }
}
