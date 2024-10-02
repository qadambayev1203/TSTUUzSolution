using Contracts.AllRepository.SearchRepository;
using Entities;
using Entities.Model.AnyClasses;
using Entities.Model.BlogsModel;
using Entities.Model.DepartamentsModel;
using Entities.Model.PagesModel;
using Entities.Model.PersonDataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.SearchSqlRepositorys
{
    public class SearchSqlRepository : ISearchRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<SearchSqlRepository> _logger;
        public SearchSqlRepository(RepositoryContext repositoryContext, ILogger<SearchSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }

        public async Task<List<Blog>> SearchBlogs(string query)
        {
            try
            {
                var blogResults = await _context.blogs_20ts24tu
                    .Where(pd => pd.status_.status != "Deleted")
                    .Where(b =>
                        EF.Functions.ILike(b.title_short, $"%{query}%") ||
                        EF.Functions.ILike(b.title, $"%{query}%") ||
                        EF.Functions.ILike(b.description, $"%{query}%") ||
                        EF.Functions.ILike(b.text, $"%{query}%") ||
                        EF.Functions.ILike(b.event_date.ToString(), $"%{query}%") ||
                        EF.Functions.ILike(b.event_end_date.ToString(), $"%{query}%"))
                    .ToListAsync();

                return blogResults ?? new List<Blog>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SearchDatabase xatoligi.");
                return new List<Blog>();
            }
        }
        public async Task<List<Departament>> SearchDepartaments(string query)
        {
            try
            {
                var departamentResults = await _context.departament_20ts24tu
                    .Where(pd => pd.status_.status != "Deleted")
                    .Include(x => x.departament_type_)
                    .Where(d =>
                        EF.Functions.ILike(d.title_short, $"%{query}%") ||
                        EF.Functions.ILike(d.title, $"%{query}%") ||
                        EF.Functions.ILike(d.description, $"%{query}%") ||
                        EF.Functions.ILike(d.text, $"%{query}%"))
                    .ToListAsync();

                return departamentResults ?? new List<Departament>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SearchDatabase xatoligi.");
                return new List<Departament>();
            }
        }
        public async Task<List<PersonData>> SearchEmployes(string query)
        {
            try
            {
                var personDataResults = await _context.persons_data_20ts24tu
                    .Include(pd => pd.persons_)
                    .Where(pd => pd.status_.status != "Deleted")
                    .Where(pd =>
                        EF.Functions.ILike(pd.biography_json, $"%{query}%") ||
                        EF.Functions.ILike(pd.degree, $"%{query}%") ||
                        EF.Functions.ILike(pd.scientific_title, $"%{query}%") ||
                        EF.Functions.ILike(pd.phone_number1, $"%{query}%") ||
                        EF.Functions.ILike(pd.phone_number2, $"%{query}%") ||
                        EF.Functions.ILike(pd.persons_.firstName, $"%{query}%") ||
                        EF.Functions.ILike(pd.persons_.lastName, $"%{query}%") ||
                        EF.Functions.ILike(pd.persons_.fathers_name, $"%{query}%") ||
                        EF.Functions.ILike(pd.persons_.email, $"%{query}%"))
                    .ToListAsync();

                return personDataResults ?? new List<PersonData>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SearchDatabase xatoligi.");
                return new List<PersonData>();
            }
        }
        public async Task<List<Pages>> SearchPages(string query)
        {
            try
            {
                var pageResults = await _context.pages_20ts24tu
                    .Where(pd => pd.status_.status != "Deleted")
                    .Where(p =>
                        EF.Functions.ILike(p.title_short, $"%{query}%") ||
                        EF.Functions.ILike(p.title, $"%{query}%") ||
                        EF.Functions.ILike(p.description, $"%{query}%") ||
                        EF.Functions.ILike(p.text, $"%{query}%"))
                    .ToListAsync();

                return pageResults ?? new List<Pages>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SearchDatabase xatoligi.");
                return new List<Pages>();
            }
        }




        public async Task<List<BlogTranslation>> SearchBlogsTranslations(string query, string language_code)
        {
            try
            {
                var blogResults = await _context.blogs_translations_20ts24tu
                    .Where(pd => pd.status_translation_.status != "Deleted")
                    .Include(pd => pd.language_)
                    .Where(pd => pd.language_.code == language_code)
                    .Where(b =>
                        EF.Functions.ILike(b.title_short, $"%{query}%") ||
                        EF.Functions.ILike(b.title, $"%{query}%") ||
                        EF.Functions.ILike(b.description, $"%{query}%") ||
                        EF.Functions.ILike(b.text, $"%{query}%") ||
                        EF.Functions.ILike(b.event_date.ToString(), $"%{query}%") ||
                        EF.Functions.ILike(b.event_end_date.ToString(), $"%{query}%"))
                    .ToListAsync();

                return blogResults ?? new List<BlogTranslation>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SearchDatabase xatoligi.");
                return new List<BlogTranslation>();
            }
        }
        public async Task<List<DepartamentTranslation>> SearchDepartamentsTranslations(string query, string language_code)
        {
            try
            {
                var departamentResults = await _context.departament_translations_20ts24tu
                    .Where(pd => pd.status_translation_.status != "Deleted")
                    .Include(pd => pd.language_)
                    .Include(x => x.departament_type_translation_).ThenInclude(y => y.departament_type_)
                    .Where(pd => pd.language_.code == language_code)
                    .Where(d =>
                        EF.Functions.ILike(d.title_short, $"%{query}%") ||
                        EF.Functions.ILike(d.title, $"%{query}%") ||
                        EF.Functions.ILike(d.description, $"%{query}%") ||
                        EF.Functions.ILike(d.text, $"%{query}%"))
                    .ToListAsync();

                return departamentResults ?? new List<DepartamentTranslation>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SearchDatabase xatoligi.");
                return new List<DepartamentTranslation>();
            }
        }
        public async Task<List<PersonDataTranslation>> SearchEmployesTranslations(string query, string language_code)
        {
            try
            {
                var personDataResults = await _context.persons_data_translations_20ts24tu
                    .Include(pd => pd.persons_data_).ThenInclude(y => y.persons_)
                    .Include(pd => pd.persons_translation_)
                    .Where(pd => pd.status_translation_.status != "Deleted")
                    .Include(pd => pd.language_)
                    .Where(pd => pd.language_.code == language_code)
                    .Where(pd =>
                        EF.Functions.ILike(pd.biography_json, $"%{query}%") ||
                        EF.Functions.ILike(pd.degree, $"%{query}%") ||
                        EF.Functions.ILike(pd.scientific_title, $"%{query}%") ||
                        EF.Functions.ILike(pd.phone_number1, $"%{query}%") ||
                        EF.Functions.ILike(pd.phone_number2, $"%{query}%") ||
                        EF.Functions.ILike(pd.persons_translation_.firstName, $"%{query}%") ||
                        EF.Functions.ILike(pd.persons_translation_.lastName, $"%{query}%") ||
                        EF.Functions.ILike(pd.persons_translation_.fathers_name, $"%{query}%") ||
                        EF.Functions.ILike(pd.persons_data_.persons_.email, $"%{query}%"))
                    .ToListAsync();

                return personDataResults ?? new List<PersonDataTranslation>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SearchDatabase xatoligi.");
                return new List<PersonDataTranslation>();
            }
        }
        public async Task<List<PageTranslation>> SearchPagesTranslations(string query, string language_code)
        {
            try
            {
                var pageResults = await _context.pages_translations_20ts24tu
                    .Where(pd => pd.status_translation_.status != "Deleted")
                    .Include(pd => pd.language_)
                    .Where(pd => pd.language_.code == language_code)
                    .Where(p =>
                        EF.Functions.ILike(p.title_short, $"%{query}%") ||
                        EF.Functions.ILike(p.title, $"%{query}%") ||
                        EF.Functions.ILike(p.description, $"%{query}%") ||
                        EF.Functions.ILike(p.text, $"%{query}%"))
                    .ToListAsync();

                return pageResults ?? new List<PageTranslation>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SearchDatabase xatoligi.");
                return new List<PageTranslation>();
            }
        }

    }
}