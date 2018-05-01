using BlazorWebsite.Shared;
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
        [HttpGet("[action]")]
        public IEnumerable<BlogPostSummary> Summaries()
        {
            return Enumerable.Range(1, 5).Select(index => new BlogPostSummary
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                Content = 
$@"<strong>Post content {index}</strong> <br/>
More content More content More content More content
More content More content More content More content<br/>
More content More content More content More content
More content...",
                Title = $"Post title {index}"
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            return Ok(new BlogPostFull
            {
                Id = id,
                Content = "mock content",
                Date = DateTime.Now,
                Title = "mock title"
            });
        }
    }
}
