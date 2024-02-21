using Entities.Model;
using Entities.Model.DepartamentDetailsModel;
using Entities.Model.DepartamentsModel;
using Entities.Model.DepartamentsTypeModel;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.PagesModel;
using Entities.Model.PersonModel;
using Entities.Model.SiteDetailsModel;
using Entities.Model.SitesModel;
using Entities.Model.SiteTypesModel;
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
                .HasIndex(u => u.login)
                .IsUnique();
            modelBuilder.Entity<User>()
        .HasOne(u => u.departament_)
        .WithOne(d => d.user_)
        .HasForeignKey<Departament>(d => d.user_id);

            modelBuilder.Entity<Departament>()
         .HasOne(d => d.user_)
         .WithOne(u => u.departament_)
         .HasForeignKey<User>(u => u.departament_id);


            base.OnModelCreating(modelBuilder);
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
        public DbSet<DepartamentDetail> departament_details_20ts24tu { get; set; }
        public DbSet<DepartamentDetailTranslation> departament_details_translations_20ts24tu { get; set; }
        public DbSet<Departament> departament_20ts24tu { get; set; }
        public DbSet<DepartamentTranslation> departament_translations_20ts24tu { get; set; }
        public DbSet<DepartamentType> departament_types_20ts24tu { get; set; }
        public DbSet<DepartamentTypeTranslation> departament_types_translations_20ts24tu { get; set; }
        public DbSet<Pages> pages_20ts24tu { get; set; }
        public DbSet<PageTranslation> pages_translations_20ts24tu { get; set; }
        public DbSet<SiteDetail> site_details_20ts24tu { get; set; }
        public DbSet<SiteDetailTranslation> site_details_translations_20ts24tu { get; set; }
        public DbSet<Site> sites_20ts24tu { get; set; }
        public DbSet<SiteTranslation> sites_translations_20ts24tu { get; set; }
        public DbSet<SiteType> site_types_20ts24tu { get; set; }
        public DbSet<SiteTypeTranslation> site_types_translations_20ts24tu { get; set; }
        public DbSet<User> users_20ts24tu { get; set; }
        public DbSet<UserType> user_types_20ts24tu { get; set; }
        public DbSet<UserTypeTranslation> user_types_translations_20ts24tu { get; set; }

    }
}
