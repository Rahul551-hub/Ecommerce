using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult login()
        {
            return Ok("Login");
        }

        [HttpPost]
        public ActionResult Register()
        {
            return Ok("Login");
        }
    }
}
