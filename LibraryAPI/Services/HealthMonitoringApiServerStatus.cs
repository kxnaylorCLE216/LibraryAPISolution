using LibraryAPI.Models.Status;
using System;

namespace LibraryAPI.Services
{
    public class HealthMonitoringApiServerStatus : IProvideServerStatusInformation
    {
        public GetStatusResponse GetCurrentStatus()
        {
            return new GetStatusResponse
            {
                Message = "Everything is Good",
                CreatedAt = DateTime.Now
            };
        }
    }
}