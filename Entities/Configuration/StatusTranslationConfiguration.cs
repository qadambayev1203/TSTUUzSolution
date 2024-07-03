using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model.StatusModel;

namespace Entities.Configuration
{
    public class StatusTranslationConfiguration : IEntityTypeConfiguration<StatusTranslation>
    {
        public void Configure(EntityTypeBuilder<StatusTranslation> builder)
        {
            builder.HasData(
                new StatusTranslation { id = 1, status = "Active", status_id = 1, name = "Active", language_id = 1, is_deleted = false },
                new StatusTranslation { id = 2, status = "Deleted", status_id = 2, name = "Deleted", language_id = 1, is_deleted = false },
                 new StatusTranslation { id = 3, status = "Active", status_id = 1, name = "Активный", language_id = 2, is_deleted = false },
                new StatusTranslation { id = 4, status = "Deleted", status_id = 2, name = "Удалено", language_id = 2, is_deleted = false }
                );

        }
    }
}
