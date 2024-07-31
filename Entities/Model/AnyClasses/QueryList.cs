using Entities.Model.BlogsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.AnyClasses
{
    public class QueryList<T>
    {
        public int length { get; set; }
        public List<T> query_list { get; set; }
    }
}
