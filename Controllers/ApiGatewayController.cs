using ApiGateway.Models;
using ApiGateway.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        /// Return Product item from carting
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<string>> GetCartItems(string cartKey, string categoryId)
        {
            //await Task.WhenAll(_cartingAgregator.GetCartingInfo(cartKey), _productAgregator.GetProductInfo(categoryId));
            //var result = _cartingAgregator.GetCartingInfo(cartKey).Result.Concat(_productAgregator.GetProductInfo(categoryId).Result).ToString();

            var cartingResult = _cartingAgregator.GetCartingInfo(cartKey).Result;
            var carting = JsonConvert.DeserializeObject<List<CartingDTO>>(cartingResult);
            var productId = carting[0].productItemId.ToString();

            var productsResult = _productAgregator.GetProductInfo(productId).Result;            

            var products = JsonConvert.DeserializeObject<List<ProductDTO>>(productsResult);
            var result = products[0].ToString();

            return result;
        }
    }
}