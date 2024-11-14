using ETicaretApi.Application.Repositories;
using ETicaretApi.Application.Repositories.Order;
using ETicaretApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories.Order
{
    public class OrderWriteRepository : WriteRepository<ETicaretApi.Domain.Entities.Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(DataContext context) : base(context)
        {
        }
    }
}
