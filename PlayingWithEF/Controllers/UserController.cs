using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PlayingWithEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApiContext _context;

        public UserController(ApiContext context, ILogger<UserController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var user = _context
                .Users
                .Include(u => u.Post)
                .FirstOrDefault(u => u.Id == long.Parse(id));
            
            var post = user.Post;
            // Post is null. If you remove = new Post from User.cs, it will be populated
            
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
