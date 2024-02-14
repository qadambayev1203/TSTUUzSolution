namespace TSTUWebAPI.Controllers.FileControllers
{
    public class FileUploadRepository
    {
        private readonly string[] allowedExtensions = { ".jpg", ".jpeg", ".mp4", ".avi", ".png", ".doc", ".xlsx", ".docx", ".pdf", ".ppt", ".pptx" };
        private readonly string[] allowedExtensionsImg = { ".jpg", ".jpeg", ".png" };
        private readonly string[] allowedExtensionsDoc = { ".doc", ".docx", ".pdf", ".ppt", ".pptx", ".xlsx" };
        private readonly string[] allowedExtensionsVideo = { ".mp4", ".avi" };


        public string SaveFileAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return ("File not found or empty!");

                var fileExtension = Path.GetExtension(file.FileName).ToLower();

                if (!allowedExtensions.Contains(fileExtension))
                    return ("Invalid file extension!");

                var filePathStr = "uploads/any";

                if (allowedExtensionsImg.Contains(fileExtension))
                {
                    filePathStr = "uploads/images";
                }
                else if (allowedExtensionsDoc.Contains(fileExtension))
                {
                    filePathStr = "uploads/documents";
                }
                else if (allowedExtensionsVideo.Contains(fileExtension))
                {
                    filePathStr = "uploads/videos";
                }
                var filePath = Path.Combine(filePathStr, Guid.NewGuid().ToString() + fileExtension);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return filePath;
            }
            catch
            {
                return "Error!";
            }
        }
    }
}
