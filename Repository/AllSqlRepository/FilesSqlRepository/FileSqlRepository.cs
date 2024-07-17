using Contracts.AllRepository.FilesRepository;
using Entities;
using Entities.Model.AnyClasses;
using Entities.Model.FileModel;
using Entities.Model.SitesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repository.AllSqlRepository.FilesSqlRepository
{
    public class FileSqlRepository : IFileRepository
    {
        private readonly string[] allowedExtensionsImg = SessionClass.allowedExtensionsImg;
        private readonly string[] allowedExtensionsFile = SessionClass.allowedExtensionsFile;

        private readonly RepositoryContext _context;
        private readonly ILogger<FileSqlRepository> _logger;
        public FileSqlRepository(RepositoryContext repositoryContext, ILogger<FileSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
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
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
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
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(file));
                return file.id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
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
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(file));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
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
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public bool UpdateFiles(int id, Files file)
        {

            try
            {
                var filescheck = GetFilesById(id);
                if (filescheck is null)
                {
                    return false;
                }
                filescheck.title = file.title;
                if (file.url != null)
                {
                    filescheck.url = file.url;
                }
                filescheck.status_id = file.status_id;
                filescheck.updated_at = DateTime.UtcNow;
                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(filescheck));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return false;
            }
        }

        public IEnumerable<Files> SelectFileTitle(bool? image)
        {
            try
            {
                var files = _context.files_20ts24tu
                    .Where(x => x.status_.status != "Deleted" && !x.url.Contains("attached"))
                    .Where(image != null
                        ? image == true
                            ? y => allowedExtensionsImg.Any(ext => y.url.EndsWith(ext))
                            : y => allowedExtensionsFile.Any(ext => y.url.EndsWith(ext))
                        : y => y.url != null)
                    .Select(x => new Files
                    {
                        id = x.id,
                        title = x.title,
                        url = x.url
                    })
                    .ToList();

                return files;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
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
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
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
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(fileTranslation));

                return fileTranslation.id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
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
                fileTranslation.status_translation_id = (_context.statuses_translations_20ts24tu
                    .FirstOrDefault(x => x.status == "Deleted" && x.language_id == fileTranslation.language_id)).id;
                _context.files_translations_20ts24tu.Update(fileTranslation);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(fileTranslation));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
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
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }
        public FilesTranslation GetFilesTranslationById(int uz_id, string language_code)
        {
            try
            {
                var fileTranslation = _context.files_translations_20ts24tu.Include(x => x.files_).Include(x => x.status_translation_).Include(x => x.language_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .FirstOrDefault(x => x.files_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return fileTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public FilesTranslation GetFilesTranslationByIdSite(int uz_id, string language_code)
        {
            try
            {
                var fileTranslation = _context.files_translations_20ts24tu.Include(x => x.files_).Include(x => x.status_translation_).Include(x => x.language_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Where(x => !x.url.StartsWith("file-uploads/attached"))
                        .Where(x => x.status_translation_.status != "Deleted")
                    .FirstOrDefault(x => x.files_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return fileTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public bool UpdateFilesTranslation(int id, FilesTranslation filesTranslation)
        {
            try
            {
                var filescheck = GetFilesTranslationById(id);
                if (filescheck is null)
                {
                    return false;
                }
                filescheck.title = filesTranslation.title;
                if (filesTranslation.url != null)
                {
                    filescheck.url = filesTranslation.url;
                }
                filescheck.status_translation_id = filesTranslation.status_translation_id;
                filescheck.language_id = filesTranslation.language_id;
                filescheck.files_id = filesTranslation.files_id;
                filescheck.updated_at = DateTime.UtcNow;
                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(filescheck));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return false;
            }
        }

        public IEnumerable<FilesTranslation> SelectFileTranslationTitle(bool? image, string language_code)
        {
            try
            {
                var files = new List<FilesTranslation>();
                files = _context.files_translations_20ts24tu
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Where(x => x.status_translation_.status != "Deleted" && !x.url.Contains("attached"))
                    .Where(image != null
                        ? image == true
                            ? y => allowedExtensionsImg.Any(ext => y.url.EndsWith(ext))
                            : y => allowedExtensionsFile.Any(ext => y.url.EndsWith(ext))
                        : y => y.url != null).Select(x => new FilesTranslation
                        {
                            id = x.id,
                            title = x.title,
                            files_id = x.files_id,
                            url = x.url,
                        }).ToList();

                return files;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return Enumerable.Empty<FilesTranslation>();
            }
        }

        public bool SaveChanges()
        {
            try { _context.SaveChanges(); return true; }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message); return false;
            }
        }



    }
}
