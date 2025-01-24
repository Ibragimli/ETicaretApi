using ETicaretApi.Domain.Entities;

namespace ETicaretApi.Application.Abstractions
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
