using Entities.Model;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.PersonModel;
using Entities.Model.StatusModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u=>u.login)
                .IsUnique();
        }




        public DbSet<Files> files_20ts24tu { get; set; }
        public DbSet<FilesTranslation> files_translations_20ts24tu { get; set; }
        public DbSet<Gender> genders_20ts24tu { get; set; }
        public DbSet<GenderTranslation> genders_translations_20ts24tu { get; set; }
        public DbSet<Language> languages_20ts24tu { get; set; }
        public DbSet<Person> persons_20ts24tu { get; set; }
        public DbSet<PersonTranslation> persons_translations_20ts24tu { get; set; }
        public DbSet<Status> statuses_20ts24tu { get; set; }
        public DbSet<StatusTranslation> statuses_translations_20ts24tu { get; set; }
        public DbSet<User> users_20ts24tu { get; set; }
        public DbSet<UserType> user_types_20ts24tu { get; set; }
        public DbSet<UserTypeTranslation> user_types_translations_20ts24tu { get; set; }
    }
}
