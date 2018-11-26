using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DBRepository.Interfaces
{
    public interface IFileRepository
    {
        Task UploadTransMonee(IFormFile file);
        Task UploadCountry(IFormFile file);
        //Task UploadSignificate(IFormFile file);

    }
}
