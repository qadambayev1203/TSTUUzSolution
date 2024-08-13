using Entities.Model.AnyClasses;
using Serilog;

namespace TSTUWebAPI.Controllers.FileControllers;

public class FileUploadRepository
{
    private readonly string[] allowedExtensions = SessionClass.allowedExtensions;
    private readonly string[] allowedExtensionsImg = SessionClass.allowedExtensionsImg;
    private readonly string[] allowedExtensionsDoc = SessionClass.allowedExtensionsDoc;
    private readonly string[] allowedExtensionsVideo = SessionClass.allowedExtensionsVideo;

    private static string fileUploadsPath;

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
            filePath = filePath.Split("file-uploads\\")[1];
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
            if (url is not null)
            {
                fileUploadsPath = GetNewFilePath(fileUploadsPath.Split("\\file-uploads")[0]);
                string filePath = GetNewFilePath(Path.Combine(fileUploadsPath, url.TrimStart('/')));
                File.Delete(filePath);
            }
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to delete file: {FilePath}");
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