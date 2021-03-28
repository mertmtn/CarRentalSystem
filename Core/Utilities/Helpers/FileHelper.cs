using Core.Utilities.Messages;
using Core.Utilities.Results;
using Core.Utilities.Results.Error;
using Core.Utilities.Results.Success;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {

        private static string _currentDirectory = Environment.CurrentDirectory;
        private static string _folderName = "\\Resources" + "\\Images\\";

        public static IDataResult<string> ImageUpload(IFormFile file)
        {
            var type = Path.GetExtension(file.FileName).ToLower();
            var typeValid = CheckImageFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid.Message != null) return new ErrorDataResult<string>(typeValid.Message);

            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessDataResult<string>(
                (_folderName + randomName + type).Replace("\\", "/"),
                FileHelperMessage.ImageUploadSuccessfully);
        }


        private static IResult CheckImageFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult(FileHelperMessage.ImageFileNotValid);
            }
            return new SuccessResult();
        }

        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static void CreateFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }


    }
}

