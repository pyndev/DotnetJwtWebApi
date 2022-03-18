using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetJwtWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IndexController : ControllerBase
    {
        private static readonly string[] Datas = new[]
        {
            "Anyone", "Can", "View", "This", "Page."
        };


        [HttpGet("public"), AllowAnonymous] //Any one can visit

        public async Task<ActionResult> Public()
        {
            return Ok(Datas);
        }

        [HttpGet("protected")] //Need Authorization to visit
        public async Task<ActionResult> Protected()
        {
            return Ok("This is protected page.");
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")] //Need Authorization and Role = Admin to visit
        public async Task<ActionResult> Admin()
        {
            return Ok("This is admin page.");
        }
    }
}

