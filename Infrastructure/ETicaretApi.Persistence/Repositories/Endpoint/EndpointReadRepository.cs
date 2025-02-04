using ETicaretApi.Application.Repositories.Endpoint;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.Endpoint
{
    public class EndpointReadRepository : ReadRepository<ETicaretApi.Domain.Entities.Endpoint>, IEndpointReadRepository
    {
        public EndpointReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
