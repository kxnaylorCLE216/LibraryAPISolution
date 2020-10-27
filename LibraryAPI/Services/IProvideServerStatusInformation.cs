using LibraryAPI.Models.Status;

namespace LibraryAPI.Services
{
    public interface IProvideServerStatusInformation
    {
        GetStatusResponse GetCurrentStatus();
    }
}