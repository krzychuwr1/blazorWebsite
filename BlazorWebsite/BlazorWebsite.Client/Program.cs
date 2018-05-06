using BlazorWebsite.Client.Infrastructure;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlazorWebsite.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                services.AddSingleton<ISessionManager, SessionManager>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
