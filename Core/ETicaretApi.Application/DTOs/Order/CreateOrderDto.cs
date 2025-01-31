using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.DTOs.Order
{
    public class CreateOrderDto
    {
        public int BasketId { get; set; } = 0;
        public string Description { get; set; }
        public string Adress { get; set; }
    }
}
