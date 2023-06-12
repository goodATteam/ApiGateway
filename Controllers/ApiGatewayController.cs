using ApiGateway.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ApiGateway.Controllers
{
    public class ApiGatewayController : ApiControllerBase
    {
        private readonly ICartingAgregatorService _cartingAgregator;
        private readonly IProductAgregatorService _productAgregator;

        public ApiGatewayController(ICartingAgregatorService cartingAgregator, IProductAgregatorService productAgregator)
        {
            _cartingAgregator = cartingAgregator;
            _productAgregator = productAgregator;
        }

        /// <summary>
        /// Return list of items regardin task for version 2 without CartKey
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<string>> GetCartItems(string cartKey, string categoryId)
        {
            await Task.WhenAll(_cartingAgregator.GetCartingInfo(cartKey), _productAgregator.GetProductInfo(categoryId));
            var result = _cartingAgregator.GetCartingInfo(cartKey).Result.Concat(_productAgregator.GetProductInfo(categoryId).Result).ToString();
            return result;
        }
    }
}