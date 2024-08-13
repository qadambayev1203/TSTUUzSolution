using Entities.Model.TerritoriesModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entities.Configuration;

public class TerritorieConfiguration : IEntityTypeConfiguration<Territorie>
{
    public void Configure(EntityTypeBuilder<Territorie> builder)
    {
        builder.HasData(
            new Territorie { id = 8, status_id = 1, title = "Qoraqalpogʻiston Respublikasi", country_id = 1 },
            new Territorie { id = 9, status_id = 1, title = "Buxoro viloyati", country_id = 1 },
            new Territorie { id = 10, status_id = 1, title = "Samarqand viloyati", country_id = 1 },
            new Territorie { id = 11, status_id = 1, title = "Navoiy viloyati", country_id = 1 },
            new Territorie { id = 12, status_id = 1, title = "Andijon viloyati", country_id = 1 },
            new Territorie { id = 13, status_id = 1, title = "Fargʻona viloyati", country_id = 1 },
            new Territorie { id = 14, status_id = 1, title = "Surxondaryo viloyati", country_id = 1 },
            new Territorie { id = 15, status_id = 1, title = "Sirdaryo viloyati", country_id = 1 },
            new Territorie { id = 16, status_id = 1, title = "Xorazm viloyati", country_id = 1 },
            new Territorie { id = 17, status_id = 1, title = "Toshkent viloyati", country_id = 1 },
            new Territorie { id = 18, status_id = 1, title = "Qashqadaryo viloyati", country_id = 1 },
            new Territorie { id = 19, status_id = 1, title = "Jizzax viloyati", country_id = 1 },
            new Territorie { id = 21, status_id = 1, title = "Namangan viloyati", country_id = 1 },
            new Territorie { id = 22, status_id = 1, title = "Toshkent shahri", country_id = 1 }
            );

    }
}
