using CloudStorageTest.Domain.Entities;
using CloudStorageTest.Domain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace CloudStorageTest.Application.UseCases.Users.UploadProfilePhoto;

public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
{
    private readonly IStorageService _storageService;
    public UploadProfilePhotoUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public void Execute(IFormFile file)
    {
        var fileStream = file.OpenReadStream();

        var isImage = fileStream.Is<JointPhotographicExpertsGroup>();

        if (isImage == false)
            throw new Exception("The file is not an image.");

        var user = GetFromDatabase();

        _storageService.Upload(file, user);
    }

    private User GetFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = "Giovana",
            Email = "gi.trevizan.barbosa@gmail.com",
            RefreshToken = "1//04rp8qFOyM5arCgYIARAAGAQSNwF-L9Ir0yfB-LZWEV850Vm4p7iTv3CLGHnapnnnJmp_60y4sbN2yG8qVh8LfP6KTLaHAhxw0h0",
            AccessToken = "ya29.a0Ad52N38LWvnNTFoT0JP-C41aZ5yhcdktU_F4WU69AbwKIMBAiIsSL6UgRbrZP67amL6Z10bYNjISvpklA7qIM9FGv6RQYjpH7Qzg7xNwBJnCiAFhnVEVU7CoziPwZtG5IR-S5rsWhdfdZ8d6EiiDVC1xBD4xz0b50gHDaCgYKAesSARMSFQHGX2MiziUaFvJjvCr25pW9PBLNpA0171"
        };
    }
}
