using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Core.Utilities.FileHelper.Abstract
{
    public interface IFileHelper
    {
        IDataResult<string> UploadFile(List<IFormFile> file);
        IDataResult<string> UploadFileUpdate(IFormFile file);
    }
}
