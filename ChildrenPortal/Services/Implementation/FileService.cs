using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ChildrenPortal.Services.Interfaces;
using DBRepository.Interfaces;

namespace ChildrenPortal.Services.Implementation
{
    public class FileService : IFileService
    {
        private IFileRepository FileRepository { get; }
        public FileService(IFileRepository fileRepository)
        {
            FileRepository = fileRepository;
        }
        public async Task UploadCountry(IFormFile file)
        {
            await FileRepository.UploadCountry(file);
        }
        public async Task UploadTransMonee(IFormFile file)
        {
            await FileRepository.UploadTransMonee(file);
        }
    }
}
