using Contracts;
using Contracts.AllRepository.BlogsCategoryRepository;
using Contracts.AllRepository.BlogsRepository;
using Contracts.AllRepository.DepartamentDetailsRepository;
using Contracts.AllRepository.DepartamentsRepository;
using Contracts.AllRepository.DepartamentsTypeRepository;
using Contracts.AllRepository.FilesRepository;
using Contracts.AllRepository.GendersRepository;
using Contracts.AllRepository.LanguagesRepository;
using Contracts.AllRepository.PagesRepository;
using Contracts.AllRepository.PersonsRepository;
using Contracts.AllRepository.SiteDetailsRepository;
using Contracts.AllRepository.SitesRepository;
using Contracts.AllRepository.SiteTypesRepository;
using Contracts.AllRepository.StatusesRepository;
using Contracts.AllRepository.UsersRepository;
using Contracts.AllRepository.UserTypesRepository;
using Entities;
using Entities.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.AllSqlRepository.BlogsCategorySqlRepository;
using Repository.AllSqlRepository.BlogsSqlRepository;
using Repository.AllSqlRepository.DepartamentsDetailSqlRepository;
using Repository.AllSqlRepository.DepartamentsSqlRepository;
using Repository.AllSqlRepository.DepartamentsTypeSqlRepository;
using Repository.AllSqlRepository.FilesSqlRepository;
using Repository.AllSqlRepository.GendersSqlRepository;
using Repository.AllSqlRepository.LanguagesSqlRepository;
using Repository.AllSqlRepository.PagesSqlRepository;
using Repository.AllSqlRepository.PersonsSqlRepository;
using Repository.AllSqlRepository.SiteDetailsSqlRepository;
using Repository.AllSqlRepository.SitesSqlRepository;
using Repository.AllSqlRepository.SiteTypesSqlRepository;
using Repository.AllSqlRepository.StatusesSqlRepository;
using Repository.AllSqlRepository.UsersSqlRepository;
using Repository.AllSqlRepository.UserTypesSqlRepository;
using System.Text;
using TSTUWebAPI.Controllers.FileControllers;

var builder = WebApplication.CreateBuilder(args);
var Configuration = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json")
      .Build();



// Add services to the container.


//JWT**************************************************
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
//*****************************************************



builder.Services.AddDbContext<RepositoryContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")
               ));
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



































































builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:5500")
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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