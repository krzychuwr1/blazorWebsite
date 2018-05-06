using BlazorWebsite.Server.Infrastructure.Database;
using BlazorWebsite.Shared;
using BlazorWebsite.Shared.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly BlogContext _db;

        public AuthenticationController(BlogContext db)
        {
            _db = db;
        }

        [HttpPost("[action]")]
        public LoginResponse Login([FromBody]LoginRequest model)
        {
            var user = _db.Users.SingleOrDefault(u => u.Username == model.Username);
            if(user != null && user.CheckPassword(model.Password))
            {
                return new LoginResponse { IsSuccess = true, AuthToken = user.Id };
            }
            else
            {
                return new LoginResponse { IsSuccess = false };
            }
        }
    }
}
