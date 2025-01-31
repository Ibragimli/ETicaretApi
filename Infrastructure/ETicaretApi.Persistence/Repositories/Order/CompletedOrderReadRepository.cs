using ETicaretApi.Application.Repositories.Order;
using ETicaretApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories.Order
{


    public class CompletedOrderReadRepository : ReadRepository<ETicaretApi.Domain.Entities.CompletedOrder>, ICompletedOrderReadRepository
    {
        public CompletedOrderReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
