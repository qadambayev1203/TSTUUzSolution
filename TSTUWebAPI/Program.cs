using Contracts;
using Contracts.AllRepository.AppealsToRectorRepository;
using Contracts.AllRepository.BlogsCategoryRepository;
using Contracts.AllRepository.BlogsRepository;
using Contracts.AllRepository.CountriesRepository;
using Contracts.AllRepository.DepartamentDetailsRepository;
using Contracts.AllRepository.DepartamentsRepository;
using Contracts.AllRepository.DepartamentsTypeRepository;
using Contracts.AllRepository.DistrictsRepository;
using Contracts.AllRepository.EmploymentsRepsitory;
using Contracts.AllRepository.FilesRepository;
using Contracts.AllRepository.GendersRepository;
using Contracts.AllRepository.LanguagesRepository;
using Contracts.AllRepository.MenuesRepository;
using Contracts.AllRepository.MenuTypesRepository;
using Contracts.AllRepository.NeighborhoodsRepository;
using Contracts.AllRepository.PagesRepository;
using Contracts.AllRepository.PersonsRepository;
using Contracts.AllRepository.SiteDetailsRepository;
using Contracts.AllRepository.SitesRepository;
using Contracts.AllRepository.SiteTypesRepository;
using Contracts.AllRepository.StatusesRepository;
using Contracts.AllRepository.TerritoriesRepository;
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
using Repository.AllSqlRepository.EmploymentsSqlRepository;
using Repository.AllSqlRepository.FilesSqlRepository;
using Repository.AllSqlRepository.GendersSqlRepository;
using Repository.AllSqlRepository.LanguagesSqlRepository;
using Repository.AllSqlRepository.MenuesSqlRepository;
using Repository.AllSqlRepository.MenuTypesSqlRepository;
using Repository.AllSqlRepository.NeighborhoodsSqlRepository;
using Repository.AllSqlRepository.PagesSqlRepository;
using Repository.AllSqlRepository.PersonsSqlRepository;
using Repository.AllSqlRepository.SiteDetailsSqlRepository;
using Repository.AllSqlRepository.SitesSqlRepository;
using Repository.AllSqlRepository.SiteTypesSqlRepository;
using Repository.AllSqlRepository.StatusesSqlRepository;
using Repository.AllSqlRepository.TerritoriesSqlRepository;
using Repository.AllSqlRepository.UsersSqlRepository;
using Repository.AllSqlRepository.UserTypesSqlRepository;
using System.Text;
using TSTUWebAPI.Controllers.FileControllers;

var builder = WebApplication.CreateBuilder(args);
var Configuration = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json")
      .Build();



// Add services to the container.


#region JWT
IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
AppSettings appSettings = appSettingsSection.Get<AppSettings>();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Example enter like this => Bearer nbkgtrnnhnuihnggfnhbnfnthngtrhn",
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
#endregion

#region DB
builder.Services.AddDbContext<RepositoryContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")
               ));
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

//Status AND StatusTranslation
builder.Services.AddScoped<IStatusRepository, StatusSqlRepository>();

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

//AppealToRector AND AppealToRectorTranslation
builder.Services.AddScoped<IAppealToRectorRepository, AppealToRectorSqlRepository>();

//MenuType AND MenuTypeTranslation
builder.Services.AddScoped<IMenuTypeRepository, MenuTypeSqlRepository>();

//Menu AND MenuTranslation
builder.Services.AddScoped<IMenuRepository, MenuSqlRepository>();

#endregion


#region AnyServices

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


builder.Services.AddScoped<FileUploadRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin().AllowAnyHeader());
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion


#region Midddlware
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TSTUWebAPI v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion