using Contracts.AllRepository.DocumentTeacher110Repository;
using Entities;
using Entities.Model;
using Entities.Model.AnyClasses;
using Entities.Model.DepartamentsModel;
using Entities.Model.DocumentTeacher110Model;
using Entities.Model.PersonModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;

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

            ScoreOptimize(person_id);          //Score


            IQueryable<DocumentTeacher110Set> documentTeacher110 = _context.document_teacher_110_set_20ts24tu
               .Include(x => x.person_)
               .Include(x => x.file_)
               .Include(x => x.document_)
               .Include(x => x.assessor_).ThenInclude(y => y.user_type_)
               .Include(x => x.assessor_).ThenInclude(y => y.person_)
               .Where(x => x.person_id == person_id)
               .Where(x => x.status_.status != "Deleted")
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


            ScoreOptimize(person_id);          //Score


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
            if (documentTeacher110Set == null)
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
                .Where(x => x.status_.status != "Deleted" && x.person_id == person_id)
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
            if (dbcheck is null)
            {
                return false;
            }

            if (dbcheck.sequence_status == 4)
            {
                return false;
            }

            dbcheck.old_year = documentTeacher110.old_year;
            dbcheck.new_year = documentTeacher110.new_year;
            dbcheck.document_id = documentTeacher110.document_id;
            dbcheck.sequence_status = 2;
            dbcheck.rejection = false;
            dbcheck.reason_for_rejection = "";

            if (documentTeacher110.file_ != null)
            {
                dbcheck.file_ = documentTeacher110.file_;
            }
            dbcheck.comment = documentTeacher110.comment;

            var document = _context.document_teacher_110_20ts24tu.FirstOrDefault(x => x.id == dbcheck.document_id);
            if (document.indicator == true)
            {
                return false;
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

                List<DocumentTeacher110Set> docList = AllDocumentTeacher110SetDocList(oldYear, newYear, person_id, false, 2).ToList();

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

                List<DocumentTeacher110Set> docList = AllDocumentTeacher110SetDocList(oldYear, newYear, person_id, false, 3).ToList();

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

    public bool ConfirmDocumentTeacher110SetFacultyCouncil(int id, bool confirm, DocumentTeacher110Set teacher110Set)
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
                return false;
            }

            if (dbcheck is null || dbcheck.rejection == true)
            {
                return false;
            }

            if (dbcheck.sequence_status != 3)
            {
                return false;
            }

            if (!confirm)
            {
                dbcheck.rejection = true;
                dbcheck.reason_for_rejection = teacher110Set.reason_for_rejection;
            }
            else if (confirm)
            {
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
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
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


    #endregion region


    #region Any

    private IEnumerable<DocumentTeacher110Set> AllDocumentTeacher110SetDocList(int oldYear, int newYear, int person_id, bool admin, int sequanse_status)
    {
        try
        {

            ScoreOptimize(person_id);          //Score

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

    private void ScoreOptimize(int person_id)
    {

        try
        {
            var result = _context.document_teacher_110_set_20ts24tu
           .Join(_context.document_teacher_110_20ts24tu,
                 dset => dset.document_id,
                 dget => dget.id,
                 (dset, dget) => new { dset, dget })
           .Where(x => x.dget.indicator == false && x.dset.person_id == person_id)
           .GroupBy(x => new { x.dget.parent_id, x.dget.max_score })
           .Select(g => new
           {
               parent_id = g.Key.parent_id,
               max_score = g.Key.max_score
           })
           .ToList();


            foreach (var document in result)
            {
                int totalScore = Convert.ToInt32(_context.document_teacher_110_set_20ts24tu
                                    .Join(_context.document_teacher_110_20ts24tu,
                                          dset => dset.document_id,
                                          dget => dget.id,
                                          (dset, dget) => new { dset, dget })
                                    .Where(x => x.dget.parent_id == document.parent_id)
                                    .Sum(x => x.dset.score));

                if (totalScore > 0 && totalScore > document.max_score)
                {
                    List<int> resultIds = _context.document_teacher_110_set_20ts24tu
                        .Join(_context.document_teacher_110_20ts24tu,
                              dset => dset.document_id,
                              dget => dget.id,
                              (dset, dget) => new { dset, dget })
                        .Where(x => x.dget.parent_id == document.parent_id)
                        .Select(x => x.dset.id)
                        .ToList();

                    if (resultIds.Count > 0)
                    {
                        double? proportional = document.max_score * 1.0 / totalScore;

                        if (proportional is not null)
                        {
                            string ids = string.Join(",", resultIds);

                            _context.Database.ExecuteSqlRaw($"UPDATE document_teacher_110_set_20ts24tu SET score = score * {proportional} WHERE id IN ({ids});");
                            _context.SaveChanges();
                        }
                    }

                }

            }
        }
        catch
        {
        }


    }

    #endregion

}
