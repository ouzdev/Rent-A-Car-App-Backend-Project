using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelper.Abstract
{
    public interface IFileHelper
    {
        IDataResult<string> UploadFile(IFormFile file);
        IDataResult<string> UploadFileUpdate(IFormFile file);
    }
}
