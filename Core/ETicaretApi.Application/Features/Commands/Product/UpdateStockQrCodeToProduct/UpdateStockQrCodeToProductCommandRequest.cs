﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.Product.UpdateStockQrCodeToProduct
{
    public class UpdateStockQrCodeToProductCommandRequest:IRequest<UpdateStockQrCodeToProductCommandResponse>
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
    }
}
