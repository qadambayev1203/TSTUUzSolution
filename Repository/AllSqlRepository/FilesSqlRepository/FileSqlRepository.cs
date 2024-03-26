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
                    files = _context.files_20ts24tu.Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    files = _context.files_20ts24tu.Include(x => x.user_).ThenInclude(y => y.user_type_).Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    files = _context.files_20ts24tu.Include(x => x.user_).ThenInclude(y => y.user_type_).Include(x => x.status_).ToList();

                }
                return files;
            }
            catch
            {
                return Enumerable.Empty<Files>();
            }
        }

        public int CreateFiles(Files file)
        {
            try
            {
                if (file == null)
                {
                    return 0;
                }
                file.crated_at = DateTime.UtcNow;
                _context.files_20ts24tu.Add(file);
                _context.SaveChanges();
                return file.id;
            }
            catch
            {
                return 0;
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
                var file = _context.files_20ts24tu.Include(x => x.user_).ThenInclude(y => y.user_type_).Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
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

                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Files> SelectFileTitle()
        {
            try
            {
                var files = new List<Files>();
                files = _context.files_20ts24tu
                    .Select(x => new Files
                    {
                        id = x.id,
                        title = x.title
                    }).ToList();
                return files;
            }
            catch
            {
                return null;
            }
        }





        //FileTranslations CRUD
        public IEnumerable<FilesTranslation> AllFilesTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var filesTranslations = new List<FilesTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    filesTranslations = _context.files_translations_20ts24tu.Include(x => x.files_).Include(x => x.status_translation_).Include(x => x.language_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    filesTranslations = _context.files_translations_20ts24tu.Include(x => x.files_).Include(x => x.status_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Include(x => x.language_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    filesTranslations = _context.files_translations_20ts24tu.Include(x => x.files_).Include(x => x.status_translation_).Include(x => x.language_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return filesTranslations;
            }
            catch
            {
                return new List<FilesTranslation>();
            }
        }

        public int CreateFilesTranslation(FilesTranslation fileTranslation)
        {
            try
            {
                if (fileTranslation == null)
                {
                    return 0;
                }
                _context.files_translations_20ts24tu.Add(fileTranslation);
                _context.SaveChanges();

                return fileTranslation.id;
            }
            catch
            {
                return 0;
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
                var fileTranslation = _context.files_translations_20ts24tu.Include(x => x.files_).Include(x => x.status_translation_).Include(x => x.language_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .FirstOrDefault(x => x.id.Equals(id));
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


                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<FilesTranslation> SelectFileTranslationTitle(string language_code)
        {
            try
            {
                var files = new List<FilesTranslation>();
                files = _context.files_translations_20ts24tu
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Select(x => new FilesTranslation
                    {
                        id = x.id,
                        title = x.title
                    }).ToList();

                return files;
            }
            catch
            {
                return null;
            }
        }

        public bool SaveChanges()
        {
            try { _context.SaveChanges(); return true; } catch { return false; }
        }



    }
}
