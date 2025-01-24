namespace ETicaretApi.Application.Features.Queries.Basket.GetBasketItems
{
    public class GetBasketItemsQueriesResponse
    {
        public int BasketItemId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
