using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Entities.DTO.FilesDTOS
{
    public class FilesUpdatedDTO
    {
        public string title { get; set; }
        public IFormFile? url { get; set; }
        public int status_id { get; set; }
    }
}
