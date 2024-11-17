using ETicaretApi.Application.Abstractions;
using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Domain.Entities;
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

        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { CreatedTime = DateTime.UtcNow,Name="Test-1",Price=2,Stock = 40},
            //    new() {CreatedTime = DateTime.UtcNow,Name="Test-3",Price=4,Stock = 50},
            //    new() {CreatedTime = DateTime.UtcNow,Name="Test-2",Price=5,Stock = 30},
            //});
            //var count = await _productWriteRepository.SaveAsync();



        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
