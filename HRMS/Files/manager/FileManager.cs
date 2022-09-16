namespace HRMS.API.Files.manager
{
    public class FileManager : IFileManager
    {

        public async Task<bool> SaveFile(IFormFile file, string path, string certificateName)
        {
            bool IsSaaveSuccess = false;
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = certificateName+extension;
                var pathBult = Path.Join(Directory.GetCurrentDirectory(), path);
                if (!Directory.Exists(pathBult))
                    Directory.CreateDirectory(pathBult);
                var filePath = Path.Join(Directory.GetCurrentDirectory(), path, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(stream);
                }
                IsSaaveSuccess = true;
            }
            catch (Exception)
            {
                IsSaaveSuccess = false;
            }
            return IsSaaveSuccess;
        }
    }
}
