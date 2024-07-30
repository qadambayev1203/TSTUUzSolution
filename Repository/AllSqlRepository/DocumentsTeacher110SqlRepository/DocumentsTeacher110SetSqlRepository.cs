using Contracts.AllRepository.DocumentTeacher110Repository;
using Entities;
using Entities.Model.DocumentTeacher110Model;
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


        public IEnumerable<DocumentTeacher110Set> AllDocumentTeacher110Set(int person_id)
        {
            try
            {
                IQueryable<DocumentTeacher110Set> documentTeacher110 = _context.document_teacher_110_set_20ts24tu
                    .Include(x => x.person_)
                    .Include(x => x.file_)
                    .Include(x => x.document_)
                    .Where(x => x.status_.status != "Deleted" && x.person_id == person_id);

                return documentTeacher110.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return Enumerable.Empty<DocumentTeacher110Set>();
            }
        }

        public IEnumerable<DocumentTeacher110Set> AllDocumentTeacher110SetAdmin(int person_id)
        {
            try
            {
                IQueryable<DocumentTeacher110Set> documentTeacher110 = _context.document_teacher_110_set_20ts24tu
                    .Include(x => x.person_)
                    .Include(x => x.file_)
                    .Include(x => x.document_)
                    .Where(x => x.person_id == person_id);

                return documentTeacher110.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return Enumerable.Empty<DocumentTeacher110Set>();
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
