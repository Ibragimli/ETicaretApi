namespace ETicaretApi.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public int TotalProductCount { get; set; }
        public object Products { get; set; }
        public string Username { get; set; }
        public long Price { get; set; }
        public string OrderCode { get; set; }
    }
}
