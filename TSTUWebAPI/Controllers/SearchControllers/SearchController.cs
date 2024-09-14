using AutoMapper;
using Contracts.AllRepository.SearchRepository;
using Entities.DTO.BlogsDTOS;
using Entities.DTO.DepartamentDTOS;
using Entities.DTO.PageDTOS;
using Entities.DTO.PersonDataDTOS;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Attributes;

namespace TSTUWebAPI.Controllers.SearchControllers;

[StaticAuth]
[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly ISearchRepository _repository;
    private readonly IMapper _mapper;

    public SearchController(ISearchRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchDatabase(string search_text)
    {
        var token = HttpContext.Request.Headers["Authorization"];

        if (token != SessionClass.tokenCheck && token != SessionClass.token)
        {
            return Unauthorized();
        }

        if (string.IsNullOrEmpty(search_text))
        {
            return BadRequest("Qidiruv matni bo'sh bo'lishi mumkin emas.");
        }



        List<SearchList<object>> lists = new List<SearchList<object>>();
        var searchBlogsMap = await _repository.SearchBlogs(search_text);
        var searchBlogs = _mapper.Map<List<BlogSearchDTO>>(searchBlogsMap);
        SearchList<object> queryListBlog = new SearchList<object>
        {
            length = searchBlogs.Count,
            type = "Bloglar",
            query_list = new List<object>(),
        };
        queryListBlog.query_list.AddRange(searchBlogs);
        lists.Add(queryListBlog);



        var searchDepartamentsMap = await _repository.SearchDepartaments(search_text);
        var searchDepartaments = _mapper.Map<List<DepartamentSearchDTO>>(searchDepartamentsMap);
        SearchList<object> queryListDep = new SearchList<object>
        {
            length = searchDepartaments.Count,
            type = "Bo'limlar",
            query_list = new List<object>(),
        };
        queryListDep.query_list.AddRange(searchDepartaments);
        lists.Add(queryListDep);



        var searchEmployesMap = await _repository.SearchEmployes(search_text);
        var searchEmployes = _mapper.Map<List<PersonDataSearchDTO>>(searchEmployesMap);
        SearchList<object> queryListEmp = new SearchList<object>
        {
            length = searchEmployes.Count,
            type = "Xodimlar",
            query_list = new List<object>(),
        };
        queryListEmp.query_list.AddRange(searchEmployes);
        lists.Add(queryListEmp);




        var searchPagesMap = await _repository.SearchPages(search_text);
        var searchPages = _mapper.Map<List<PageSearchDTO>>(searchPagesMap);
        SearchList<object> queryListPage = new SearchList<object>
        {
            length = searchPages.Count,
            type = "Pagelar",
            query_list = new List<object>(),
        };
        queryListPage.query_list.AddRange(searchPages);
        lists.Add(queryListPage);



        if (!lists.Any())
        {
            return NotFound("Hech qanday mos keluvchi natijalar topilmadi.");
        }

        return Ok(lists);
    }


    [HttpGet("search/{language_code}")]
    public async Task<IActionResult> SearchDatabaseTranslation(string search_text, string language_code)
    {
        var token = HttpContext.Request.Headers["Authorization"];

        if (token != SessionClass.tokenCheck && token != SessionClass.token)
        {
            return Unauthorized();
        }

        if (string.IsNullOrEmpty(search_text))
        {
            return BadRequest("Qidiruv matni bo'sh bo'lishi mumkin emas.");
        }

        List<SearchList<object>> lists = new List<SearchList<object>>();



        var searchBlogsMap = await _repository.SearchBlogsTranslations(search_text, language_code);
        var searchBlogs = _mapper.Map<List<BlogTranslationSearchDTO>>(searchBlogsMap);
        SearchList<object> queryListBlog = new SearchList<object>
        {
            length = searchBlogs.Count,
            type = "Blogs",
            query_list = new List<object>(),
        };
        queryListBlog.query_list.AddRange(searchBlogs);
        lists.Add(queryListBlog);



        var searchDepartamentsMap = await _repository.SearchDepartamentsTranslations(search_text, language_code);
        var searchDepartaments = _mapper.Map<List<DepartamentTranslationSearchDTO>>(searchDepartamentsMap);
        SearchList<object> queryListDep = new SearchList<object>
        {
            length = searchDepartaments.Count,
            type = "Departaments",
            query_list = new List<object>(),
        };
        queryListDep.query_list.AddRange(searchDepartaments);
        lists.Add(queryListDep);



        var searchEmployesMap = await _repository.SearchEmployesTranslations(search_text, language_code);
        var searchEmployes = _mapper.Map<List<PersonDataTranslationSearchDTO>>(searchEmployesMap);
        SearchList<object> queryListEmp = new SearchList<object>
        {
            length = searchEmployes.Count,
            type = "Employees",
            query_list = new List<object>(),
        };
        queryListEmp.query_list.AddRange(searchEmployes);
        lists.Add(queryListEmp);



        var searchPagesMap = await _repository.SearchPagesTranslations(search_text, language_code);
        var searchPages = _mapper.Map<List<PageTranslationSearchDTO>>(searchPagesMap);
        SearchList<object> queryListPage = new SearchList<object>
        {
            length = searchPages.Count,
            type = "Pages",
            query_list = new List<object>(),
        };
        queryListPage.query_list.AddRange(searchPages);
        lists.Add(queryListPage);


        if (!lists.Any())
        {
            return NotFound("Hech qanday mos keluvchi natijalar topilmadi.");
        }

        return Ok(lists);
    }

}
