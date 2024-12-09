using ETicaretApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.ViewModels.Products
{
    public class ProductCreateVM
    {
        public string Name { get; set; } = "saalasasd";
        public int Stock { get; set; } = 1;
        public long Price { get; set; } = 1;
        public List<IFormFile> ImageFiles { get; set; }
    }
}
