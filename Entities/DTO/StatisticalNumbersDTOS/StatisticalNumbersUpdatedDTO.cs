using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Entities.DTO.StatisticalNumbersDTOS
{
    public class StatisticalNumbersUpdatedDTO
    {
        public string title { get; set; }
        public string description { get; set; }
        public string numbers { get; set; }
        public IFormFile? icon_up { get; set; }
        public int? status_id { get; set; }
    }
}
