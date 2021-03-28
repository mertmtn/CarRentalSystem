using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results; 
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class UploadManager : IUploadService
    { 
        public IDataResult<string> ImageUpload(IFormFile file)
        {            
            return FileHelper.ImageUpload(file);
        }
    }
}
