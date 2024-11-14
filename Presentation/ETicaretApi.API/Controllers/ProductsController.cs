using ETicaretApi.Application.Abstractions;
using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Persistence.Repositories.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;

        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        //[HttpGet]
        //public async void Get()
        //{
        //    await _productWriteRepository.AddRangeAsync(new()
        //    {
        //        new() {Id = 1, CreatedTime = DateTime.UtcNow,Name="Test-1",Price=2,Stock = 20},
        //        new() {Id = 2, CreatedTime = DateTime.UtcNow,Name="Test-3",Price=4,Stock = 20},
        //        new() {Id = 3, CreatedTime = DateTime.UtcNow,Name="Test-2",Price=5,Stock = 20},
        //    });
        //    var count = await _productWriteRepository.SaveAsync();
        //}
    }
}
