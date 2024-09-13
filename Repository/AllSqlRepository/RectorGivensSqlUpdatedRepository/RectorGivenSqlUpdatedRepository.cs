using Contracts.AllRepository.RectorGivensUpdatedRepository;
using Entities.Model.DepartamentsModel;
using Entities.Model.PersonDataModel;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.Extensions.Logging;
using Repository.AllSqlRepository.DepartamentsSqlRepository;
using Newtonsoft.Json;
using Entities.Model.AnyClasses;

namespace Repository.AllSqlRepository.RectorGivensSqlUpdatedRepository;

public class RectorGivenSqlUpdatedRepository : IRectorGivenUpdatedRepository
{

    private readonly RepositoryContext _context;
    private readonly ILogger<RectorGivenSqlUpdatedRepository> _logger;
    public RectorGivenSqlUpdatedRepository(RepositoryContext repositoryContext, ILogger<RectorGivenSqlUpdatedRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }


    //RectorGiven CRUD
    public Departament GetRectorGiven()
    {
        try
        {
            int rectorat_id = 1;
            var departament = _context.departament_20ts24tu
                .Where(x => x.status_.status != "Deleted")
                .Include(x => x.img_)
                .Include(x => x.img_icon_)
                .FirstOrDefault(x => x.id.Equals(rectorat_id));

            return departament ?? new Departament();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return new Departament();
        }
    }
    public bool UpdateRectorGiven(Departament departament)
    {
        try
        {
            var dbcheck = GetRectorGiven();
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.title_short = departament.title_short;
            dbcheck.title = departament.title;
            dbcheck.description = departament.description;
            dbcheck.text = departament.text;
            dbcheck.updated_at = DateTime.UtcNow;
            if (departament.img_ != null)
            {
                dbcheck.img_ = departament.img_;
            }
            if (departament.img_icon_ != null)
            {
                dbcheck.img_icon_ = departament.img_icon_;
            }

            dbcheck.favorite = departament.favorite;

            _context.SaveChanges();

            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return false;
        }
    }

    //RectorGivenTranslation CRUD
    public DepartamentTranslation GetRectorGivenTranslation(string language_code)
    {
        try
        {
            int rectorat_uz_id = 1;

            var departamentTranslation = _context.departament_translations_20ts24tu
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Include(x => x.language_)
                    .Include(x => x.img_)
                    .Include(x => x.img_icon_)
                    .FirstOrDefault(x =>
                            x.departament_id.Equals(rectorat_uz_id) && x.language_.code.Equals(language_code));

            return departamentTranslation ?? new DepartamentTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return new DepartamentTranslation();
        }
    }
    public bool UpdateRectorGivenTranslation(DepartamentTranslation departament, string language_code)
    {
        try
        {
            var dbcheck = GetRectorGivenTranslation(language_code);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.title_short = departament.title_short;
            dbcheck.title = departament.title;
            dbcheck.description = departament.description;
            dbcheck.text = departament.text;
            dbcheck.language_id = departament.language_id;
            dbcheck.updated_at = departament.updated_at;
            if (departament.img_ != null)
            {
                dbcheck.img_ = departament.img_;
            }
            if (departament.img_icon_ != null)
            {
                dbcheck.img_icon_ = departament.img_icon_;
            }
            dbcheck.favorite = departament.favorite;

            _context.SaveChanges();

            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return false;
        }
    }



    //RectorData CRUD
    public PersonData GetRectorData()
    {
        try
        {
            int rector_id = 1;

            var personData = _context.persons_data_20ts24tu
                    .Where(x => x.status_.status != "Deleted")
                    .Include(x => x.persons_).ThenInclude(y => y.img_)
                    .Include(x => x.persons_).ThenInclude(y => y.gender_)
                    .FirstOrDefault(x => x.id.Equals(rector_id));
            return personData ?? new PersonData();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonData();
        }
    }
    public bool UpdateRectorData(PersonData rectorData)
    {
        try
        {
            var dbcheck = GetRectorData();
            if (dbcheck is null) return false;

            if (rectorData.birthday != null)
            {
                DateTime utcDateTime = DateTime.SpecifyKind(DateTime.Parse(rectorData.birthday.ToString()), DateTimeKind.Local).ToUniversalTime();
                rectorData.birthday = utcDateTime;
            }

            dbcheck.persons_.firstName = rectorData.persons_.firstName;
            dbcheck.persons_.lastName = rectorData.persons_.lastName;
            dbcheck.persons_.fathers_name = rectorData.persons_.fathers_name;
            dbcheck.persons_.email = rectorData.persons_.email;
            dbcheck.persons_.gender_id = rectorData.persons_.gender_id;
            dbcheck.persons_.pinfl = rectorData.persons_.pinfl;
            dbcheck.persons_.passport_text = rectorData.persons_.passport_text;
            dbcheck.persons_.passport_number = rectorData.persons_.passport_number;
            if (rectorData.persons_.img_ != null) dbcheck.persons_.img_ = rectorData.persons_.img_;

            dbcheck.biography_json = rectorData.biography_json;
            dbcheck.birthday = rectorData.birthday;
            dbcheck.degree = rectorData.degree;
            dbcheck.scientific_title = rectorData.scientific_title;
            dbcheck.experience_year = rectorData.experience_year;
            dbcheck.phone_number1 = rectorData.phone_number1;
            dbcheck.phone_number2 = rectorData.phone_number2;
            dbcheck.orchid = rectorData.orchid;
            dbcheck.scopus_id = rectorData.scopus_id;
            dbcheck.address = rectorData.address;
            dbcheck.languages_uz = rectorData.languages_uz;
            dbcheck.languages_en = rectorData.languages_en;
            dbcheck.languages_ru = rectorData.languages_ru;
            dbcheck.languages_any_title = rectorData.languages_any_title;
            dbcheck.languages_any = rectorData.languages_any;


            _context.SaveChanges();

            _logger.LogInformation($"Updated {JsonConvert.SerializeObject(dbcheck)}");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error {ex}");
            return false;
        }
    }

    //PersonDataTranslation CRUD
    public PersonDataTranslation GetRectorDataTranslation(string language_code)
    {
        try
        {
            int rector_uz_id = 1;
            var personDataTranslation = _context.persons_data_translations_20ts24tu
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Include(x => x.language_)
                    .Include(x => x.persons_data_)
                    .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                                    .FirstOrDefault(x =>
                                        x.persons_data_id.Equals(rector_uz_id) && x.language_.code.Equals(language_code));
            return personDataTranslation ?? new PersonDataTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonDataTranslation();
        }
    }
    public bool UpdateRectorDataTranslation(PersonDataTranslation rectorData, string language_code)
    {
        try
        {
            var dbcheck = GetRectorDataTranslation(language_code);
            if (dbcheck is null)
            {
                return false;
            }

            DateTime localDateTime = DateTime.Parse(rectorData.birthday.ToString());
            localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
            DateTime utcDateTime = localDateTime.ToUniversalTime();

            rectorData.birthday = utcDateTime;
            rectorData.persons_translation_.language_id = rectorData.language_id;

            dbcheck.persons_translation_.firstName = rectorData.persons_translation_.firstName;
            dbcheck.persons_translation_.lastName = rectorData.persons_translation_.lastName;
            dbcheck.persons_translation_.fathers_name = rectorData.persons_translation_.fathers_name;
            dbcheck.persons_translation_.gender_id = rectorData.persons_translation_.gender_id;
            dbcheck.persons_translation_.language_id = dbcheck.language_id;

            dbcheck.biography_json = rectorData.biography_json;
            dbcheck.birthday = rectorData.birthday;
            dbcheck.degree = rectorData.degree;
            dbcheck.scientific_title = rectorData.scientific_title;
            dbcheck.experience_year = rectorData.experience_year;
            dbcheck.phone_number1 = rectorData.phone_number1;
            dbcheck.phone_number2 = rectorData.phone_number2;
            dbcheck.orchid = rectorData.orchid;
            dbcheck.scopus_id = rectorData.scopus_id;
            dbcheck.address = rectorData.address;
            dbcheck.languages_uz = rectorData.languages_uz;
            dbcheck.languages_en = rectorData.languages_en;
            dbcheck.languages_ru = rectorData.languages_ru;
            dbcheck.languages_any_title = rectorData.languages_any_title;
            dbcheck.languages_any = rectorData.languages_any;
            dbcheck.language_id = rectorData.language_id;



            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }
}
