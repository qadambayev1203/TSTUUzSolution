using Contracts.AllRepository.PersonsRepository;
using Entities;
using Entities.Model.PersonModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Repository.AllSqlRepository.PersonsSqlRepository;

public class PersonSqlRepository : IPersonRepository
{


    private readonly RepositoryContext _context;
    private readonly ILogger<PersonSqlRepository> _logger;
    public PersonSqlRepository(RepositoryContext repositoryContext, ILogger<PersonSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }


    //Person CRUD
    public IEnumerable<Person> AllPersonSite(int queryNum, int pageNum)
    {
        try
        {
            var persons = new List<Person>();
            if (queryNum == 0 && pageNum != 0)
            {
                persons = _context.persons_20ts24tu.Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_)
                    .Include(y => y.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.employee_type_)
                    .Where(x => x.status_.status != "Deleted").Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                persons = _context.persons_20ts24tu.Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_)
                    .Include(y => y.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.employee_type_)
                    .Where(x => x.status_.status != "Deleted").Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();

            }
            else
            {
                persons = _context.persons_20ts24tu.Include(x => x.gender_).Where(x => x.status_.status != "Deleted").Include(x => x.status_).Include(x => x.img_)
                    .Include(x => x.employee_type_)
                    .Include(y => y.departament_).ThenInclude(y => y.departament_type_)
                    .ToList();

            }
            return persons;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<Person>();
        }
    }
    public IEnumerable<Person> AllPerson(int queryNum, int pageNum)
    {
        try
        {
            var persons = new List<Person>();
            if (queryNum == 0 && pageNum != 0)
            {
                persons = _context.persons_20ts24tu.Include(y => y.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_)
                    .Include(x => x.employee_type_)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                persons = _context.persons_20ts24tu
                    .Include(y => y.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_)
                    .Include(x => x.employee_type_)
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();

            }
            else
            {
                persons = _context.persons_20ts24tu.Include(y => y.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.employee_type_)
                    .Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_)
                    .ToList();

            }
            return persons;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<Person>();
        }
    }

    public int CreatePerson(Person person)
    {
        try
        {
            if (person == null)
            {
                return 0;
            }
            person.created_at = DateTime.UtcNow;
            _context.persons_20ts24tu.Add(person);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(person));

            return person.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeletePerson(int id)
    {
        try
        {
            var person = GetPersonById(id);
            if (person == null)
            {
                return false;
            }
            person.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.persons_20ts24tu.Update(person);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(person));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public Person GetPersonByIdSite(int id)
    {
        try
        {
            var person = _context.persons_20ts24tu.Where(x => x.status_.status != "Deleted")
                    .Include(x => x.employee_type_)
                .Include(y => y.departament_).ThenInclude(y => y.departament_type_)
                .Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_).FirstOrDefault(x => x.id.Equals(id));
            return person;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public Person GetPersonById(int id)
    {
        try
        {
            var person = _context.persons_20ts24tu
                    .Include(x => x.employee_type_)
                .Include(y => y.departament_).ThenInclude(y => y.departament_type_)
                .Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_).FirstOrDefault(x => x.id.Equals(id));
            return person;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdatePerson(int id, Person person)
    {

        try
        {
            var dbcheck = GetPersonById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.firstName = person.firstName;
            dbcheck.lastName = person.lastName;
            dbcheck.fathers_name = person.fathers_name;
            dbcheck.email = person.email;
            dbcheck.gender_id = person.gender_id;
            dbcheck.pinfl = person.pinfl;
            dbcheck.passport_text = person.passport_text;
            dbcheck.passport_number = person.passport_number;
            dbcheck.status_id = person.status_id;
            if (person.img_ != null)
            {
                dbcheck.img_ = person.img_;
            }

            dbcheck.departament_id = person.departament_id;
            dbcheck.employee_type_id = person.employee_type_id;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }






    //PersonTranslation CRUD
    public IEnumerable<PersonTranslation> AllPersonTranslationSite(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var personsTranslation = new List<PersonTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                personsTranslation = _context.persons_translations_20ts24tu.Include(x => x.gender_).Include(x => x.language_)
                    .Include(y => y.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                    .Include(x => x.persons_).ThenInclude(y => y.img_)
                    .Include(x => x.employee_type_translation_)
                    .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                personsTranslation = _context.persons_translations_20ts24tu.Include(x => x.gender_)
                    .Include(y => y.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                    .Include(x => x.employee_type_translation_)
                     .Include(x => x.language_).Where(x => x.status_translation_.status != "Deleted").Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                     .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();

            }
            else
            {
                personsTranslation = _context.persons_translations_20ts24tu.Include(x => x.gender_)
                    .Include(y => y.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                    .Include(x => x.employee_type_translation_)
                    .Include(x => x.language_).Where(x => x.status_translation_.status != "Deleted").Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                      .ToList();

            }
            return personsTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<PersonTranslation>();
        }
    }
    public IEnumerable<PersonTranslation> AllPersonTranslation(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var personsTranslation = new List<PersonTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                personsTranslation = _context.persons_translations_20ts24tu.Include(x => x.gender_).Include(x => x.language_)
                    .Include(x => x.persons_).ThenInclude(y => y.img_)
                    .Include(y => y.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                    .Include(x => x.employee_type_translation_)
                    .Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                personsTranslation = _context.persons_translations_20ts24tu.Include(x => x.gender_)
                    .Include(x => x.employee_type_translation_)
                    .Include(y => y.departament_translation_).ThenInclude(y => y.departament_type_translation_).
                    Include(x => x.language_).Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                     .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();

            }
            else
            {
                personsTranslation = _context.persons_translations_20ts24tu.Include(x => x.gender_)
                    .Include(y => y.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                    .Include(x => x.employee_type_translation_)
                    .Include(x => x.language_).Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                      .ToList();

            }
            return personsTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<PersonTranslation>();
        }
    }

    public int CreatePersonTranslation(PersonTranslation personTranslation)
    {
        try
        {
            if (personTranslation == null)
            {
                return 0;
            }
            _context.persons_translations_20ts24tu.Add(personTranslation);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(personTranslation));

            return personTranslation.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeletePersonTranslation(int id)
    {
        try
        {
            var personTranslation = GetPersonTranslationById(id);
            if (personTranslation == null)
            {
                return false;
            }
            personTranslation.status_translation_id = (_context.statuses_translations_20ts24tu
                .FirstOrDefault(x => x.status == "Deleted" && x.language_id == personTranslation.language_id)).id;
            _context.persons_translations_20ts24tu.Update(personTranslation);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(personTranslation));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public PersonTranslation GetPersonTranslationByIdSite(int id)
    {
        try
        {
            var personTranslation = _context.persons_translations_20ts24tu.Where(x => x.status_translation_.status != "Deleted")
                    .Include(x => x.employee_type_translation_)
                .Include(y => y.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                .Include(x => x.gender_).Include(x => x.language_).Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
            return personTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public PersonTranslation GetPersonTranslationById(int id)
    {
        try
        {
            var personTranslation = _context.persons_translations_20ts24tu
                    .Include(x => x.employee_type_translation_)
                .Include(y => y.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                .Include(x => x.gender_).Include(x => x.language_).Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
            return personTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public PersonTranslation GetPersonTranslationById(int uz_id, string language_code)
    {
        try
        {
            var personTranslation = _context.persons_translations_20ts24tu
                    .Include(x => x.employee_type_translation_)
                .Include(y => y.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                .Include(x => x.gender_).Include(x => x.language_).Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.status_translation_).FirstOrDefault(x => x.persons_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return personTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public PersonTranslation GetPersonTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var personTranslation = _context.persons_translations_20ts24tu
                    .Include(x => x.employee_type_translation_)
                .Include(y => y.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                .Include(x => x.gender_).Include(x => x.language_).Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.status_translation_)
                .Where(x => x.status_translation_.status != "Deleted")
                .FirstOrDefault(x => x.persons_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return personTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdatePersonTranslation(int id, PersonTranslation person)
    {

        try
        {
            var dbcheck = GetPersonTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.firstName = person.firstName;
            dbcheck.lastName = person.lastName;
            dbcheck.fathers_name = person.fathers_name;
            dbcheck.gender_id = person.gender_id;
            dbcheck.persons_id = person.persons_id;
            dbcheck.language_id = person.language_id;
            dbcheck.status_translation_id = person.status_translation_id;
            dbcheck.departament_translation_id = person.departament_translation_id;
            dbcheck.employee_type_translation_id = person.employee_type_translation_id;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }
    public bool SaveChanges()
    {
        try { _context.SaveChanges(); return true; }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message); return false;
        }
    }

}
