namespace GameZone.Services.Interfaces
{
    public interface IAttachmentService
    {
        public Task<string> UploadAttachmentAsync(IFormFile file);
        public Task DeleteAttachmentAsync(string fileName);
    }
}
