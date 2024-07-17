#region Library

using Contracts;
using Contracts.AllRepository.AppealsToRectorRepository;
using Contracts.AllRepository.BlogsCategoryRepository;
using Contracts.AllRepository.BlogsRepository;
using Contracts.AllRepository.CountriesRepository;
using Contracts.AllRepository.DepartamentDetailsRepository;
using Contracts.AllRepository.DepartamentsRepository;
using Contracts.AllRepository.DepartamentsTypeRepository;
using Contracts.AllRepository.DistrictsRepository;
using Contracts.AllRepository.EmployeesRepository;
using Contracts.AllRepository.EmploymentsRepsitory;
using Contracts.AllRepository.FilesRepository;
using Contracts.AllRepository.GendersRepository;
using Contracts.AllRepository.StatisticalNumbersRepository;
using Contracts.AllRepository.InteractiveServicesRepository;
using Contracts.AllRepository.LanguagesRepository;
using Contracts.AllRepository.MenuesRepository;
using Contracts.AllRepository.MenuTypesRepository;
using Contracts.AllRepository.NeighborhoodsRepository;
using Contracts.AllRepository.PagesRepository;
using Contracts.AllRepository.PersonsDataRepository;
using Contracts.AllRepository.PersonsRepository;
using Contracts.AllRepository.SiteDetailsRepository;
using Contracts.AllRepository.SitesRepository;
using Contracts.AllRepository.SiteTypesRepository;
using Contracts.AllRepository.StatusesRepository;
using Contracts.AllRepository.TerritoriesRepository;
using Contracts.AllRepository.TokensRepository;
using Contracts.AllRepository.UsersRepository;
using Contracts.AllRepository.UserTypesRepository;
using Entities;
using Entities.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.AllSqlRepository.AppealsToRectorSqlRepository;
using Repository.AllSqlRepository.BlogsCategorySqlRepository;
using Repository.AllSqlRepository.BlogsSqlRepository;
using Repository.AllSqlRepository.CountriesSqlRepository;
using Repository.AllSqlRepository.DepartamentsDetailSqlRepository;
using Repository.AllSqlRepository.DepartamentsSqlRepository;
using Repository.AllSqlRepository.DepartamentsTypeSqlRepository;
using Repository.AllSqlRepository.DistrictsSqlRepository;
using Repository.AllSqlRepository.EmployeeTypesSqlRepository;
using Repository.AllSqlRepository.EmploymentsSqlRepository;
using Repository.AllSqlRepository.FilesSqlRepository;
using Repository.AllSqlRepository.GendersSqlRepository;
using Repository.AllSqlRepository.InteractivesServicesSqlRepository;
using Repository.AllSqlRepository.LanguagesSqlRepository;
using Repository.AllSqlRepository.MenuesSqlRepository;
using Repository.AllSqlRepository.MenuTypesSqlRepository;
using Repository.AllSqlRepository.NeighborhoodsSqlRepository;
using Repository.AllSqlRepository.PagesSqlRepository;
using Repository.AllSqlRepository.PersonDatasDataSqlRepository;
using Repository.AllSqlRepository.PersonsSqlRepository;
using Repository.AllSqlRepository.SiteDetailsSqlRepository;
using Repository.AllSqlRepository.SitesSqlRepository;
using Repository.AllSqlRepository.SiteTypesSqlRepository;
using Repository.AllSqlRepository.StatusesSqlRepository;
using Repository.AllSqlRepository.TerritoriesSqlRepository;
using Repository.AllSqlRepository.TokensSqlRepository;
using Repository.AllSqlRepository.UsersSqlRepository;
using Repository.AllSqlRepository.UserTypesSqlRepository;
using Serilog;
using System.Text;
using TSTUWebAPI.Captcha;
using TSTUWebAPI.Controllers.FileControllers;
using Repository.AllSqlRepository.StatisticalsNumbersSqlRepository;
using Contracts.AllRepository.FrontLogFilesRepository;
using Repository.AllSqlRepository.FrontLogFilesSqlRepository;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Configuration;
using System;
using Entities.Model.AnyClasses;
using Contracts.AllRepository.ProfilsRepository;
using Repository.AllSqlRepository.ProfilsSqlRepopsitory;

#endregion

try
{
    var builder = WebApplication.CreateBuilder(args);
    var Configuration = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json")
          .Build();


    #region JWT
    IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
    builder.Services.Configure<AppSettings>(appSettingsSection);
    AppSettings appSettings = appSettingsSection.Get<AppSettings>();
    var secretKey = Encoding.ASCII.GetBytes(appSettings.SecretKey);

    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKey),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });
    #endregion

    #region Swagger

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });


        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "Example enter like this => Bearer 'token'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                       new OpenApiSecurityScheme
                       {
                           Reference=new OpenApiReference
                           {
                               Type = ReferenceType.SecurityScheme,
                               Id = "Bearer",
                           },
                       },
                       Array.Empty<string>()
                    },
                });
    });
    builder.Services.AddSwaggerGen();
    #endregion

    #region DB

    string? connectionString = builder.Environment.IsDevelopment()
        ? builder.Configuration.GetConnectionString("DefaultConnection")
        : builder.Configuration.GetConnectionString("DefaultConnectionServer");

    builder.Services.AddDbContext<RepositoryContext>(options =>
                options.UseNpgsql(connectionString)
                   );
    #endregion

    #region RepositorysServices
    builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

    //Gender AND GenderTranslation
    builder.Services.AddScoped<IGenderRepository, GenderSqlRepository>();

    //File AND FileTranslation
    builder.Services.AddScoped<IFileRepository, FileSqlRepository>();

    //Language
    builder.Services.AddScoped<ILanguageRepository, LanguageSqlRepository>();

    //Person AND PersonTranslation
    builder.Services.AddScoped<IPersonRepository, PersonSqlRepository>();

    //PersonData AND PersonDataTranslation
    builder.Services.AddScoped<IPersonDataRepository, PersonDataSqlRepository>();

    //Status AND StatusTranslation
    builder.Services.AddScoped<IStatusRepository, StatusSqlRepository>();
    builder.Services.AddScoped<IStatusRepositoryStatic, StatusSqlRepositoryStatic>();

    //UserType AND UserTypeTranslation
    builder.Services.AddScoped<IUserTypeRepository, UserTypeSqlRepository>();

    //User AND UserTranslation
    builder.Services.AddScoped<IUserRepository, UserSqlRepository>();

    //Departament AND DepartamentTranslation
    builder.Services.AddScoped<IDepartamentRepository, DepartamentSqlRepository>();

    //DepartamentType AND DepartamentTypeTranslation
    builder.Services.AddScoped<IDepartamentTypeRepository, DepartamentTypeSqlRepository>();

    //DepartamentDetail AND DepartamentDetailTranslation
    builder.Services.AddScoped<IDepartamentDetailRepository, DepartamentDetailSqlRepository>();

    //Page AND PageTranslation
    builder.Services.AddScoped<IPageRepository, PageSqlRepository>();

    //Site AND SiteTranslation
    builder.Services.AddScoped<ISiteRepository, SiteSqlRepository>();

    //SiteType AND SiteTypeTranslation
    builder.Services.AddScoped<ISiteTypeRepository, SiteTypeRepository>();

    //SiteDetail AND SiteDetailTranslation
    builder.Services.AddScoped<ISiteDetailRepository, SiteDetailSqlRepository>();

    //BlogCategory AND BlogCategoryTranslation
    builder.Services.AddScoped<IBlogCategoryRepository, BlogCategorySqlRepository>();

    //Blog AND BlogTranslation
    builder.Services.AddScoped<IBlogRepository, BlogSqlRepository>();

    //Country AND CountryTranslation
    builder.Services.AddScoped<ICountryRepository, CountrySqlRepository>();

    //Territorie AND TerritorieTranslation
    builder.Services.AddScoped<ITerritorieRepository, TerritorieSqlRepository>();

    //District AND DistrictTranslation
    builder.Services.AddScoped<IDistrictRepository, DistrictSqlRepository>();

    //Neighborhood AND NeighborhoodTranslation
    builder.Services.AddScoped<INeighborhoodRepository, NeighborhoodSqlRepository>();

    //Employment AND EmploymentTranslation
    builder.Services.AddScoped<IEmploymentRepository, EmploymentSqlRepository>();

    //EmployeeType AND EmployeeTypeTranslation
    builder.Services.AddScoped<IEmployeeTypeRepository, EmployeeTypeSqlRepository>();

    //AppealToRector AND AppealToRectorTranslation
    builder.Services.AddScoped<IAppealToRectorRepository, AppealToRectorSqlRepository>();

    //MenuType AND MenuTypeTranslation
    builder.Services.AddScoped<IMenuTypeRepository, MenuTypeSqlRepository>();

    //Menu AND MenuTranslation
    builder.Services.AddScoped<IMenuRepository, MenuSqlRepository>();

    //Tokens AND TokensTranslation
    builder.Services.AddScoped<ITokensRepository, TokenSqlRepository>();

    //InteractiveServices AND InteractiveServicesTranslation
    builder.Services.AddScoped<IInteractiveServicesRepository, InteractiveServicesSqlRepository>();

    //StatisticalNumbers AND StatisticalNumbersTranslation
    builder.Services.AddScoped<IStatisticalNumbersRepository, StatisticalNumbersSqlRepository>();

    //FrontLogFiles
    builder.Services.AddScoped<IFrontLogFileRepository, FrontLogFileSqlRepository>();
    
    //UserProfils
    builder.Services.AddScoped<IProfilRepository, ProfilSqlRepository>();

    #endregion

    #region AnyServices

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins("http://sayt.tstu.uz")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
    });

    builder.Services.AddScoped<FileUploadRepository>();

    builder.Services.AddScoped<CaptchaCheck>();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddControllers();

    //builder.Services.AddCors(opt =>
    //{
    //    opt.AddPolicy("CorsPolicy", builder =>
    //    builder.AllowAnyOrigin().AllowAnyHeader());
    //});


    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();


    #endregion

    #region Midddlware

    var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .Enrich.WithProperty("Application", "TSTUUzWebAPI")
        .CreateLogger();

    builder.Logging.ClearProviders();

    builder.Logging.AddSerilog(logger);

    builder.Services.AddControllers();

    builder.Services.AddDirectoryBrowser();



    var app = builder.Build();

    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "TSTUWebAPI v1");
        }
        );


    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();

    app.UseAuthorization();

    //app.UseCors("AllowSpecificOrigin");
    app.UseCors("AllowAllOrigins");

    app.MapControllers();

    var fileUploadsPath = Path.Combine(app.Environment.ContentRootPath, "file-uploads");

    if (!Directory.Exists(fileUploadsPath))
    {
        Directory.CreateDirectory(fileUploadsPath);
    }

    var fileProvider = new PhysicalFileProvider(fileUploadsPath);

    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = fileProvider,
        RequestPath = "/file-uploads",
        OnPrepareResponse = ctx =>
        {
            var fileExtension = Path.GetExtension(ctx.File.PhysicalPath);

            if (!SessionClass.allowedExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
            {
                ctx.Context.Response.StatusCode = StatusCodes.Status403Forbidden;
                ctx.Context.Response.ContentLength = 0;
                ctx.Context.Response.Body = Stream.Null;
            }
        }
    });

    app.Run();





    #endregion

}
catch (Exception ex)
{
    Log.Fatal(ex.Message);
    throw;
}