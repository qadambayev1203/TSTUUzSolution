using Entities.Model.PersonDataModel.PersonBlogModel;

namespace Contracts.AllRepository.PersonsDataRepository.PersonBlogRepository;

public interface IPersonBlogRepository
{
    // PersonBlog CRUD
    public int CreatePersonBlog(PersonBlog personBlog);
    public IEnumerable<PersonBlog> AllPersonBlog(int queryNum, int pageNum, int person_data_id, bool isAdmin);
    public PersonBlog GetByIdPersonBlog(int id, bool isAdmin);
    public bool DeletePersonBlog(int id);
    public bool UpdatePersonBlog(int id, PersonBlog personBlog, bool isAdmin);

    // PersonBlogTranslation CRUD
    public int CreatePersonBlogTranslation(PersonBlogTranslation personBlog);
    public IEnumerable<PersonBlogTranslation> AllPersonBlogTranslation(int queryNum, int pageNum, int person_data_id, bool isAdmin, string language_code);
    public PersonBlogTranslation GetByIdPersonBlogTranslation(int id, bool isAdmin);
    public PersonBlogTranslation GetByIdPersonBlogTranslation(int uz_id, string language_code, bool isAdmin);
    public bool DeletePersonBlogTranslation(int id);
    public bool UpdatePersonBlogTranslation(int id, PersonBlogTranslation personBlog, bool isAdmin);
}
