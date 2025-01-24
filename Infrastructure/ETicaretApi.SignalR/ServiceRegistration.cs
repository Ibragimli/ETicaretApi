using ETicaretApi.Application.Abstractions.Hubs;
using ETicaretApi.SignalR.HubsService;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretApi.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            collection.AddTransient<IProductHubService, ProductHubService>();
            collection.AddSignalR();
        }
    }
}
