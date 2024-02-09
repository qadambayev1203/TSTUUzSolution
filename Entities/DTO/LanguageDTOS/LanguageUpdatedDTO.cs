using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.LanguageDTOS
{
    public class LanguageUpdatedDTO
    {
        public string? languages { get; set; }
        public int? status_id { get; set; }
    }
}
