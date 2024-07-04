using System;
using System.IO;
using System.Linq;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Http;

namespace TSTUWebAPI.Controllers.FileControllers
{
    public class FileUploadRepository
    {
        private readonly string fileUploadsPath;

        public FileUploadRepository()
        {
            fileUploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "file-uploads");
        }

        public string SaveFileAsync(IFormFile file, bool isFileSection = false)
        {
            if (file == null || file.Length == 0)
                return null;

            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (!SessionClass.allowedExtensions.Contains(fileExtension))
                return "Invalid file extension!";

            string filePathStr = GetFilePath(fileExtension, isFileSection);

            var filePath = Path.Combine(filePathStr, Guid.NewGuid().ToString() + fileExtension);

            try
            {
                if (!Directory.Exists(filePathStr))
                {
                    Directory.CreateDirectory(filePathStr);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                string newfilePath = GetNewFilePath("/file-uploads/" + filePath);

                return newfilePath;
            }
            catch
            {
                return "Error!";
            }
        }

        private string GetFilePath(string fileExtension, bool isFileSection)
        {
            string basePath = isFileSection ? fileUploadsPath : Path.Combine(fileUploadsPath, "attached");

            if (SessionClass.allowedExtensionsImg.Contains(fileExtension))
                return Path.Combine(basePath, "images");
            else if (SessionClass.allowedExtensionsDoc.Contains(fileExtension))
                return Path.Combine(basePath, "documents");
            else if (SessionClass.allowedExtensionsVideo.Contains(fileExtension))
                return Path.Combine(basePath, "videos");

            return Path.Combine(basePath, "any");
        }

        public bool DeleteFileAsync(string url)
        {
            try
            {
                string filePath = Path.Combine(fileUploadsPath, url);
                File.Delete(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetNewFilePath(string filePath)
        {
            if (filePath == null)
            {
                return null;
            }

            string newPath = filePath.Replace(@"\\", "/");

            newPath = newPath.Replace(@"\", "/");

            return newPath;
        }
    }
}
