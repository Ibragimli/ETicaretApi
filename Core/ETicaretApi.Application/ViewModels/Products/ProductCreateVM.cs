using Microsoft.AspNetCore.Http;

namespace ETicaretApi.Application.ViewModels.Products
{
    public class ProductCreateVM
    {
        public string Name { get; set; }
        public int Stock { get; set; } = 1;
        public long Price { get; set; } = 1;
        public List<IFormFile> ImageFiles { get; set; }
    }
}
