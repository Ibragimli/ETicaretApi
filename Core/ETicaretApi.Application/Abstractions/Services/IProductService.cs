using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<byte[]> QrCodeToProductAsync(int productId);
        Task StockUpdateToProductAsync(int productId, int stock);

    }
}
