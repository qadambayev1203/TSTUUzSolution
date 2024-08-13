using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Model.EmploymentModel;

namespace Entities.Configuration;

public class EmploymentConfiguration : IEntityTypeConfiguration<Employment>
{
    public void Configure(EntityTypeBuilder<Employment> builder)
    {
        builder.HasData(
            new Employment { id = 1,  status_id = 1, title = "Band" },
            new Employment { id = 2,  status_id = 1, title = "Ishsiz" },
            new Employment { id = 3,  status_id = 1, title = "Nafaqada" },
            new Employment { id = 4,  status_id = 1, title = "Talaba" }
            );

    }
}
