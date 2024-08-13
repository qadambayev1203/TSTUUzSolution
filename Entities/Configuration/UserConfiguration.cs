using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Model;
using Entities.Model.AnyClasses;

namespace Entities.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                id = 1,
                user_type_id = 1,
                login = "admin",
                password = PasswordManager.EncryptPassword(("admin123").ToString()),
                person_id = null,
                status_id = 1
            });
        builder.HasIndex(u => u.login).IsUnique();


    }

}
