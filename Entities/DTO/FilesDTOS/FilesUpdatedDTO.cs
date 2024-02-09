using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.FilesDTOS
{
    public class FilesUpdatedDTO
    {
        public string? title { get; set; }
        public string? url { get; set; }
        public int? status_id { get; set; }
        public int? user_id { get; set; }
    }
}
