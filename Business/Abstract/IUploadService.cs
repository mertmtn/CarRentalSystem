using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IUploadService
    { 
        IDataResult<string> ImageUpload(IFormFile file);
    }
}
