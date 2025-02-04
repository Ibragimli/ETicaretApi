using ETicaretApi.Application.Abstractions.Storage;
using ETicaretApi.Application.Consts;
using ETicaretApi.Application.CustomAttributes;
using ETicaretApi.Application.Enums;
using ETicaretApi.Application.Features.Commands.Product.DeleteProduct;
using ETicaretApi.Application.Features.Commands.Product.PostProduct;
using ETicaretApi.Application.Features.Commands.Product.PutProduct;
using ETicaretApi.Application.Features.Commands.ProductImageFile.ChangeShowcaseImage;
using ETicaretApi.Application.Features.Queries.Basket.GetBasketItems;
using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Application.Repositories.ProductImage;
using ETicaretApi.Application.Services;
using ETicaretApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductImageWriteRepository _productImageFileWriteRepository;
        private readonly IMediator _mediator;
        private readonly IProductImageReadRepository _productImageRead;
        private readonly IProductImageReadRepository _productImageReadRepository;
        private readonly IStorageService _storageService;
        private readonly IFileService _fileService;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IMediator mediator, IProductImageReadRepository productImageRead, IProductImageReadRepository productImageReadRepository, IStorageService storageService, IFileService fileService, IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IWebHostEnvironment webHostEnvironment, IProductImageWriteRepository productImageFileWriteRepository)
        {
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _mediator = mediator;
            _productImageRead = productImageRead;
            _productImageReadRepository = productImageReadRepository;
            _storageService = storageService;
            _fileService = fileService;
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPut("[action]/{imageId}/{productId}")]
        [Authorize(AuthenticationSchemes = "Admin")]

        public async Task<IActionResult> ChangeShowCase([FromQuery] ChangeShowcaseImageCommandRequest changeShowcaseImageCommandRequest)
        {

            ChangeShowcaseImageCommandResponse response = await _mediator.Send(changeShowcaseImageCommandRequest);
            return Ok(response);
        }



      
        [HttpGet("GetAll")]
        public IActionResult GetAll()
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


        [HttpGet]
        //[Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Reading)]
        public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueriesRequest getBasketItemsQueriesRequest)
        {
            List<GetBasketItemsQueriesResponse> response = await _mediator.Send(getBasketItemsQueriesRequest);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Writing)]
        public async Task<IActionResult> Post([FromForm] PostProductCommandRequest postProductCommandRequest)
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
            var response = await _mediator.Send(postProductCommandRequest);
            return Ok(response);
            //var newProduct = await _productWriteRepository.AddAsync(new()
            //{
            //    Name = productVM.Name,
            //    Price = productVM.Price,
            //    Stock = productVM.Stock,
            //});
            //await _productWriteRepository.SaveAsync();

            //var paths = await _storageService.UploadAsync("files", Request.Form.Files);

            //var newProductImages = productVM.ImageFiles.Select((image, index) => new ProductImageFile
            //{
            //    ProductId = newProduct.Id,
            //    Image = image.Name,
            //    Path = paths.ElementAtOrDefault(index).fileName
            //}).ToList();

            //await _productImageFileWriteRepository.AddRangeAsync(newProductImages);
            //await _productImageFileWriteRepository.SaveAsync();


            //uzun versiya

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

        }
        
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Writing)]
        public async Task<IActionResult> Put(PutProductCommandRequest putProductCommandRequest)
        {
            //Product product = await _productReadRepository.GetByIdAsync(updateVM.Id);
            //product.Stock = updateVM.Stock;
            //product.Name = updateVM.Name;
            //product.Price = updateVM.Price;
            //await _productWriteRepository.SaveAsync();
            var response = await _mediator.Send(putProductCommandRequest);
            return Ok(response);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _productWriteRepository.RemoveAsync(id);
        //    await _productWriteRepository.SaveAsync();
        //    return StatusCode((int)HttpStatusCode.Accepted);
        //}

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Deleting)]
        public async Task<IActionResult> Delete(DeleteProductCommandRequest deleteProductCommandRequest)
        {
            //if (!await _productReadRepository.IsExistAsync(id))
            //    return Ok("tapilmadi");
            //foreach (var image in _productImageRead.GetWhere(x => x.ProductId == id).ToList())
            //{
            //    await _productImageFileWriteRepository.RemoveAsync(image.Id);
            //    await _storageService.DeleteAsync("files", image.Path);

            //}
            //await _productWriteRepository.RemoveAsync(id);
            //await _productWriteRepository.SaveAsync();

            //return StatusCode((int)HttpStatusCode.Accepted);
            var response = await _mediator.Send(deleteProductCommandRequest);
            return Ok(response);
        }


        [HttpPost("[action]")]
        [Consumes("multipart/form-data")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Products, ActionType = Application.Enums.ActionType.Updating)]
        public async Task<IActionResult> Uplaod([FromForm] List<IFormFile> formFiles)
        {
            //await _fileService.UploadAsync("resource/productImages", Request.Form.Files);
            var images = await _storageService.UploadAsync("files", Request.Form.Files);
            //await _storageService.UploadAsync("resource/productImages", Request.Form.Files);
            return Ok();
        }
    }
}
