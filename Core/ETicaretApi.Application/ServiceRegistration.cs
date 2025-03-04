﻿using ETicaretApi.Application.Features.Commands.DeleteProduct;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

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
