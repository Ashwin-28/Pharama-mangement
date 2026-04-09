namespace Pharma_backend
{
    public interface IFileService
    {
        Task<string> SavePrescriptionAsync(IFormFile file);
    }
}
