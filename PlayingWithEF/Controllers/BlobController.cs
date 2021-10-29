using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlayingWithEF.Models;

namespace PlayingWithEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlobController : ControllerBase
    {
        private readonly ILogger<BlobController> _logger;
        private readonly ApiContext _context;

        public BlobController(ApiContext context, ILogger<BlobController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Blob> Get(string id)
        {
            var blobs = _context
                .Blobs
                .Include(b => b.PersonInstance)
                .Take(5)
                .ToList();
            
            var post = blobs.First().PersonInstance;
            // Post is null. If you remove = new Post from User.cs, it will be populated
            
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
    }
}
