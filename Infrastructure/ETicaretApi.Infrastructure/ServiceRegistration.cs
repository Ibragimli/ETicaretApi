using ETicaretApi.Application.Abstractions.Storage;
using ETicaretApi.Application.Abstractions.Storage.Local;
using ETicaretApi.Application.Abstractions.Tokens;
using ETicaretApi.Application.Services;
using ETicaretApi.Infrastructure.Enums;
using ETicaretApi.Infrastructure.Service;
using ETicaretApi.Infrastructure.Service.Storage;
using ETicaretApi.Infrastructure.Service.Storage.Azure;
using ETicaretApi.Infrastructure.Service.Storage.Local;
using ETicaretApi.Infrastructure.Service.Tokens;
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
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();

        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }

        //elave olaraq 
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();

                    break;
                case StorageType.AWS:
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;

            }
        }
    }
}
