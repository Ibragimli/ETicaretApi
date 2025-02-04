using ETicaretApi.Application.Repositories.Endpoint;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.Endpoint
{
    public class EndpointWriteRepository : WriteRepository<ETicaretApi.Domain.Entities.Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(DataContext context) : base(context)
        {
        }
    }
}
