using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChildrenPortal.Services.Interfaces;

namespace ChildrenPortal.Controllers
{
    [Route("[controller]/[action]")]
    public class FileController:Controller
    {
        private IFileService Service { get; }
        public FileController(IFileService service)
        {
            Service = service;
        }

        public IActionResult UploadCountry()
        {
            return View();
        }
        [HttpPost]
        public async Task UploadCountry(IFormFile file)
        {
            await Service.UploadCountry(file);
        }

        public IActionResult UploadTransMonee()
        {
            return View();
        }
        [HttpPost]
        public async Task UploadTransMonee(IFormFile file)
        {
            await Service.UploadTransMonee(file);
        }
    }
}