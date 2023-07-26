using Firebase.Storage;
using GetTogether.BLL.Interfaces;
using GetTogether.Common.DTO.Image;
using GetTogether.DAL.Context;
using AutoMapper;

namespace GetTogether.BLL.Services;

public class StorageService : BaseService, IStorageService
{
    private FirebaseStorage _storage;
    private readonly IAccountService _accountService;

    public StorageService(
        DataContext context,
        IMapper mapper,
        IAccountService accountService) : base(context, mapper)
    {
        _accountService = accountService;
    }
    public void SetToken(string bucketName, string firebaseAuthToken)
    {
        _storage = new FirebaseStorage(bucketName, new FirebaseStorageOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult(firebaseAuthToken)
        });
    }

    public async Task<string> UploadImageAsync(NewImageDTO img)
    {
        var url = await _storage.Child(img.Type.ToString()).Child(img.FileName).PutAsync(img.Stream);
        var user = await _context.Users.FindAsync(_accountService.UserId);

        if (user != null)
        {
            user.ImageAvatar = new() { Url = url };
            await _context.SaveChangesAsync();
        }
       
        return url;
    }

    public async Task<string> GetImageAsync(string folderName, string fileName)
    {
        var url = await _storage.Child(folderName).Child(fileName).GetDownloadUrlAsync();
        return url;
    }
}

