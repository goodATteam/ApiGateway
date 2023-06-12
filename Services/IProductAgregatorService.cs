namespace ApiGateway.Services
{
    public interface IProductAgregatorService
    {
        public Task<string> GetProductInfo(string categoryId);
    }
}