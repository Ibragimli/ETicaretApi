﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Abstractions.Hubs
{
    public interface IOrderHubService
    {
        public Task OrderAddedMessageAsync(string message);

    }
}
