using ETicaretApi.Application.Repositories.Order;
using ETicaretApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<ETicaretApi.Domain.Entities.Order>, IOrderReadRepository
    {
        public OrderReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
