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

    public List<PersonData> GetRectoratData()
    {
        try
        {
            var personData = _context.persons_data_20ts24tu
                    .Where(x => x.status_.status != "Deleted")
                    .Where(x => x.persons_.employee_type_.title == "Rektor" ||
                                x.persons_.employee_type_.title == "Prorektor")
                    .Include(x => x.persons_).ThenInclude(y => y.img_)
                    .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                    .Include(x => x.persons_).ThenInclude(y => y.gender_)
                    .ToList();
            return personData ?? new List<PersonData>();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new List<PersonData>();
        }
    }
    public PersonData GetByIdRectoratData(int id)
    {
        try
        {
            var personData = _context.persons_data_20ts24tu
                    .Where(x => x.status_.status != "Deleted")
                    .Where(x => x.persons_.employee_type_.title == "Rektor" ||
                                x.persons_.employee_type_.title == "Prorektor")
                    .Include(x => x.persons_).ThenInclude(y => y.img_)
                    .Include(x => x.persons_).ThenInclude(y => y.employee_type_)
                    .Include(x => x.persons_).ThenInclude(y => y.gender_)
                    .FirstOrDefault(x => x.id.Equals(id));
            return personData ?? new PersonData();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonData();
        }
    }
    public bool UpdateRectorData(PersonData rectorData, int id)
    {
        try
        {
            var dbcheck = GetByIdRectoratData(id);
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


    public List<PersonDataTranslation> GetRectoratDataTranslation(string language_code)
    {
        try
        {
            var personDataTranslation = _context.persons_data_translations_20ts24tu
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where(x => x.language_.code.Equals(language_code))
                    .Where(x => x.persons_data_.persons_.employee_type_.title == "Rektor" ||
                                x.persons_data_.persons_.employee_type_.title == "Prorektor")
                    .Include(x => x.language_)
                    .Include(x => x.persons_data_)
                    .Include(x => x.persons_translation_).ThenInclude(y => y.gender_).ToList();

            return personDataTranslation ?? new List<PersonDataTranslation>();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new List<PersonDataTranslation>();
        }
    }
    public PersonDataTranslation GetByIdRectoratDataTranslation(int uz_id, string language_code)
    {
        try
        {
            var personDataTranslation = _context.persons_data_translations_20ts24tu
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where(x => x.persons_data_.persons_.employee_type_.title == "Rektor" ||
                                x.persons_data_.persons_.employee_type_.title == "Prorektor")
                    .Include(x => x.language_)
                    .Include(x => x.persons_data_)
                    .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                                    .FirstOrDefault(x =>
                                        x.persons_data_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return personDataTranslation ?? new PersonDataTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonDataTranslation();
        }
    }

    public bool UpdateRectoratDataTranslation(PersonDataTranslation rectorData, int id)
    {
        try
        {
            var dbcheck = GetByIdRectoratDataTranslationCheck(id);
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

            _context.SaveChanges();

            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public PersonDataTranslation GetByIdRectoratDataTranslationCheck(int id)
    {
        try
        {
            var personDataTranslation = _context.persons_data_translations_20ts24tu
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where(x => x.persons_data_.persons_.employee_type_.title == "Rektor" ||
                                x.persons_data_.persons_.employee_type_.title == "Prorektor")
                    .Include(x => x.language_)
                    .Include(x => x.persons_data_)
                    .Include(x => x.persons_translation_).ThenInclude(y => y.gender_)
                                    .FirstOrDefault(x => x.id.Equals(id));
            return personDataTranslation ?? new PersonDataTranslation();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new PersonDataTranslation();
        }
    }
}
