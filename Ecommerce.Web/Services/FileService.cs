namespace Ecommerce.Web.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        #region Helpers
        private string GetFileName(IFormFile file)
        {
            return $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
        }
        private string GetFolderPath(string folderName)
        {
            return Path.Combine(_webHostEnvironment.WebRootPath, folderName);
        }
        #endregion

        public string UploadFile(string folderName, IFormFile file)
        {
            var folderPath = GetFolderPath(folderName);
            var fileName = GetFileName(file);
            var filePath = Path.Combine(folderPath, fileName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return Path.Combine(folderName, fileName);
        }

        public void DeleteFile(string? filePath)
        {
            if (filePath != null)
            {
                var folderPath = GetFolderPath(filePath);
                if (File.Exists(folderPath))
                {
                    File.Delete(folderPath);
                }
            }
        }
    }
}
