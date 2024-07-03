using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model.LanguagesModel;

namespace Entities.Configuration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {

        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasData(
                new Language { id = 1, title = "England", code = "en", status_id = 1 },
                new Language { id = 2, title = "Russian", code = "ru", status_id = 1 }
                );

        }
    }
}
