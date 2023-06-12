using ApiGateway.Models.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        //For admin Only
        [HttpGet]
        [Route("Admins")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"{currentUser.Username} is {currentUser.Role}");
        }
        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}