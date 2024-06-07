using Entities.Model.TerritoriesModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class TerritorieConfiguration : IEntityTypeConfiguration<Territorie>
    {
        public void Configure(EntityTypeBuilder<Territorie> builder)
        {
            builder.HasData(
                new Territorie { id = 8, title = "Qoraqalpogʻiston Respublikasi", country_id=1 },
                new Territorie { id = 9, title = "Buxoro viloyati", country_id = 1 },
                new Territorie { id = 10, title = "Samarqand viloyati", country_id=1  },
                new Territorie { id = 11, title = "Navoiy viloyati", country_id=1  },
                new Territorie { id = 12, title = "Andijon viloyati", country_id=1  },
                new Territorie { id = 13, title = "Fargʻona viloyati", country_id=1  },
                new Territorie { id = 14, title = "Surxondaryo viloyati", country_id=1  },
                new Territorie { id = 15, title = "Sirdaryo viloyati", country_id=1  },
                new Territorie { id = 16, title = "Xorazm viloyati", country_id=1  },
                new Territorie { id = 17, title = "Toshkent viloyati", country_id=1  },
                new Territorie { id = 18, title = "Qashqadaryo viloyati", country_id=1  },
                new Territorie { id = 19, title = "Jizzax viloyati", country_id=1  },
                new Territorie { id = 21, title = "Namangan viloyati", country_id=1  },
                new Territorie { id = 22, title = "Toshkent shahri", country_id=1  }
                );

        }
    }
}
