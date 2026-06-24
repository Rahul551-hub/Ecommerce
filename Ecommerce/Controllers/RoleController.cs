using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        //Here we are interecting with the db context
        //_context= class variable
        private readonly EcommerceDataContent _context;

        //here is my constructor
        //context parameter of constructor
        public RoleController(EcommerceDataContent context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult GetRoles()
        {
            var roles = _context.RoleDetails.ToList();
            return Ok(roles);
        }


        [HttpPost]
        public ActionResult Create([FromBody] Role role)
        {
            if (role == null)
            {
                return BadRequest("Nothing in the Role");
            }

            Role roleToUpdate = new Role { 
                RoleName = role.RoleName,
                RoleId = role.RoleId, 
                RoleDescription = "Admin"
            };

            //RoleDetails is the table which is yed in the role model 
            _context.RoleDetails.Add(roleToUpdate);

            _context.SaveChanges();
            

            return Ok("Yes  Updated");
        }
    }
}
