using Contracts.AllRepository.FilesRepository;
using Entities;
using Entities.Model.FileModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AllSqlRepository.FilesSqlRepository
{
    public class FileSqlRepository : IFileRepository
    {
        private readonly RepositoryContext _context;
        public FileSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        //File CRUD
        public IEnumerable<Files> AllFile()
        {
            var files = new List<Files>();
            files = _context.files_20ts24tu.Include(x=>x.user_).Include(x=>x.status_).ToList();
            return files;
        }

        public bool CreateFiles(Files file)
        {
            if (file == null)
            {
                return false;
            }
            _context.files_20ts24tu.Add(file);
            _context.SaveChanges();
            return true;

        }

        public bool DeleteFiles(int id)
        {
            var file = GetFilesById(id);
            if (file == null)
            {
                return false;
            }
            _context.files_20ts24tu.Update(file);
            _context.SaveChanges();

            return true;
        }

        public Files GetFilesById(int id)
        {
            var file = _context.files_20ts24tu.Include(x => x.user_).Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
            return file;
        }

        public bool UpdateFiles(int id, Files file)
        {
            var fileCheck = GetFilesById(id);
            if (fileCheck == null)
            {
                return false;
            }
            _context.files_20ts24tu.Update(file);
            _context.SaveChanges();

            return true;
        }





        //FileTranslations CRUD
        public IEnumerable<FilesTranslation> AllFilesTranslation()
        {
            var filesTranslations = new List<FilesTranslation>();
            filesTranslations = _context.files_translations_20ts24tu.Include(x => x.files_).Include(x => x.status_translation_).Include(x => x.languages_).ToList();
            return filesTranslations;
        }

        public bool CreateFilesTranslation(FilesTranslation fileTranslation)
        {
            if (fileTranslation == null)
            {
                return false;
            }
            _context.files_translations_20ts24tu.Add(fileTranslation);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteFilesTranslation(int id)
        {
            var fileTranslation = GetFilesTranslationById(id);
            if (fileTranslation == null)
            {
                return false;
            }
            _context.files_translations_20ts24tu.Update(fileTranslation);
            _context.SaveChanges();

            return true;
        }

        public FilesTranslation GetFilesTranslationById(int id)
        {
            var fileTranslation = _context.files_translations_20ts24tu.Include(x => x.files_).Include(x => x.status_translation_).Include(x => x.languages_).FirstOrDefault(x => x.id.Equals(id));
            return fileTranslation;
        }

        public bool UpdateFilesTranslation(int id, FilesTranslation fileTranslation)
        {
            var fileTranslationCheck = GetFilesTranslationById(id);
            if (fileTranslationCheck == null)
            {
                return false;
            }
            _context.files_translations_20ts24tu.Update(fileTranslation);
            _context.SaveChanges();

            return true;
        }

    }
}
