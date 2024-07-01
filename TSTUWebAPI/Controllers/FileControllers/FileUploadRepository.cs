using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TSTUWebAPI.Controllers.FileControllers
{
    public class FileUploadRepository
    {
        private readonly string[] allowedExtensions = { ".jpg", ".jpeg", ".mp4", ".avi", ".png", ".gif", ".doc", ".docx", ".xlsx", ".pdf", ".ppt", ".pptx" };
        private readonly string[] allowedExtensionsImg = { ".jpg", ".jpeg", ".png", ".gif" };
        private readonly string[] allowedExtensionsDoc = { ".doc", ".docx", ".pdf", ".ppt", ".pptx", ".xlsx" };
        private readonly string[] allowedExtensionsVideo = { ".mp4", ".avi" };

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

            if (!allowedExtensions.Contains(fileExtension))
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

            if (allowedExtensionsImg.Contains(fileExtension))
                return Path.Combine(basePath, "images");
            else if (allowedExtensionsDoc.Contains(fileExtension))
                return Path.Combine(basePath, "documents");
            else if (allowedExtensionsVideo.Contains(fileExtension))
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
