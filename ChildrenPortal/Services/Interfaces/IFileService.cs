using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ChildrenPortal.Services.Interfaces
{
    public interface IFileService
    {
        Task UploadCountry(IFormFile file);
        Task UploadTransMonee(IFormFile file);
    }
}
