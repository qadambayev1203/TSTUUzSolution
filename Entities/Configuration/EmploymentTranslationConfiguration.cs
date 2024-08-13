using Entities.Model.EmploymentModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entities.Configuration;

public class EmploymentTranslationConfiguration : IEntityTypeConfiguration<EmploymentTranslation>
{
    public void Configure(EntityTypeBuilder<EmploymentTranslation> builder)
    {
        builder.HasData(
            new EmploymentTranslation { id = 1, status_translation_id = 1, title = "Busy", employment_id = 1, language_id = 1 },
            new EmploymentTranslation { id = 2, status_translation_id = 1, title = "Unemployed", employment_id = 2, language_id = 1 },
            new EmploymentTranslation { id = 3, status_translation_id = 1, title = "Retired", employment_id = 3, language_id = 1 },
            new EmploymentTranslation { id = 4, status_translation_id = 1, title = "Student", employment_id = 4, language_id = 1 }
            );

    }
}

