using GetTogether.Common.DTO.Image;

namespace GetTogether.BLL.Interfaces;

public interface IStorageService
{
    public Task<string> UploadImageAsync(NewImageDTO img);
}
