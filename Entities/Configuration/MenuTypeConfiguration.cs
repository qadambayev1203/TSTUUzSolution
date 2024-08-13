using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Model.MenuTypesModel;
using Microsoft.EntityFrameworkCore;

namespace Entities.Configuration;

public class MenuTypeConfiguration : IEntityTypeConfiguration<MenuType>
{
    public void Configure(EntityTypeBuilder<MenuType> builder)
    {
        builder.HasData(
            new MenuType { id = 1, status_id = 1, title = "Main" },
            new MenuType { id = 2, status_id = 1, title = "Blog" },
            new MenuType { id = 3, status_id = 1, title = "Page" },
            new MenuType { id = 4, status_id = 1, title = "Link" },
            new MenuType { id = 5, status_id = 1, title = "Faculty" },
            new MenuType { id = 6, status_id = 1, title = "Department" },
            new MenuType { id = 7, status_id = 1, title = "Section" }
            );

    }
}
