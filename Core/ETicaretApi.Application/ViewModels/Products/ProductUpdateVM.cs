using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.ViewModels.Products
{
    public class ProductUpdateVM
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public int Stock { get; set;}
        public long Price { get; set; }
    }
}
