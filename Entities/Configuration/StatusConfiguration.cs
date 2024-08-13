using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Model.StatusModel;

namespace Entities.Configuration;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasData(
            new Status { id = 1, status = "Active", name = "Faol", is_deleted = false },
            new Status { id = 2, status = "Deleted", name = "O'chirilgan", is_deleted = false }
            );

    }
}
