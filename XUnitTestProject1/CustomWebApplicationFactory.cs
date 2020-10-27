using LibraryAPI;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace LibraryApiIntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serverStatusDescriptor = services.Single(services =>
                services.ServiceType == typeof(IProvideServerStatusInformation));

                services.Remove(serverStatusDescriptor);
                services.AddTransient<IProvideServerStatusInformation, DummyServerStatus>();
            });
        }
    }

    public class DummyServerStatus : IProvideServerStatusInformation
    {
        public LibraryAPI.Models.Status.GetStatusResponse GetCurrentStatus()
        {
            //throw new Exception();

            return new LibraryAPI.Models.Status.GetStatusResponse
            {
                Message = "The Crow Flies at Midnight",
                CreatedAt = new System.DateTime(1969, 4, 20, 23, 59, 00)
            };
        }
    }
}