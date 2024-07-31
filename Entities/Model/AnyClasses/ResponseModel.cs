using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.AnyClasses
{
    public class ResponseModel<T>
    {
        public int length { get; set; }
        public IEnumerable<T> list { get; set; }
    }
}
