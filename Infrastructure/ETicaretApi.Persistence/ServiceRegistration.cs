using ETicaretApi.Application.Abstractions;
using ETicaretApi.Application.Abstractions.Services;
using ETicaretApi.Application.Repositories;
using ETicaretApi.Application.Repositories.Customer;
using ETicaretApi.Application.Repositories.Order;
using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Application.Repositories.ProductImage;
using ETicaretApi.Domain.Entities.Identity;
using ETicaretApi.Persistence.Concretes;
using ETicaretApi.Persistence.Contexts;
using ETicaretApi.Persistence.Repositories.Customer;
using ETicaretApi.Persistence.Repositories.Order;
using ETicaretApi.Persistence.Repositories.Product;
using ETicaretApi.Persistence.Repositories.ProductImage;
using ETicaretApi.Persistence.Services;
using Microsoft.AspNetCore.Identity;
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

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IProductImageReadRepository, ProductImageReadRepository>();
            services.AddScoped<IProductImageWriteRepository, ProductImageWriteRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            // Identity Konfigürasyonu
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false; // Örnek yapılandırma
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
        }
    }
}
