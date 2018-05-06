using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebsite.Client.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        public string GetValue(string key)
        {
            return RegisteredFunction.Invoke<string>("blazor_localStorageGetValue", key);
        }
        public void SetValue(string key, string value)
        {
            RegisteredFunction.Invoke<bool>("blazor_localStorageSetValue", key, value);
        }
    }
}
