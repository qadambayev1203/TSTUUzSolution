using Entities.Configuration;
using Entities.Model;
using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.AppealToEmployeeModel;
using Entities.Model.BlogsCategoryModel;
using Entities.Model.BlogsModel;
using Entities.Model.CountrysModel;
using Entities.Model.DepartamentDetailsModel;
using Entities.Model.DepartamentsModel;
using Entities.Model.DepartamentsTypeModel;
using Entities.Model.DistrictsModel;
using Entities.Model.EmployeeTypesModel;
using Entities.Model.EmploymentModel;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.InteractiveServicesModel;
using Entities.Model.LanguagesModel;
using Entities.Model.MenuModel;
using Entities.Model.MenuTypesModel;
using Entities.Model.NeighborhoodsModel;
using Entities.Model.PagesModel;
using Entities.Model.PersonDataModel;
using Entities.Model.PersonModel;
using Entities.Model.SiteDetailsModel;
using Entities.Model.SitesModel;
using Entities.Model.SiteTypesModel;
using Entities.Model.StatisticalNumbersModel;
using Entities.Model.StatusModel;
using Entities.Model.TerritoriesModel;
using Entities.Model.TokensModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
            try
            {
                Database.EnsureCreated();
            }
            catch
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new TerritorieConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictConfiguration());
            modelBuilder.ApplyConfiguration(new EmploymentConfiguration());
            modelBuilder.ApplyConfiguration(new EmploymentTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new StatusTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new MenuTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new DepartamentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartamentConfiguration());


            modelBuilder.Entity<Files>().HasIndex(f => f.title).IsUnique();
            modelBuilder.Entity<FilesTranslation>().HasIndex(f => f.title).IsUnique();
            modelBuilder.Entity<User>().HasIndex(f => f.login).IsUnique();

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
                //string backupFile = "D:\\TSTUUzProject\\TSTUUzDB\\bazaBackup.backup";
                string backupFile = "C:/Users/Admin/Desktop/TSTUz-BAZA/BazaDBBackup.sql";
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
        public DbSet<Country> countries_20ts24tu { get; set; }
        public DbSet<CountryTranslation> countries_translations_20ts24tu { get; set; }
        public DbSet<Territorie> territories_20ts24tu { get; set; }
        public DbSet<TerritorieTranslation> territories_translations_20ts24tu { get; set; }
        public DbSet<District> districts_20ts24tu { get; set; }
        public DbSet<DistrictTranslation> districts_translations_20ts24tu { get; set; }
        public DbSet<Neighborhood> neighborhoods_20ts24tu { get; set; }
        public DbSet<NeighborhoodTranslation> neighborhoods_translations_20ts24tu { get; set; }
        public DbSet<Employment> employments_20ts24tu { get; set; }
        public DbSet<EmploymentTranslation> employments_translations_20ts24tu { get; set; }
        public DbSet<EmployeeType> employee_types_20ts24tu { get; set; }
        public DbSet<EmployeeTypeTranslation> employee_types_translations_20ts24tu { get; set; }
        public DbSet<MenuType> menu_types_20ts24tu { get; set; }
        public DbSet<MenuTypeTranslation> menu_types_translations_20ts24tu { get; set; }
        public DbSet<Menu> menu_20ts24tu { get; set; }
        public DbSet<MenuTranslation> menu_translations_20ts24tu { get; set; }
        public DbSet<AppealToRector> appeals_to_rectors_20ts24tu { get; set; }
        public DbSet<AppealToRectorTranslation> appeals_to_rectors_translations_20ts24tu { get; set; }
        public DbSet<User> users_20ts24tu { get; set; }
        public DbSet<UserType> user_types_20ts24tu { get; set; }
        public DbSet<UserTypeTranslation> user_types_translations_20ts24tu { get; set; }
        public DbSet<Tokens> tokens_20ts24tu { get; set; }
        public DbSet<PersonData> persons_data_20ts24tu { get; set; }
        public DbSet<PersonDataTranslation> persons_data_translations_20ts24tu { get; set; }
        public DbSet<InteractiveServices> interactive_services_20ts24tu { get; set; }
        public DbSet<InteractiveServicesTranslation> interactive_services_translations_20ts24tu { get; set; }
        public DbSet<StatisticalNumbers> statistical_numbers_20ts24tu { get; set; }
        public DbSet<StatisticalNumbersTranslation> statistical_numbers_translations_20ts24tu { get; set; }
        public DbSet<AppealToEmployee> appeal_to_employee_20ts24tu { get; set; }
        public DbSet<AppealToEmployeeTranslation> appeal_to_employee_translation_20ts24tu { get; set; }

    }



}
