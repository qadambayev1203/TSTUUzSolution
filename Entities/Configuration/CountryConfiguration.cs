using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Model.CountrysModel;

namespace Entities.Configuration;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasData(
            new Country { id = 1, title = "O'zbekiston", status_id=1},
            new Country { id = 2, title = "Boshqa", status_id = 1 }               
            );

    }
}
