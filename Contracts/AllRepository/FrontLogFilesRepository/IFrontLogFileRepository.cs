namespace Contracts.AllRepository.FrontLogFilesRepository;

public interface IFrontLogFileRepository
{
    public bool LogFileCreated(Exception ex);
}
