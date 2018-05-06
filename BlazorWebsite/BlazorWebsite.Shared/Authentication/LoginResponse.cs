using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorWebsite.Shared.Authentication
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public Guid AuthToken { get; set; }
    }
}
