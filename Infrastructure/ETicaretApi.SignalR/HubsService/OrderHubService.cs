using ETicaretApi.Application.Abstractions.Hubs;
using ETicaretApi.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.SignalR.HubsService
{
    public class OrderHubService : IOrderHubService
    {
        readonly IHubContext<OrderHub> _context;
        public OrderHubService(IHubContext<OrderHub> hubContext)
        {
            _context = hubContext;
        }

        public IHubContext<OrderHub> HubContext { get; }

        public async Task OrderAddedMessageAsync(string message)
        {
            await _context.Clients.All.SendAsync(ReceiveFunctionNames.OrderAddedMessage, message);
        }
    }
}
