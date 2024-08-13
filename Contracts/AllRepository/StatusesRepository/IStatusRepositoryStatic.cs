namespace Contracts.AllRepository.StatusesRepository;

public interface IStatusRepositoryStatic
{
    public int GetStatusId(string status);        
    public int GetStatusTranslationId(string status, int language_id);     
    public bool SaveChanges();
}
