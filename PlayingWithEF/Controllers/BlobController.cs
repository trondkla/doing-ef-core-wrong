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
            if (!long.TryParse(id, out long idLong))
            {
                return NotFound();
            }

            var blobs = _context
                .Blobs
                .Include(b => b.PersonInstance)
                .FirstOrDefault(b => b.Id == idLong);
            
            var post = blobs.PersonInstance;
            // Post is null. If you remove = new Post from User.cs, it will be populated
            // This is just a constructed example, Post should not be returned :P
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
    }
}
