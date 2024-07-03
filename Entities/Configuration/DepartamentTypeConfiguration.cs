using Entities.Model.DepartamentsTypeModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class DepartamentTypeConfiguration : IEntityTypeConfiguration<DepartamentType>
    {
        public void Configure(EntityTypeBuilder<DepartamentType> builder)
        {
            builder.HasData(
                new DepartamentType { id = 1, type = "Rektor", status_id = 1 },
                new DepartamentType { id = 2, type = "Rektor yordamchisi", status_id = 1 },
                new DepartamentType { id = 3, type = "Rektor maslahatchisi", status_id = 1 },
                new DepartamentType { id = 4, type = "Kengash", status_id = 1 },
                new DepartamentType { id = 5, type = "Boshqarma", status_id = 1 },
                new DepartamentType { id = 6, type = "Markaz", status_id = 1 },
                new DepartamentType { id = 7, type = "Bo'lim", status_id = 1 },
                new DepartamentType { id = 8, type = "Assistent", status_id = 1 },
                new DepartamentType { id = 9, type = "Litsey", status_id = 1 },
                new DepartamentType { id = 10, type = "Texnikum", status_id = 1 },
                new DepartamentType { id = 11, type = "Sektor", status_id = 1 },
                new DepartamentType { id = 12, type = "Poligon", status_id = 1 },
                new DepartamentType { id = 13, type = "Omborxona", status_id = 1 },
                new DepartamentType { id = 14, type = "Muzey", status_id = 1 },
                new DepartamentType { id = 15, type = "Psixolog", status_id = 1 },
                new DepartamentType { id = 16, type = "Inshoot", status_id = 1 },
                new DepartamentType { id = 18, type = "TTJ", status_id = 1 },
                new DepartamentType { id = 19, type = "Qozonxona", status_id = 1 },
                new DepartamentType { id = 20, type = "Xizmat", status_id = 1 },
                new DepartamentType { id = 21, type = "Kotib", status_id = 1 },
                new DepartamentType { id = 22, type = "Fakultet", status_id = 1 },
                new DepartamentType { id = 23, type = "Yuriskonsult", status_id = 1 },
                new DepartamentType { id = 24, type = "Devonxona", status_id = 1 },
                new DepartamentType { id = 25, type = "Arxiv", status_id = 1 }
                );

        }
    }
}
