using ETicaretApi.Application.Repositories.Order;
using ETicaretApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories.Order
{

    public class CompletedOrderWriteRepository : WriteRepository<ETicaretApi.Domain.Entities.CompletedOrder>, ICompletedOrderWriteRepository
    {
        public CompletedOrderWriteRepository(DataContext context) : base(context)
        {
        }
    }
}
