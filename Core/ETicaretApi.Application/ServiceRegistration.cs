using ETicaretApi.Application.Abstractions.Storage;
using ETicaretApi.Application.Features.Commands.DeleteProduct;
using ETicaretApi.Application.Features.Commands.Product.DeleteProduct;
using ETicaretApi.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(DeleteProductCommandHandler).Assembly);
        }
    }
}
