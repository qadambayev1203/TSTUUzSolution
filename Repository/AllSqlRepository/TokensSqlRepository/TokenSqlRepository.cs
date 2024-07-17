using Contracts.AllRepository.TokensRepository;
using Entities;
using Entities.Model;
using Entities.Model.TokensModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;

namespace Repository.AllSqlRepository.TokensSqlRepository
{
    public class TokenSqlRepository : ITokensRepository
    {

        private readonly RepositoryContext _context;
        private readonly ILogger<TokenSqlRepository> _logger;
        public TokenSqlRepository(RepositoryContext repositoryContext, ILogger<TokenSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }

        public IEnumerable<Tokens> AllTokens(int queryNum, int pageNum)
        {
            try
            {
                var tokens = new List<Tokens>();
                if (queryNum == 0 && pageNum != 0)
                {
                    tokens = _context.tokens_20ts24tu.Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    tokens = _context.tokens_20ts24tu.Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    tokens = _context.tokens_20ts24tu.Include(x => x.status_).ToList();

                }
                return tokens;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public IEnumerable<Tokens> AllTokensSite(int queryNum, int pageNum)
        {
            try
            {
                var tokens = new List<Tokens>();
                if (queryNum == 0 && pageNum != 0)
                {
                    tokens = _context.tokens_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    tokens = _context.tokens_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    tokens = _context.tokens_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).ToList();

                }
                return tokens;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }


        public int CreateTokens(Tokens Tokens)
        {
            try
            {

                if (Tokens == null)
                {
                    return 0;
                }
                Tokens.status_id = 1;
                _context.tokens_20ts24tu.Add(Tokens);
                _context.SaveChanges();
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(Tokens));

                return Tokens.id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return 0;
            }
        }

        public bool DeleteTokens(int id)
        {
            try
            {
                var Tokens = GetTokensById(id);
                if (Tokens == null)
                {
                    return false;
                }
                Tokens.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.tokens_20ts24tu.Update(Tokens);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(Tokens));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);

                return false;
            }
        }

        public Tokens GetTokensByIdSite(int id)
        {
            try
            {
                var Tokens = _context.tokens_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
                return Tokens;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }
         public Tokens GetTokensById(int id)
        {
            try
            {
                var Tokens = _context.tokens_20ts24tu.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
                return Tokens;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public bool UpdateTokens(int id, Tokens Tokens)
        {
            try
            {
                var tokenscheck = GetTokensById(id);
                if (tokenscheck is null)
                {
                    return false;
                }
                tokenscheck.title = Tokens.title;
                tokenscheck.token = Tokens.token;
                tokenscheck.status_id = Tokens.status_id;
                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(tokenscheck));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return false;
            }
        }

        public bool SaveChanges()
        {
            try { _context.SaveChanges(); return true; }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message); return false;
            }
        }
    }
}
