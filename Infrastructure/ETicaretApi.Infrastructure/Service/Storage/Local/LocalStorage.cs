using ETicaretApi.Application.Abstractions.Storage.Local;
using ETicaretApi.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ETicaretApi.Infrastructure.Service.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public bool HasFile(string path, string fileName)
                => File.Exists($"{path}\\{fileName}");

        public async Task DeleteAsync(string path, string fileName)
                => File.Delete($"{path}\\{fileName}");


        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }



        //public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainer, IFormFileCollection files)
        //{
        //    string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/product-images");

        //    if (!Directory.Exists(uploadPath))
        //        Directory.CreateDirectory(uploadPath);

        //    Random r = new();

        //    foreach (IFormFile file in files)
        //    {
        //        string fullPath = Path.Combine(uploadPath, $"{r.Next()}{Path.GetExtension(file.FileName)}");
        //        using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
        //        await file.CopyToAsync(fileStream);
        //        await fileStream.FlushAsync();
        //    }
        //    return null;
        //}
        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainer, IFormFileCollection files)
        {
            foreach (var file in files)
            {
                string filename = file.FileName;
                filename = filename.Length <= 64 ? (filename) : (filename.Substring(filename.Length - 64, 64));
                filename = Guid.NewGuid().ToString() + filename;
                string path = Path.Combine(_webHostEnvironment.WebRootPath,pathOrContainer, filename);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }


            return null;
        }
    }
}
