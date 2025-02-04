using ETicaretApi.Application.Repositories.Menu;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.Menu
{
    public class MenuReadRepository : ReadRepository<ETicaretApi.Domain.Entities.Menu>, IMenuReadRepository
    {
        public MenuReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
