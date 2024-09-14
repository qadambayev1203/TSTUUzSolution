using Entities.Model.BlogsModel;
using Entities.Model.DepartamentsModel;
using Entities.Model.PagesModel;
using Entities.Model.PersonDataModel;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.AllRepository.SearchRepository;

public interface ISearchRepository
{
    public Task<List<Blog>> SearchBlogs(string query);
    public Task<List<Departament>> SearchDepartaments(string query);
    public Task<List<PersonData>> SearchEmployes(string query);
    public Task<List<Pages>> SearchPages(string query);


    public Task<List<BlogTranslation>> SearchBlogsTranslations(string query, string language_code);
    public Task<List<DepartamentTranslation>> SearchDepartamentsTranslations(string query, string language_code);
    public Task<List<PersonDataTranslation>> SearchEmployesTranslations(string query, string language_code);
    public Task<List<PageTranslation>> SearchPagesTranslations(string query, string language_code);
}
