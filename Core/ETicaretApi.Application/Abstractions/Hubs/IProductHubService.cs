namespace ETicaretApi.Application.Abstractions.Hubs
{
    public interface IProductHubService
    {
        public Task ProductAddedMessageAsync(string message);
    }
}
