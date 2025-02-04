using ETicaretApi.Application.Abstractions;
using ETicaretApi.Application.Abstractions.Services;
using ETicaretApi.Application.Abstractions.Services.Baskets;
using ETicaretApi.Application.Abstractions.Services.Order;
using ETicaretApi.Application.Repositories;
using ETicaretApi.Application.Repositories.Basket;
using ETicaretApi.Application.Repositories.BasketItem;
using ETicaretApi.Application.Repositories.Customer;
using ETicaretApi.Application.Repositories.Endpoint;
using ETicaretApi.Application.Repositories.Menu;
using ETicaretApi.Application.Repositories.Order;
using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Application.Repositories.ProductImage;
using ETicaretApi.Domain.Entities.Identity;
using ETicaretApi.Persistence.Concretes;
using ETicaretApi.Persistence.Contexts;
using ETicaretApi.Persistence.Repositories.Basket;
using ETicaretApi.Persistence.Repositories.BasketItem;
using ETicaretApi.Persistence.Repositories.Customer;
using ETicaretApi.Persistence.Repositories.Endpoint;
using ETicaretApi.Persistence.Repositories.Menu;
using ETicaretApi.Persistence.Repositories.Order;
using ETicaretApi.Persistence.Repositories.Product;
using ETicaretApi.Persistence.Repositories.ProductImage;
using ETicaretApi.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
            services.AddScoped<IProductImageReadRepository, ProductImageReadRepository>();
            services.AddScoped<IProductImageWriteRepository, ProductImageWriteRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICompletedOrderWriteRepository, CompletedOrderWriteRepository>();
            services.AddScoped<ICompletedOrderReadRepository, CompletedOrderReadRepository>();

            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();
            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();

            services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
            services.AddScoped<IProductService, ProductService>();



            // Identity Konfigürasyonu
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false; // Örnek yapılandırma
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
        }
    }
}
