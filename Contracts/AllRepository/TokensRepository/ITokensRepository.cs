using Entities.Model.TokensModel;

namespace Contracts.AllRepository.TokensRepository;

public interface ITokensRepository
{
    //Tokens CRUD
    public IEnumerable<Tokens> AllTokens(int queryNum, int pageNum);
    public IEnumerable<Tokens> AllTokensSite(int queryNum, int pageNum);
    public Tokens GetTokensById(int id);
    public Tokens GetTokensByIdSite(int id);
    public int CreateTokens(Tokens Tokens);
    public bool UpdateTokens(int id, Tokens Tokens);
    public bool DeleteTokens(int id);
    public bool SaveChanges();

}
