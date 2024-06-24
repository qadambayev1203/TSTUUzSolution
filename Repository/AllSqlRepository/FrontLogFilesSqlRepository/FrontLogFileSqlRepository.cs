using Contracts.AllRepository.FrontLogFilesRepository;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.FrontLogFilesSqlRepository
{
    public class FrontLogFileSqlRepository : IFrontLogFileRepository
    {
        private readonly ILogger<FrontLogFileSqlRepository> _logger;
        public FrontLogFileSqlRepository(ILogger<FrontLogFileSqlRepository> logger)
        {
            _logger = logger;
        }

        public bool LogFileCreated(Exception ex)
        {
            try
            {
                _logger.LogError("Error <Front>" + ex.ToString());
                return true;
            }
            catch (Exception ex1)
            {
                _logger.LogError("Error " + ex1.ToString());
                return false;
            }
        }
    }
}
