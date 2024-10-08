﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Model.GenderModel;

namespace Entities.Configuration;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.HasData(
            new Gender { id = 1, gender = "Erkak", status_id = 1 },
            new Gender { id = 2, gender = "Ayol", status_id = 1 }
            );

    }
}
