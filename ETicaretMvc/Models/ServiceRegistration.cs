using ETicaretApi.Application.Abstractions.Storage;
using ETicaretApi.Application.Abstractions.Storage.Local;
using ETicaretApi.Application.Services;
using ETicaretApi.Infrastructure.Service;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileService, FileService>();
            serviceCollection.AddScoped<IStorageService, StorageService>();

        }


    }
}
