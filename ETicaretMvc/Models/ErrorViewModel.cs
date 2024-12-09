using ETicaretApi.Domain.Entities;

namespace ETicaretMvc.Models
{
    public class ErrorViewModel
    {
        public List<Product> Products { get; set; }
        public List<string> Images { get; set; }
        public string Path { get; set; }

    }
}