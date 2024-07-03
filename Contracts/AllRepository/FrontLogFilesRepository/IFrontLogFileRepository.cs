
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.FrontLogFilesRepository
{
    public interface IFrontLogFileRepository
    {
        public bool LogFileCreated(Exception ex);
    }
}
