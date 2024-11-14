using ETicaretApi.Application.Abstractions;
using ETicaretApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts() => new()
       {
           new() { Id = 1, Name= "Product 1", Price = 11, Stock = 10},
           new() { Id = 2, Name= "Product 2", Price = 34, Stock = 13},
           new() { Id = 3, Name= "Product 3", Price = 27, Stock = 12},
           new() { Id = 4, Name= "Product 4", Price = 46, Stock = 5},
           new() { Id = 5, Name= "Product 5", Price = 52, Stock = 24},
       };
    }
}
