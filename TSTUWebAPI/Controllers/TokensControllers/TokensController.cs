using AutoMapper;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Contracts.AllRepository.TokensRepository;
using Entities.DTO.TokensDTOS;
using Entities.Model.TokensModel;
using TSTUWebAPI.Attributes;
using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.FileModel;
using TSTUWebAPI.Controllers.FileControllers;
using Contracts.AllRepository.StatusesRepository;

namespace TSTUWebAPI.Controllers.TokensControllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly ITokensRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public TokensController(ITokensRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // tokens CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createtokens")]
        public IActionResult Createtokens(TokensCreatedDTO tokens1)
        {
            var tokens = _mapper.Map<Tokens>(tokens1);
            tokens.status_id = _status.GetStatusId("Active");
            int check = _repository.CreateTokens(tokens);

            if (check == 0)
            {
                return BadRequest();
            }

            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = check,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getalltokens")]
        public IActionResult GetAlltokens(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Tokens> tokenss1 = _repository.AllTokens(queryNum, pageNum);
            var tokenss = _mapper.Map<IEnumerable<TokensReadedDTO>>(tokenss1);
            return Ok(tokenss);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidtokens/{id}")]
        public IActionResult GetByIdtokens(int id)
        {

            Tokens tokens1 = _repository.GetTokensById(id);
            var tokens = _mapper.Map<TokensReadedDTO>(tokens1);
            return Ok(tokens);
        }

        [StaticAuth]
        [HttpGet("sitegetalltokens")]
        public IActionResult GetAlltokenssite(int queryNum, int pageNum)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (token == SessionClass.tokenCheck || token == SessionClass.token)
            {
                queryNum = Math.Abs(queryNum);
                pageNum = Math.Abs(pageNum);
                IEnumerable<Tokens> tokenss1 = _repository.AllTokensSite(queryNum, pageNum);
                var tokenss = _mapper.Map<IEnumerable<TokensReadedSiteDTO>>(tokenss1);
                return Ok(tokenss);

            }
            return Unauthorized();

        }

        [StaticAuth]
        [HttpGet("sitegetbyidtokens/{id}")]
        public IActionResult GetByIdtokenssite(int id)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (token == SessionClass.tokenCheck || token == SessionClass.token)
            {
                Tokens tokens1 = _repository.GetTokensByIdSite(id);
                var tokens = _mapper.Map<TokensReadedSiteDTO>(tokens1);
                return Ok(tokens);

            }
            return Unauthorized();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletetokens/{id}")]
        public IActionResult Deletetokens(int id)
        {
            bool check = _repository.DeleteTokens(id);
            if (!check)
            {
                return BadRequest();
            }
            bool check1 = _repository.SaveChanges();
            if (!check1)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updatetokens/{id}")]
        public IActionResult Updatetokens(TokensUpdatedDTO tokens1, int id)
        {
            try
            {
                if (tokens1 == null)
                {
                    return BadRequest();
                }

                var tokens = _mapper.Map<Tokens>(tokens1);

                bool updatedcheck = _repository.UpdateTokens(id, tokens);
                if (!updatedcheck)
                {
                    return BadRequest();
                }
                bool check = _repository.SaveChanges();
                if (!check)
                {
                    return BadRequest();
                }
                return Ok("Updated");
            }
            catch
            {
                return BadRequest();
            }

        }


    }
}
