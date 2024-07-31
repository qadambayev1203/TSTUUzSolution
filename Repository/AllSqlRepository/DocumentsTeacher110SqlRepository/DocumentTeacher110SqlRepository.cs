using Contracts.AllRepository.DocumentTeacher110Repository;
using Entities;
using Entities.Model.DistrictsModel;
using Entities.Model.DocumentTeacher110Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Repository.AllSqlRepository.DocumentsTeacher110SqlRepository
{
    public class DocumentTeacher110SqlRepository : IDocumentTeacher110Repository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<DocumentTeacher110SqlRepository> _logger;
        public DocumentTeacher110SqlRepository(RepositoryContext repositoryContext, ILogger<DocumentTeacher110SqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }


        public IEnumerable<DocumentTeacher110> AllDocumentTeacher110(int? parent_id, bool parent)
        {
            try
            {
                IQueryable<DocumentTeacher110> documentTeacher110 = _context.document_teacher_110_20ts24tu
                    .Where(x => x.status_.status != "Deleted");

                if (parent_id != null && parent)
                {
                    documentTeacher110 = documentTeacher110.Where(x => x.parent_id == parent_id);
                }

                return documentTeacher110.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return Enumerable.Empty<DocumentTeacher110>();
            }
        }

        public IEnumerable<DocumentTeacher110> AllDocumentTeacher110Select()
        {
            try
            {
                IQueryable<DocumentTeacher110> documentTeacher110 = _context.document_teacher_110_20ts24tu
                    .Where(x => x.status_.status != "Deleted")
                    .Select(x => new DocumentTeacher110
                    {
                        id = x.id,
                        title = x.title
                    });
                return documentTeacher110.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return Enumerable.Empty<DocumentTeacher110>();
            }
        }

        public IEnumerable<DocumentTeacher110> AllDocumentTeacher110Admin(int? parent_id, bool parent)
        {
            try
            {
                IQueryable<DocumentTeacher110> documentTeacher110 = _context.document_teacher_110_20ts24tu
                    .Include(x => x.status_);

                if (parent_id != null && parent)
                {
                    documentTeacher110 = documentTeacher110.Where(x => x.parent_id == parent_id);
                }

                return documentTeacher110.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return Enumerable.Empty<DocumentTeacher110>();
            }
        }

        public int CreateDocumentTeacher110(DocumentTeacher110 documentTeacher110)
        {
            try
            {
                if (documentTeacher110 == null)
                {
                    return 0;
                }
                _context.document_teacher_110_20ts24tu.Add(documentTeacher110);
                _context.SaveChanges();
                int id = documentTeacher110.id;
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(documentTeacher110));
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return 0;
            }
        }

        public bool DeleteDocumentTeacher110(int id)
        {
            try
            {
                var documentTeacher110 = GetDocumentTeacher110ByIdAdmin(id);
                if (documentTeacher110 == null)
                {
                    return false;
                }
                documentTeacher110.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.document_teacher_110_20ts24tu.Update(documentTeacher110);
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

        public DocumentTeacher110 GetDocumentTeacher110ById(int id)
        {
            try
            {
                var documentTeacher110 = _context.document_teacher_110_20ts24tu
                    .Where(x => x.status_.status != "Deleted")
                    .FirstOrDefault(x => x.id.Equals(id));

                return documentTeacher110 ?? new DocumentTeacher110();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return new DocumentTeacher110();
            }
        }

        public DocumentTeacher110 GetDocumentTeacher110ByIdAdmin(int id)
        {
            try
            {
                var documentTeacher110 = _context.document_teacher_110_20ts24tu
                    .Include(x => x.status_)
                    .FirstOrDefault(x => x.id.Equals(id));

                return documentTeacher110 ?? new DocumentTeacher110();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return new DocumentTeacher110();
            }
        }

        public bool UpdateDocumentTeacher110(int id, DocumentTeacher110 documentTeacher110)
        {
            try
            {
                var dbcheck = GetDocumentTeacher110ByIdAdmin(id);
                if (dbcheck is null)
                {
                    return false;
                }

                dbcheck.title = documentTeacher110.title;
                dbcheck.parent_id = documentTeacher110.parent_id;
                dbcheck.indicator = documentTeacher110.indicator;
                dbcheck.one_indicator = documentTeacher110.one_indicator;
                dbcheck.two_indicator = documentTeacher110.two_indicator;
                dbcheck.max_score = documentTeacher110.max_score;
                dbcheck.description = documentTeacher110.description;
                dbcheck.document_sequence = documentTeacher110.document_sequence;
                dbcheck.status_id = documentTeacher110.status_id;

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
