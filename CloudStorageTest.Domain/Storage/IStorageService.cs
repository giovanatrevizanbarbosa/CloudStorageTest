using CloudStorageTest.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CloudStorageTest.Domain.Storage;
public interface IStorageService
{
    public string Upload(IFormFile file, User user);
}
