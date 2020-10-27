using LibraryAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApiIntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
    }
}