using Contracts.AllRepository.DocumentTeacher110Repository;
using Entities;
using Entities.Model.AnyClasses;
using Entities.Model.BlogsModel;
using Entities.Model.DocumentTeacher110Model;
using Entities.Model.PersonModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Repository.AllSqlRepository.DocumentsTeacher110SqlRepository;

public class DocumentsTeacher110SetSqlRepository : IDocumentTeacher110SetRepository
{
    private readonly RepositoryContext _context;
    private readonly ILogger<DocumentsTeacher110SetSqlRepository> _logger;
    public DocumentsTeacher110SetSqlRepository(RepositoryContext repositoryContext, ILogger<DocumentsTeacher110SetSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }


    #region Teacher

    public IEnumerable<DocumentTeacher110Set> AllDocumentTeacher110Set(int oldYear, int newYear)
    {
        try
        {
            var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
            int person_id;
            if (user != null && user.person_id != 0 && user.person_id != null)
            {
                person_id = user.person_id ??= 0;

            }
            else
            {
                return Enumerable.Empty<DocumentTeacher110Set>();
            }



            IQueryable<DocumentTeacher110Set> documentTeacher110 = _context.document_teacher_110_set_20ts24tu
               .Include(x => x.person_)
               .Include(x => x.file_)
               .Include(x => x.document_)
               .Include(x => x.assessor_).ThenInclude(y => y.user_type_)
               .Include(x => x.assessor_).ThenInclude(y => y.person_)
               .Where(x => x.person_id == person_id)
               .Where(x => x.status_.status != "Deleted" && x.document_id != SessionClass.staticDocumentId)
               .Where(x => x.old_year == oldYear && x.new_year == newYear);


            return documentTeacher110.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<DocumentTeacher110Set>();
        }
    }

    public double? GetTeacherDocumentScore(int oldYear, int newYear, int person_id)
    {
        try
        {
            if (person_id == 0)
            {
                var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);

                if (user != null && user.person_id != 0 && user.person_id != null)
                {
                    person_id = user.person_id ??= 0;
                }
                else
                {
                    return null;
                }
            }




            double? score = _context.document_teacher_110_set_20ts24tu
                    .Where(x => x.person_id == person_id)
                    .Where(x => x.status_.status != "Deleted")
                    .Where(x => x.old_year == oldYear && x.new_year == newYear)
                    .Sum(x => (double?)x.score);

            return score;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateDocumentTeacher110Set(DocumentTeacher110Set documentTeacher110Set)
    {
        try
        {
            if (documentTeacher110Set == null || documentTeacher110Set.document_id == SessionClass.staticDocumentId)
            {
                return 0;
            }

            var user = _context.users_20ts24tu.Include(x => x.user_type_).FirstOrDefault(x => x.id == SessionClass.id);
            int person_id;
            if (user != null && user.person_id != 0 && user.person_id != null)
            {
                person_id = user.person_id ??= 0;
            }
            else
            {
                return 0;
            }

            if (documentTeacher110Set.fixed_date != null)
            {
                DateTime localDateTime = DateTime.Parse(documentTeacher110Set.fixed_date.ToString());
                localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
                DateTime utcDateTime = localDateTime.ToUniversalTime();
                documentTeacher110Set.fixed_date = utcDateTime.AddDays(1);
            }


            if (user.user_type_.type != "Teacher")
            {
                return 0;
            }


            documentTeacher110Set.person_id = person_id;

            var document = _context.document_teacher_110_20ts24tu.FirstOrDefault(x => x.id == documentTeacher110Set.document_id);
            if (document.indicator == true)
            {
                return 0;
            }

            documentTeacher110Set.avtor = document.avtor;

            if (documentTeacher110Set.avtor == false || documentTeacher110Set.avtor == null)
            {
                documentTeacher110Set.number_authors = null;
            }

            _context.document_teacher_110_set_20ts24tu.Add(documentTeacher110Set);
            _context.SaveChanges();
            int id = documentTeacher110Set.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(documentTeacher110Set));
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public Tuple<bool, string> OptimizeDocument(int document_id, int person_id)
    {
        try
        {
            if (person_id == 0 || person_id == null)
            {
                var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                if (user != null && user.person_id != 0 && user.person_id != null)
                {
                    person_id = user.person_id ??= 0;
                }
                else
                {
                    return null;
                }
            }

            DocumentTeacher110 document = _context.document_teacher_110_20ts24tu
                .Where(x => x.status_.status != "Deleted").FirstOrDefault(x => x.id == document_id);

            if (document.indicator.Value) return Tuple.Create(true, "");

            List<DocumentTeacher110Set> documentTeacher110Set = _context.document_teacher_110_set_20ts24tu
                .Where(x => x.status_.status != "Deleted" && x.person_id == person_id)
                .Where(x => x.document_id.Equals(document_id))
                .ToList();

            double summ = 0;

            if (documentTeacher110Set != null)
            {
                foreach (var item in documentTeacher110Set)
                {
                    if (item.score > 0)
                    {
                        summ += item.score.Value;
                    }
                }
            }

            if (summ >= document.max_score) return Tuple.Create(false, "Bu turdagi hujjat limitingiz to'lgan");

            return Tuple.Create(true, "");
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Tuple.Create(true, "");
        }
    }

    public bool DeleteDocumentTeacher110Set(int id)
    {
        try
        {
            var documentTeacher110 = GetDocumentTeacher110SetById(id);
            if (documentTeacher110 == null)
            {
                return false;
            }
            if (documentTeacher110.sequence_status == 4)
            {
                return false;
            }
            documentTeacher110.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.document_teacher_110_set_20ts24tu.Update(documentTeacher110);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(documentTeacher110));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public DocumentTeacher110Set GetDocumentTeacher110SetById(int id)
    {
        try
        {
            var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
            int person_id;
            if (user != null && user.person_id != 0 && user.person_id != null)
            {
                person_id = user.person_id ??= 0;
            }
            else
            {
                return null;
            }

            var documentTeacher110 = _context.document_teacher_110_set_20ts24tu
                .Include(x => x.person_)
                .Include(x => x.file_)
                .Include(x => x.document_)
                .Where(x => x.status_.status != "Deleted" && x.person_id == person_id && x.document_id != SessionClass.staticDocumentId)
                .FirstOrDefault(x => x.id.Equals(id));

            return documentTeacher110 ?? new DocumentTeacher110Set();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new DocumentTeacher110Set();
        }
    }

    public bool UpdateDocumentTeacher110Set(int id, DocumentTeacher110Set documentTeacher110)
    {
        try
        {
            var dbcheck = GetDocumentTeacher110SetByIdAdmin(id);
            if (dbcheck is null || dbcheck.document_id == SessionClass.staticDocumentId)
            {
                return false;
            }

            if (dbcheck.sequence_status == 4)
            {
                return false;
            }

            if (documentTeacher110.fixed_date != null)
            {
                DateTime localDateTime = DateTime.Parse(documentTeacher110.fixed_date.ToString());
                localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
                DateTime utcDateTime = localDateTime.ToUniversalTime();
                documentTeacher110.fixed_date = utcDateTime.AddDays(1);
            }

            var document = _context.document_teacher_110_20ts24tu.FirstOrDefault(x => x.id == dbcheck.document_id);
            if (document.indicator == true)
            {
                return false;
            }

            documentTeacher110.avtor = document.avtor;

            if (documentTeacher110.avtor == false || documentTeacher110.avtor == null)
            {
                documentTeacher110.number_authors = null;
            }

            dbcheck.old_year = documentTeacher110.old_year;
            dbcheck.new_year = documentTeacher110.new_year;
            dbcheck.document_id = documentTeacher110.document_id;
            dbcheck.sequence_status = 2;
            dbcheck.rejection = false;
            dbcheck.reason_for_rejection = "";
            dbcheck.fixed_date = documentTeacher110.fixed_date;
            dbcheck.avtor = documentTeacher110.avtor;
            dbcheck.number_authors = documentTeacher110.number_authors;

            if (documentTeacher110.file_ != null)
            {
                dbcheck.file_ = documentTeacher110.file_;
            }
            dbcheck.comment = documentTeacher110.comment;


            _context.Update(dbcheck);
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

    public IEnumerable<DocumentTeacher110Set> GetDocumentTeacher110SetByDocumentId(int oldYear, int newYear, int document_id)
    {
        try
        {
            var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
            int person_id;
            if (user != null && user.person_id != 0 && user.person_id != null)
            {
                person_id = user.person_id ??= 0;
            }
            else
            {
                return null;
            }

            var documentTeacher110 = _context.document_teacher_110_set_20ts24tu
                .Include(x => x.person_)
                .Include(x => x.file_)
                .Include(x => x.document_)
                .Where(x => x.status_.status != "Deleted" && x.person_id == person_id)
                .Where(x => x.old_year == oldYear && x.new_year == newYear)
                .Where(x => x.document_id.Equals(document_id)).ToList();

            return documentTeacher110 ?? Enumerable.Empty<DocumentTeacher110Set>();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<DocumentTeacher110Set>();
        }
    }



    #endregion


    #region Admin

    public IEnumerable<Person> AllDocumentTeacher110SetAdmin(int oldYear, int newYear, int departament_id)
    {
        try
        {
            List<Person> personsIdList = _context.document_teacher_110_set_20ts24tu
             .Where(x => x.old_year == oldYear && x.new_year == newYear && x.person_id != null)
             .Where(x => x.person_.departament_id == departament_id)
             .Include(x => x.person_)
             .AsEnumerable()
             .GroupBy(x => x.person_id)
             .Select(g => g.First())
             .Select(x => new Person
             {
                 id = x.person_.id,
                 firstName = x.person_.firstName,
                 lastName = x.person_.lastName,
                 fathers_name = x.person_.fathers_name,
                 employee_type_id = 0,
                 departament_id = 0
             })
             .ToList();


            return personsIdList;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<Person>();
        }
    }

    public DocumentTeacher110SetList DocumentTeacher110SetAdmin(int oldYear, int newYear, int person_id)
    {
        try
        {

            var person = _context.persons_20ts24tu
                .Where(x => x.id == person_id)
                .Select(x => new Person
                {
                    id = x.id,
                    firstName = x.firstName,
                    lastName = x.lastName,
                    fathers_name = x.fathers_name,
                    employee_type_id = 0,
                    departament_id = 0
                }).FirstOrDefault();

            List<DocumentTeacher110Set> docList = AllDocumentTeacher110SetDocList(oldYear, newYear, person_id, true, 0).ToList();

            DocumentTeacher110SetList document = new DocumentTeacher110SetList()
            {
                person_ = person,
                documents_teacher_ = docList
            };


            return document;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new DocumentTeacher110SetList();
        }
    }

    public DocumentTeacher110Set GetDocumentTeacher110SetByIdAdmin(int id)
    {
        try
        {
            var documentTeacher110 = _context.document_teacher_110_set_20ts24tu
                .Include(x => x.person_)
                .Include(x => x.file_)
                .Include(x => x.document_)
                .Include(x => x.status_)
                .FirstOrDefault(x => x.id.Equals(id));

            return documentTeacher110 ?? new DocumentTeacher110Set();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new DocumentTeacher110Set();
        }
    }



    #endregion


    #region Head of Departament 

    public IEnumerable<Person> AllDocumentTeacher110SetConfirmationDepartament(int oldYear, int newYear)
    {
        try
        {
            var user = _context.users_20ts24tu.Include(x => x.person_).FirstOrDefault(x => x.id == SessionClass.id);
            if (user != null)
            {


                List<Person> personsIdList = _context.document_teacher_110_set_20ts24tu
                .Where(x => x.old_year == oldYear && x.new_year == newYear && x.person_id != null)
                .Where(x => x.status_.status != "Deleted" && (x.sequence_status >= 2 || x.rejection == true))
                .Where(x => x.person_.departament_id == user.person_.departament_id)
                .Include(x => x.person_)
                .AsEnumerable()
                .GroupBy(x => x.person_id)
                .Select(g => g.First())
                .Select(x => new Person
                {
                    id = x.person_.id,
                    firstName = x.person_.firstName,
                    lastName = x.person_.lastName,
                    fathers_name = x.person_.fathers_name,
                    employee_type_id = 0,
                    departament_id = 0
                })
                .ToList();


                return personsIdList;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<Person>();
        }
    }

    public DocumentTeacher110SetList DocumentTeacher110SetConfirmDep(int oldYear, int newYear, int person_id)
    {
        try
        {
            var user = _context.users_20ts24tu.Include(x => x.person_).FirstOrDefault(x => x.id == SessionClass.id);

            if (user != null)
            {
                var person = _context.persons_20ts24tu
                .Where(x => x.id == person_id)
                .Where(x => x.status_.status != "Deleted")
                .Where(x => x.departament_id == user.person_.departament_id)
                .Select(x => new Person
                {
                    id = x.id,
                    firstName = x.firstName,
                    lastName = x.lastName,
                    fathers_name = x.fathers_name,
                    employee_type_id = 0,
                    departament_id = 0
                }).FirstOrDefault();

                if (person == null) return new DocumentTeacher110SetList();

                List<DocumentTeacher110Set> docList = AllDocumentTeacher110SetDocList(oldYear, newYear, person_id, false, 2)
                    .Where(x => x.document_id != SessionClass.staticDocumentId)
                    .ToList();

                DocumentTeacher110SetList document = new DocumentTeacher110SetList()
                {
                    person_ = person,
                    documents_teacher_ = docList
                };


                return document;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new DocumentTeacher110SetList();
        }
    }

    public bool ConfirmDocumentTeacher110Set(int id, bool confirm, string? reason_for_rejection)
    {
        try
        {
            var dbcheck = GetDocumentTeacher110SetByIdAdmin(id);

            if (dbcheck is null || dbcheck.rejection == true)
            {
                return false;
            }

            var headDepartamentId = _context.users_20ts24tu
               .Where(x => x.id == SessionClass.id)
               .Select(x => x.person_.departament_id).FirstOrDefault();

            if (dbcheck.sequence_status != 2 || dbcheck.person_.departament_id != headDepartamentId)
            {
                return false;
            }

            if (!confirm)
            {
                dbcheck.rejection = true;
                dbcheck.reason_for_rejection = reason_for_rejection;
            }
            else if (confirm)
            {
                dbcheck.rejection = false;
                dbcheck.sequence_status = dbcheck.sequence_status + 1;

            }

            _context.Update(dbcheck);
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


    #endregion

    #region Faculty Council

    public IEnumerable<Person> AllDocumentTeacher110SetConfirmationFacultyCouncil(int oldYear, int newYear, int departament_id)
    {
        try
        {
            var user = _context.users_20ts24tu.Include(x => x.person_).FirstOrDefault(x => x.id == SessionClass.id);
            if (user != null)
            {
                List<int> faculty_child_department = _context.departament_20ts24tu
                  .Where(x => x.parent_id == user.person_.departament_id)
                  .Where(x => x.departament_type_id == 26)
                  .Select(x => x.id)
                  .ToList();

                List<Person> personsIdList = _context.document_teacher_110_set_20ts24tu
                .Where(x => x.old_year == oldYear && x.new_year == newYear && x.person_id != null)
                .Where(x => x.status_.status != "Deleted" && x.sequence_status >= 3)
                .Where(x => x.person_.departament_id.HasValue && faculty_child_department.Contains(x.person_.departament_id.Value))
                .Where(x => x.person_.departament_id == departament_id)
                .Include(x => x.person_)
                .AsEnumerable()
                .GroupBy(x => x.person_id)
                .Select(g => g.First())
                .Select(x => new Person
                {
                    id = x.person_.id,
                    firstName = x.person_.firstName,
                    lastName = x.person_.lastName,
                    fathers_name = x.person_.fathers_name,
                    employee_type_id = 0,
                    departament_id = 0
                })
                .ToList();


                return personsIdList;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<Person>();
        }
    }

    public DocumentTeacher110SetList DocumentTeacher110SetConfirmFacultyCouncil(int oldYear, int newYear, int person_id)
    {
        try
        {
            var user = _context.users_20ts24tu.Include(x => x.person_).FirstOrDefault(x => x.id == SessionClass.id);

            if (user != null)
            {
                List<int> faculty_child_department = _context.departament_20ts24tu
                 .Where(x => x.parent_id == user.person_.departament_id)
                 .Where(x => x.departament_type_id == 26)
                 .Select(x => x.id)
                 .ToList();

                var person = _context.persons_20ts24tu
                .Where(x => x.id == person_id)
                .Where(x => x.status_.status != "Deleted")
                .Where(x => x.departament_id.HasValue && faculty_child_department.Contains(x.departament_id.Value))
                .Select(x => new Person
                {
                    id = x.id,
                    firstName = x.firstName,
                    lastName = x.lastName,
                    fathers_name = x.fathers_name,
                    employee_type_id = 0,
                    departament_id = 0
                }).FirstOrDefault();

                if (person == null) return new DocumentTeacher110SetList();

                List<DocumentTeacher110Set> docList = AllDocumentTeacher110SetDocList(oldYear, newYear, person_id, false, 3)
                    .Where(x => x.document_id != SessionClass.staticDocumentId)
                    .ToList();

                DocumentTeacher110SetList document = new DocumentTeacher110SetList()
                {
                    person_ = person,
                    documents_teacher_ = docList
                };


                return document;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new DocumentTeacher110SetList();
        }
    }

    public Tuple<bool, string> ConfirmDocumentTeacher110SetFacultyCouncil(int id, bool confirm, DocumentTeacher110Set teacher110Set)
    {
        try
        {
            var user = _context.users_20ts24tu.Include(x => x.person_).FirstOrDefault(x => x.id == SessionClass.id);
            List<int> faculty_child_department = _context.departament_20ts24tu
                            .Where(x => x.parent_id == user.person_.departament_id)
                            .Where(x => x.departament_type_id == 26)
                            .Select(x => x.id)
                            .ToList();


            var dbcheck = GetDocumentTeacher110SetByIdAdmin(id);

            if (dbcheck.person_.departament_id.HasValue && !(faculty_child_department.Contains(dbcheck.person_.departament_id.Value)))
            {
                return Tuple.Create(false, "Xato!");
            }

            if (dbcheck is null || dbcheck.rejection == true)
            {
                return Tuple.Create(false, "Xato!");
            }

            if (dbcheck.sequence_status != 3 || dbcheck.document_id == SessionClass.staticDocumentId)
            {
                return Tuple.Create(false, "Xato!");
            }

            if (!confirm)
            {
                dbcheck.rejection = true;
                dbcheck.reason_for_rejection = teacher110Set.reason_for_rejection;
            }
            else if (confirm)
            {

                DocumentTeacher110 document = dbcheck.document_;

                if (document.indicator.Value) return Tuple.Create(true, "");

                List<DocumentTeacher110Set> documentTeacher110Set = _context.document_teacher_110_set_20ts24tu
                    .Where(x => x.status_.status != "Deleted" && x.person_id == dbcheck.person_id)
                    .Where(x => x.document_id.Equals(document.id))
                    .ToList();

                double summ = 0;

                if (documentTeacher110Set != null)
                {
                    foreach (var item in documentTeacher110Set)
                    {
                        if (item.score > 0)
                        {
                            summ += item.score.Value;
                        }
                    }
                }

                if (summ > document.max_score) return Tuple.Create(false, "Bu turdagi hujjat limiti to'lgan");

                //

                DocumentTeacher110 documentParent = _context.document_teacher_110_20ts24tu
                    .Include(x => x.status_)
                    .Where(x => x.status_.status != "Deleted")
                    .FirstOrDefault(x => x.id == document.parent_id);


                List<DocumentTeacher110> documentParentList = _context.document_teacher_110_20ts24tu
                    .Include(x => x.status_)
                    .Where(x => x.status_.status != "Deleted")
                    .Where(x => x.parent_id == document.parent_id)
                    .ToList();

                double summ2 = 0;

                foreach (var item in documentParentList)
                {
                    if (item != null)
                    {
                        summ2 += GetTeacherDocumentScoreAllDoc(dbcheck.old_year ?? 0, dbcheck.new_year ?? 0, dbcheck.person_id ?? 0, item.id, false) ?? 0;
                    }
                }

                if (summ2 > documentParent.max_score) return Tuple.Create(false, "Hujjatga ball qo'yish limiti to'lgan");

                double differenceParent = documentParent.max_score.Value - summ2;

                //

                double difference = document.max_score.Value - summ;

                if (teacher110Set.score > difference) return Tuple.Create(
                    false,
                    $"Bu turdagi hujjatga maksimal " +
                    $"{((differenceParent < difference) ? differenceParent : difference)} " +
                    $"ball qo'yishingiz mumkin"
                    );

                if (teacher110Set.score > differenceParent) return Tuple.Create(false, $"Bu turdagi hujjatga maksimal {differenceParent} ball qo'yishingiz mumkin");





                dbcheck.rejection = false;
                dbcheck.sequence_status = dbcheck.sequence_status + 1;
                dbcheck.score = teacher110Set.score;
                dbcheck.assessor_id = SessionClass.id;
                if (dbcheck.document_.max_score <= teacher110Set.score)
                {
                    dbcheck.score = dbcheck.document_.max_score;
                }

            }

            _context.Update(dbcheck);
            _context.SaveChanges();
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return Tuple.Create(true, "");
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Tuple.Create(false, "Xato!");
        }
    }



    #endregion region


    #region Study department

    public IEnumerable<Person> AllDocumentTeacher110SetConfirmationStudyDep(int oldYear, int newYear, int departament_id)
    {
        try
        {


            List<Person> personsIdList = _context.document_teacher_110_set_20ts24tu
            .Where(x => x.old_year == oldYear && x.new_year == newYear && x.person_id != null)
            .Where(x => x.status_.status != "Deleted" && x.sequence_status >= 3)
            .Where(x => x.person_.departament_id == departament_id)
            .Include(x => x.person_)
            .AsEnumerable()
            .GroupBy(x => x.person_id)
            .Select(g => g.First())
            .Select(x => new Person
            {
                id = x.person_.id,
                firstName = x.person_.firstName,
                lastName = x.person_.lastName,
                fathers_name = x.person_.fathers_name,
                employee_type_id = 0,
                departament_id = 0
            })
            .ToList();


            return personsIdList;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<Person>();
        }
    }

    public DocumentTeacher110SetList DocumentTeacher110SetConfirmStudyDep(int oldYear, int newYear, int person_id)
    {
        try
        {
            var person = _context.persons_20ts24tu
            .Where(x => x.id == person_id)
            .Where(x => x.status_.status != "Deleted")
            .Select(x => new Person
            {
                id = x.id,
                firstName = x.firstName,
                lastName = x.lastName,
                fathers_name = x.fathers_name,
                employee_type_id = 0,
                departament_id = 0
            }).FirstOrDefault();

            if (person == null) return new DocumentTeacher110SetList();

            List<DocumentTeacher110Set> docList = AllDocumentTeacher110SetDocList(oldYear, newYear, person_id, false, 3).ToList();

            DocumentTeacher110SetList document = new DocumentTeacher110SetList()
            {
                person_ = person,
                documents_teacher_ = docList
            };


            return document;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new DocumentTeacher110SetList();
        }
    }

    public Tuple<bool, string> CreateDocumentTeacher110SetStudyDep(int person_id, DocumentTeacher110Set documentTeacher110Set)
    {
        try
        {
            if (documentTeacher110Set == null || documentTeacher110Set.document_id != SessionClass.staticDocumentId)
            {
                return Tuple.Create(false, "Xato!");
            }

            if (documentTeacher110Set.fixed_date != null)
            {
                DateTime localDateTime = DateTime.Parse(documentTeacher110Set.fixed_date.ToString());
                localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
                DateTime utcDateTime = localDateTime.ToUniversalTime();
                documentTeacher110Set.fixed_date = utcDateTime.AddDays(1);
            }


            double scoreMax = GetTeacherDocumentScore(documentTeacher110Set.old_year ?? 0, documentTeacher110Set.new_year ?? 0, person_id) ?? 0;
            double define = 110 - scoreMax;

            if (documentTeacher110Set.score > define)
            {
                return Tuple.Create(false, $"Siz maksimal {define} ball qo'yishingiz mumkin");
            }

            documentTeacher110Set.person_id = person_id;

            var document = _context.document_teacher_110_20ts24tu.FirstOrDefault(x => x.id == documentTeacher110Set.document_id);
            if (document.indicator == true)
            {
                return Tuple.Create(false, "Xato!");
            }

            documentTeacher110Set.avtor = document.avtor;

            if (documentTeacher110Set.avtor == false || documentTeacher110Set.avtor == null)
            {
                documentTeacher110Set.number_authors = null;
            }

            _context.document_teacher_110_set_20ts24tu.Add(documentTeacher110Set);
            _context.SaveChanges();
            int id = documentTeacher110Set.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(documentTeacher110Set));
            return Tuple.Create(true, id.ToString());
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Tuple.Create(false, "Xato!");
        }
    }

    public Tuple<bool, string> UpdateDocumentTeacher110SetStudyDep(int id, DocumentTeacher110Set documentTeacher110)
    {
        try
        {
            var dbcheck = GetDocumentTeacher110SetByIdAdmin(id);
            if (dbcheck is null || documentTeacher110.document_id != SessionClass.staticDocumentId)
            {
                return Tuple.Create(false, "Xato!");
            }


            if (documentTeacher110.fixed_date != null)
            {
                DateTime localDateTime = DateTime.Parse(documentTeacher110.fixed_date.ToString());
                localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
                DateTime utcDateTime = localDateTime.ToUniversalTime();
                documentTeacher110.fixed_date = utcDateTime.AddDays(1);
            }

            double scoreMax = GetTeacherDocumentScore(documentTeacher110.old_year ?? 0, documentTeacher110.new_year ?? 0, dbcheck.person_id ?? 0) ?? 0;
            scoreMax = scoreMax - dbcheck.score ?? 0;
            double define = 110 - scoreMax;

            if (documentTeacher110.score > define)
            {
                return Tuple.Create(false, $"Siz maksimal {define} ball qo'yishingiz mumkin");
            }

            var document = _context.document_teacher_110_20ts24tu.FirstOrDefault(x => x.id == dbcheck.document_id);
            if (document.indicator == true)
            {
                return Tuple.Create(false, "Xato!");
            }

            documentTeacher110.avtor = document.avtor;

            if (documentTeacher110.avtor == false || documentTeacher110.avtor == null)
            {
                documentTeacher110.number_authors = null;
            }
            dbcheck.score = documentTeacher110.score;
            dbcheck.old_year = documentTeacher110.old_year;
            dbcheck.new_year = documentTeacher110.new_year;
            dbcheck.document_id = documentTeacher110.document_id;
            dbcheck.sequence_status = 4;
            dbcheck.rejection = false;
            dbcheck.reason_for_rejection = "";
            dbcheck.fixed_date = documentTeacher110.fixed_date;
            dbcheck.avtor = documentTeacher110.avtor;
            dbcheck.number_authors = documentTeacher110.number_authors;

            if (documentTeacher110.file_ != null)
            {
                dbcheck.file_ = documentTeacher110.file_;
            }
            dbcheck.comment = documentTeacher110.comment;


            _context.Update(dbcheck);
            _context.SaveChanges();
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return Tuple.Create(true, "");
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Tuple.Create(false, "Xato!");
        }
    }

    public DocumentTeacher110Set GetDocumentTeacher110SetByIdStudyDep(int id)
    {
        try
        {

            var documentTeacher110 = _context.document_teacher_110_set_20ts24tu
                .Include(x => x.person_)
                .Include(x => x.file_)
                .Include(x => x.document_)
                .Where(x => x.status_.status != "Deleted" && x.document_id == SessionClass.staticDocumentId)
                .FirstOrDefault(x => x.id.Equals(id));

            return documentTeacher110 ?? new DocumentTeacher110Set();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return new DocumentTeacher110Set();
        }
    }

    public bool DeleteDocumentTeacher110SetStudyDep(int id)
    {
        try
        {
            var documentTeacher110 = GetDocumentTeacher110SetByIdStudyDep(id);
            if (documentTeacher110 == null)
            {
                return false;
            }

            documentTeacher110.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.document_teacher_110_set_20ts24tu.Update(documentTeacher110);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(documentTeacher110));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    #endregion region


    #region Any

    private IEnumerable<DocumentTeacher110Set> AllDocumentTeacher110SetDocList(int oldYear, int newYear, int person_id, bool admin, int sequanse_status)
    {
        try
        {

            IQueryable<DocumentTeacher110Set> documentTeacher110 = _context.document_teacher_110_set_20ts24tu
                .Include(x => x.person_)
                .Include(x => x.file_)
                .Include(x => x.document_)
                .Include(x => x.assessor_).ThenInclude(y => y.user_type_)
                .Include(x => x.assessor_).ThenInclude(y => y.person_)
                .Where(x => x.person_id == person_id)
                .Where(x => x.old_year == oldYear && x.new_year == newYear);





            if (admin)
            {
                documentTeacher110 = documentTeacher110.Include(x => x.status_);
            }
            if (!admin)
            {
                documentTeacher110 = documentTeacher110.Where(x => x.status_.status != "Deleted")
                .Where(x => x.sequence_status >= sequanse_status || x.rejection == true);
            }

            List<DocumentTeacher110Set> getList = documentTeacher110.ToList();
            List<DocumentTeacher110Set> response = new List<DocumentTeacher110Set>();

            if (getList != null)
            {
                foreach (var item in getList)
                {
                    string titleDoc = item.document_.title;

                    int? docParentId = item.document_.parent_id;

                    while (docParentId > 0)
                    {
                        var document = _context.document_teacher_110_20ts24tu.FirstOrDefault(x => x.id == docParentId);
                        if (document != null)
                        {
                            titleDoc = $"{document.title} // {titleDoc}";
                            docParentId = document.parent_id;
                        }
                        else
                        {
                            break;
                        }


                    }
                    DocumentTeacher110Set documentTeacher110Set = item;
                    documentTeacher110Set.document_ = new DocumentTeacher110
                    {
                        id = item.document_.id,
                        title = titleDoc,
                        parent_id = item.document_.parent_id,
                        indicator = item.document_.indicator,
                        max_score = item.document_.max_score,
                        description = item.document_.description,
                    };
                    response.Add(documentTeacher110Set);


                }
            }



            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return Enumerable.Empty<DocumentTeacher110Set>();
        }
    }


    #endregion




    public double? GetTeacherDocumentScoreAllDoc(int oldYear, int newYear, int person_id, int document_id, bool teacher)
    {
        try
        {
            if (teacher)
            {
                var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);

                if (user != null && user.person_id != 0 && user.person_id != null)
                {
                    person_id = user.person_id ??= 0;
                }
                else
                {
                    return 0;
                }
            }

            double score = 0;

            var document = _context.document_teacher_110_20ts24tu
                .Where(x => x.status_.status != "Deleted" && x.id == document_id)
                .FirstOrDefault();

            if (document != null)
            {
                if (document.indicator == true)
                {
                    var DocChildList = _context.document_teacher_110_20ts24tu
                       .Where(x => x.status_.status != "Deleted" && x.parent_id == document_id)
                       .ToList();

                    foreach (var docChild in DocChildList)
                    {
                        score += GetTeacherDocBall(oldYear, newYear, person_id, docChild) ?? 0;
                    }
                }
                else if (document.indicator == false)
                {
                    score += GetTeacherDocBall(oldYear, newYear, person_id, document) ?? 0;
                }
            }

            return score;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    private double? GetTeacherDocBall(int oldYear, int newYear, int person_id, DocumentTeacher110? docChild)
    {
        try
        {
            double score = 0;

            if (docChild.indicator == false)
            {
                var docSet = _context.document_teacher_110_set_20ts24tu
                .Where(x => x.status_.status != "Deleted" && x.document_id == docChild.id)
                .Where(x => x.old_year == oldYear && x.new_year == newYear)
                .Where(x => x.person_id == person_id)
                .ToList();
                foreach (var item in docSet) { score += item.score ?? 0; }
            }
            else if (docChild.indicator == true)
            {
                var DocChildList = _context.document_teacher_110_20ts24tu
                    .Where(x => x.status_.status != "Deleted" && x.parent_id == docChild.id)
                    .ToList();

                foreach (var docChild1 in DocChildList)
                {
                    score += GetTeacherDocBall(oldYear, newYear, person_id, docChild1) ?? 0;
                }
            }


            return score;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }
}
