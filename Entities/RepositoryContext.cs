using Entities.Model;
using Entities.Model.BlogsCategoryModel;
using Entities.Model.BlogsModel;
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
using System.Diagnostics;
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

            base.OnModelCreating(modelBuilder);
        }
        public void BackupDatabase(/*string server,string port,string user,string password,string dbname,string backupCommandDir,string backupFile*/)

        {
            try
            {
                string server = "localhost";
                string port = "5432";
                string user = "postgres";
                string password = "1203";
                string dbname = "TSTUUzDB";
                string backupCommandDir = "C:\\Program Files\\PostgreSQL\\16\\bin";
                Environment.SetEnvironmentVariable("PGPASSWORD", password);
                string backupFile = "C:\\Users\\Admin\\Desktop\\TSTUz-BAZA\\bazaBackup.backup";
                string BackupString = " -f \"" + backupFile + "\" -F c" + " -h " + server + " -U " + user + " -p " + port + " -d " + dbname;
                Process proc = new Process();
                proc.StartInfo.FileName = backupCommandDir + "\\pg_dump.exe";
                proc.StartInfo.Arguments = BackupString;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
                proc.Close();
            }
            catch
            {

            }
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
        public DbSet<BlogCategory> blogs_category_20ts24tu { get; set; }
        public DbSet<BlogCategoryTranslation> blogs_category_translations_20ts24tu { get; set; }
        public DbSet<Blog> blogs_20ts24tu { get; set; }
        public DbSet<BlogTranslation> blogs_translations_20ts24tu { get; set; }
        public DbSet<User> users_20ts24tu { get; set; }
        public DbSet<UserType> user_types_20ts24tu { get; set; }
        public DbSet<UserTypeTranslation> user_types_translations_20ts24tu { get; set; }

    }
}
