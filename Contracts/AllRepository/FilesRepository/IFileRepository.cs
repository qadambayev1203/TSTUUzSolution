using Entities.Model.FileModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.FilesRepository
{
    public interface IFileRepository
    {
        //File CRUD
        public IEnumerable<Files> AllFile(int queryNum, int pageNum);
        public Files GetFilesById(int id);
        public int CreateFiles(Files file);
        public bool UpdateFiles();
        public bool DeleteFiles(int id);



        //FileTranslation CRUD
        public IEnumerable<FilesTranslation> AllFilesTranslation(int queryNum, int pageNum, string language_code);
        public FilesTranslation GetFilesTranslationById(int id);
        public int CreateFilesTranslation(FilesTranslation fileTranslation);
        public bool UpdateFilesTranslation();
        public bool DeleteFilesTranslation(int id);

        public bool SaveChanges();

    }
}
