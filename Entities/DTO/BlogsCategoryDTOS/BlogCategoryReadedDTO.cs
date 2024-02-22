using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.BlogsCategoryDTOS
{
    public class BlogCategoryReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public Status? status_ { get; set; }
    }
}
