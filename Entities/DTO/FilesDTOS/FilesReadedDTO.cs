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
    public class FilesReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? url { get; set; }
        public DateTime? crated_at { get; set; } = DateTime.Now;
        public DateTime? updated_at { get; set; }
        public Status? status_ { get; set; }
        public User? user_ { get; set; }
    }
}
