using ETicaretApi.Application.Abstractions;
using ETicaretApi.Application.Abstractions.Storage;
using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Application.Repositories.ProductImage;
using ETicaretApi.Application.Services;
using ETicaretApi.Application.ViewModels.Products;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Persistence.Repositories.Product;
using ETicaretApi.Persistence.Repositories.ProductImage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing.Constraints;
using System.IO;
using System.Net;

namespace ETicaretApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductImageWriteRepository _productImageFileWriteRepository;
        private readonly IProductImageReadRepository _productImageRead;
        private readonly IProductImageReadRepository _productImageReadRepository;
        private readonly IStorageService _storageService;
        private readonly IFileService _fileService;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductImageReadRepository productImageRead, IProductImageReadRepository productImageReadRepository, IStorageService storageService, IFileService fileService, IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IWebHostEnvironment webHostEnvironment, IProductImageWriteRepository productImageFileWriteRepository)
        {
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productImageRead = productImageRead;
            _productImageReadRepository = productImageReadRepository;
            _storageService = storageService;
            _fileService = fileService;
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_productReadRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

        //[HttpGet("")]
        //public List<string> GetImage()
        //{

        //    var images = _storageService.GetFiles("files");
        //    return images;
        //}


        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductCreateVM productVM)
        {
            if (!ModelState.IsValid)
            {
                foreach (var errors in ModelState.Values)
                {
                    foreach (var error in errors.Errors)
                    {
                        return Ok(error.ErrorMessage);
                    }
                }
            }
            var newProduct = await _productWriteRepository.AddAsync(new()
            {
                Name = productVM.Name,
                Price = productVM.Price,
                Stock = productVM.Stock,
            });
            await _productWriteRepository.SaveAsync();

            var paths = await _storageService.UploadAsync("files", Request.Form.Files);

            var newProductImages = productVM.ImageFiles.Select((image, index) => new ProductImageFile
            {
                ProductId = newProduct.Id,
                Image = image.Name,
                Path = paths.ElementAtOrDefault(index).fileName
            }).ToList();

            await _productImageFileWriteRepository.AddRangeAsync(newProductImages);
            await _productImageFileWriteRepository.SaveAsync();

            //foreach (var image in productVM.ImageFiles)
            //{
            //    ProductImageFile newPrdImage = new()
            //    {
            //        ProductId = newProduct.Id,
            //        Image = image.Name,
            //    };


            //    if (await _productImageFileWriteRepository.AddExistAsync(newPrdImage))
            //    {
            //        //await Uplaod(productVM.ImageFiles);
            //        var paths = await _storageService.UploadAsync("files", Request.Form.Files);
            //        foreach (var path in paths)
            //        {
            //            newPrdImage.Path = path.fileName;
            //        }
            //        await _productImageFileWriteRepository.SaveAsync();
            //    }


            //}
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductUpdateVM updateVM)
        {
            Product product = await _productReadRepository.GetByIdAsync(updateVM.Id);
            product.Stock = updateVM.Stock;
            product.Name = updateVM.Name;
            product.Price = updateVM.Price;
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.OK);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _productWriteRepository.RemoveAsync(id);
        //    await _productWriteRepository.SaveAsync();
        //    return StatusCode((int)HttpStatusCode.Accepted);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _productReadRepository.IsExistAsync(id))
                return Ok("tapilmadi");
            foreach (var image in _productImageRead.GetWhere(x => x.ProductId == id).ToList())
            {
                await _productImageFileWriteRepository.RemoveAsync(image.Id);
                await _storageService.DeleteAsync("files", image.Path);

            }
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();

            return StatusCode((int)HttpStatusCode.Accepted);
        }


        [HttpPost("[action]")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Uplaod([FromForm] List<IFormFile> formFiles)
        {

            //await _fileService.UploadAsync("resource/productImages", Request.Form.Files);
            var images = await _storageService.UploadAsync("files", Request.Form.Files);
            //await _storageService.UploadAsync("resource/productImages", Request.Form.Files);


            return Ok();
        }
    }
}
