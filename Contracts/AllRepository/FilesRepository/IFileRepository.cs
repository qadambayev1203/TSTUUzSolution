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
        public IEnumerable<Files> AllFile();
        public Files GetFilesById(int id);
        public bool CreateFiles(Files file);
        public bool UpdateFiles(int id, Files file);
        public bool DeleteFiles(int id);



        //FileTranslation CRUD
        public IEnumerable<FilesTranslation> AllFilesTranslation();
        public FilesTranslation GetFilesTranslationById(int id);
        public bool CreateFilesTranslation(FilesTranslation fileTranslation);
        public bool UpdateFilesTranslation(int id, FilesTranslation fileTranslation);
        public bool DeleteFilesTranslation(int id);
    }
}
