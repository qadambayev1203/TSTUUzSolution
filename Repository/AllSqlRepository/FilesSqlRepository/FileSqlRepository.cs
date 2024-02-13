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
        public IEnumerable<Files> AllFile(int queryNum, int pageNum)
        {
            try
            {
                var files = new List<Files>();
                if (queryNum == 0 && pageNum != 0)
                {
                    files = _context.files_20ts24tu.Include(x => x.user_).Include(x => x.status_).Skip(10 * (pageNum-1)).Take(10).ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    files = _context.files_20ts24tu.Include(x => x.user_).Include(x => x.status_).Take(queryNum).ToList();

                }
                else
                {
                    files = _context.files_20ts24tu.Include(x => x.user_).Include(x => x.status_).Take(200).ToList();

                }
                return files;
            }
            catch
            {
                return Enumerable.Empty<Files>();
            }
        }

        public bool CreateFiles(Files file)
        {
            try
            {
                if (file == null)
                {
                    return false;
                }
                file.crated_at = DateTime.UtcNow;
                _context.files_20ts24tu.Add(file);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteFiles(int id)
        {
            try
            {
                var file = GetFilesById(id);
                if (file == null)
                {
                    return false;
                }
                file.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.files_20ts24tu.Update(file);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Files GetFilesById(int id)
        {
            try
            {
                var file = _context.files_20ts24tu.Include(x => x.user_).Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
                return file;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateFiles()
        {

            try
            {
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }





        //FileTranslations CRUD
        public IEnumerable<FilesTranslation> AllFilesTranslation(int queryNum, int pageNum)
        {
            try
            {
                var filesTranslations = new List<FilesTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    filesTranslations = _context.files_translations_20ts24tu.Include(x => x.files_).Include(x => x.status_translation_).Include(x => x.languages_).Skip(10*(pageNum-1)).Take(10).ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    filesTranslations = _context.files_translations_20ts24tu.Include(x => x.files_).Include(x => x.status_translation_).Include(x => x.languages_).Take(queryNum).ToList();

                }
                else
                {
                    filesTranslations = _context.files_translations_20ts24tu.Include(x => x.files_).Include(x => x.status_translation_).Include(x => x.languages_).Take(200).ToList();

                }
                return filesTranslations;
            }
            catch
            {
                return new List<FilesTranslation>();
            }
        }

        public bool CreateFilesTranslation(FilesTranslation fileTranslation)
        {
            try
            {
                if (fileTranslation == null)
                {
                    return false;
                }
                _context.files_translations_20ts24tu.Add(fileTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFilesTranslation(int id)
        {
            try
            {
                var fileTranslation = GetFilesTranslationById(id);
                if (fileTranslation == null)
                {
                    return false;
                }
                fileTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.files_translations_20ts24tu.Update(fileTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public FilesTranslation GetFilesTranslationById(int id)
        {
            try
            {
                var fileTranslation = _context.files_translations_20ts24tu.Include(x => x.files_).Include(x => x.status_translation_).Include(x => x.languages_).FirstOrDefault(x => x.id.Equals(id));
                return fileTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateFilesTranslation()
        {
            try
            {

                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
