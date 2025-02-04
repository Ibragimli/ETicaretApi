using ETicaretApi.Application.Repositories.Menu;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.Menu
{
    public class MenuWriteRepository : WriteRepository<ETicaretApi.Domain.Entities.Menu>, IMenuWriteRepository
    {
        public MenuWriteRepository(DataContext context) : base(context)
        {
        }
    }
}
