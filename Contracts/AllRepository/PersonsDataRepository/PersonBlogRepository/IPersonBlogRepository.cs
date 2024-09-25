using Entities.Model.AnyClasses;
using Entities.Model.PersonDataModel;
using Entities.Model.PersonDataModel.PersonBlogModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Contracts.AllRepository.PersonsDataRepository.PersonBlogRepository;

public interface IPersonBlogRepository
{
    // PersonBlog CRUD
    public int CreatePersonBlog(PersonBlog personBlog);
    public IEnumerable<PersonBlog> AllPersonBlog(int queryNum, int pageNum, int person_data_id, bool isAdmin);
    public IEnumerable<PersonBlog> AllPersonBlogSite(int queryNum, int pageNum, int person_data_id);
    public PersonBlog GetByIdPersonBlogSite(int id);
    public PersonBlog GetByIdPersonBlog(int id, bool isAdmin);
    public bool DeletePersonBlog(int id);
    public bool UpdatePersonBlog(int id, PersonBlog personBlog, bool isAdmin);

    // PersonBlogTranslation CRUD
    public int CreatePersonBlogTranslation(PersonBlogTranslation personBlog);
    public IEnumerable<PersonBlogTranslation> AllPersonBlogTranslation(int queryNum, int pageNum, int person_data_id, bool isAdmin, string language_code);
    public IEnumerable<PersonBlogTranslation> AllPersonBlogTranslationSite(int queryNum, int pageNum, int person_data_id, string language_code);
    public PersonBlogTranslation GetByIdPersonBlogTranslation(int id, bool isAdmin);
    public PersonBlogTranslation GetByIdPersonBlogTranslationSite(int id);
    public PersonBlogTranslation GetByIdPersonBlogTranslation(int uz_id, string language_code, bool isAdmin);
    public PersonBlogTranslation GetByIdPersonBlogTranslationSite(int uz_id, string language_code);
    public bool DeletePersonBlogTranslation(int id);
    public bool UpdatePersonBlogTranslation(int id, PersonBlogTranslation personBlog, bool isAdmin);


    //Confirm
    public IEnumerable<PersonData> AllPersonBlogCreated();
    public IEnumerable<PersonBlog> AllPersonBlogDep(int queryNum, int pageNum, int person_data_id);
    public bool ConfirmDocumentTeacher110Set(int id, bool confirm);

}
