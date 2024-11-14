using ETicaretApi.Application.Abstractions;
using ETicaretApi.Application.Repositories;
using ETicaretApi.Application.Repositories.Customer;
using ETicaretApi.Application.Repositories.Order;
using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Persistence.Concretes;
using ETicaretApi.Persistence.Contexts;
using ETicaretApi.Persistence.Repositories.Customer;
using ETicaretApi.Persistence.Repositories.Order;
using ETicaretApi.Persistence.Repositories.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddSingleton<IProductService, ProductService>();
            //services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            //services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            //services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
            //services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            //services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            //services.AddSingleton<IOrderReadRepository, OrderReadRepository>();

        }
    }
}
