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
        public bool UpdateFiles(int id, Files file);
        public bool DeleteFiles(int id);
        public IEnumerable<Files> SelectFileTitle(bool? image);


        //FileTranslation CRUD
        public IEnumerable<FilesTranslation> AllFilesTranslation(int queryNum, int pageNum, string language_code);
        public FilesTranslation GetFilesTranslationById(int id);
        public FilesTranslation GetFilesTranslationById(int uz_id, string language_code);
        public FilesTranslation GetFilesTranslationByIdSite(int uz_id, string language_code);
        public int CreateFilesTranslation(FilesTranslation fileTranslation);
        public bool UpdateFilesTranslation(int id, FilesTranslation filesTranslation);
        public bool DeleteFilesTranslation(int id);
        public IEnumerable<FilesTranslation> SelectFileTranslationTitle(bool? image, string language_code);


        public bool SaveChanges();

    }
}
