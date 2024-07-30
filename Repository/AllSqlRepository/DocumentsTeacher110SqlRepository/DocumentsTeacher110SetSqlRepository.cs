using Contracts.AllRepository.DocumentTeacher110Repository;
using Entities;
using Entities.Model.AnyClasses;
using Entities.Model.DocumentTeacher110Model;
using Entities.Model.PersonModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AllSqlRepository.DocumentsTeacher110SqlRepository
{
    public class DocumentsTeacher110SetSqlRepository : IDocumentTeacher110SetRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<DocumentsTeacher110SetSqlRepository> _logger;
        public DocumentsTeacher110SetSqlRepository(RepositoryContext repositoryContext, ILogger<DocumentsTeacher110SetSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }


        public IEnumerable<DocumentTeacher110Set> AllDocumentTeacher110Set(int oldYear, int newYear)
        {
            try
            {
                var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                int person_id = 3;
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
                    .Where(x => x.status_.status != "Deleted" && x.person_id == person_id)
                    .Where(x => x.old_year == oldYear && x.new_year == newYear);

                return documentTeacher110.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return Enumerable.Empty<DocumentTeacher110Set>();
            }
        }

        public IEnumerable<DocumentTeacher110Set> AllDocumentTeacher110SetDocList(int oldYear, int newYear, int person_id)
        {
            try
            {

                IQueryable<DocumentTeacher110Set> documentTeacher110 = _context.document_teacher_110_set_20ts24tu
                    .Include(x => x.person_)
                    .Include(x => x.file_)
                    .Include(x => x.document_)
                    .Where(x => x.person_id == person_id)
                    .Where(x => x.old_year == oldYear && x.new_year == newYear);

                return documentTeacher110.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return Enumerable.Empty<DocumentTeacher110Set>();
            }
        }

        public IEnumerable<Person> AllDocumentTeacher110SetAdmin(int oldYear, int newYear)
        {
            try
            {
                List<Person> personsIdList = _context.document_teacher_110_set_20ts24tu
                .Where(x => x.old_year == oldYear && x.new_year == newYear && x.person_id != null)
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

                List<DocumentTeacher110Set> docList = AllDocumentTeacher110SetDocList(oldYear, newYear, person_id).ToList();

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

        public int CreateDocumentTeacher110Set(DocumentTeacher110Set documentTeacher110Set)
        {
            try
            {
                if (documentTeacher110Set == null)
                {
                    return 0;
                }

                var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                int person_id = 3;
                if (user != null && user.person_id != 0 && user.person_id != null)
                {
                    person_id = user.person_id ??= 0;

                }
                else
                {
                    return 0;
                }

                documentTeacher110Set.person_id = person_id;
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
                var documentTeacher110 = _context.document_teacher_110_set_20ts24tu
                    .Include(x => x.person_)
                    .Include(x => x.file_)
                    .Include(x => x.document_)
                    .Where(x => x.status_.status != "Deleted")
                    .FirstOrDefault(x => x.id.Equals(id));

                return documentTeacher110 ?? new DocumentTeacher110Set();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return new DocumentTeacher110Set();
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

        public bool UpdateDocumentTeacher110Set(int id, DocumentTeacher110Set documentTeacher110)
        {
            try
            {
                var dbcheck = GetDocumentTeacher110SetByIdAdmin(id);
                if (dbcheck is null)
                {
                    return false;
                }

                var user = _context.users_20ts24tu.FirstOrDefault(x => x.id == SessionClass.id);
                int person_id;
                if (user != null && user.person_id != 0 && user.person_id != null)
                {
                    person_id = user.person_id ??= 0;

                }
                else
                {
                    return false;
                }
                documentTeacher110.person_id = person_id;

                dbcheck.person_id = documentTeacher110.person_id;
                dbcheck.old_year = documentTeacher110.old_year;
                dbcheck.new_year = documentTeacher110.new_year;
                dbcheck.document_id = documentTeacher110.document_id;
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

    }
}
