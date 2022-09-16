
namespace HRMS.API.Files.manager
{
    public interface IFileManager
    {
        Task<bool> SaveFile(IFormFile file, string path, string certifcateName);
    }
}