using ETicaretApi.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;

namespace ETicaretApi.SignalR
{
    public static class HubRegistration
    {
        public static void MapHubs(this WebApplication application)
        {
            application.MapHub<ProductHub>("product/hub");

        }
    }
}
