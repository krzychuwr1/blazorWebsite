using BlazorWebsite.Server.Infrastructure.Database;
using BlazorWebsite.Shared;
using BlazorWebsite.Shared.Post;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    public class BlogPostController : Controller
    {
        private readonly BlogContext _db;

        public BlogPostController(BlogContext db)
        {
            _db = db;
        }

        [HttpGet("[action]")]
        public IEnumerable<BlogPostSummary> Summaries()
        {
            return _db.Posts.Select(p => new BlogPostSummary
            {
                Title = p.Title,
                Id = p.Id,
                Content = p.Content,
                Date = p.Date
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _db.Posts.FindAsync(id);
            return Ok(new BlogPostFull
            {
                Id = post.Id,
                Content = post.Content,
                Date = post.Date,
                Title = post.Title
            });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddPost([FromBody]AddPostRequest post)
        {
            if((Request.Headers.TryGetValue("authentication-token", out var token)))
            {
                var userId = Guid.Parse(token.First());
                if (await _db.Users.FindAsync(userId) != null)
                    _db.Posts.Add(new Model.BlogPost
                    {
                        Title = post.Title,
                        Content = post.Content,
                        Date = DateTime.Now
                    });
                    await _db.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
