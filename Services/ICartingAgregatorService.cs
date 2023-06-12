namespace ApiGateway.Services
{
    public interface ICartingAgregatorService
    {
        public Task<string> GetCartingInfo(string cartKey);
    }
}