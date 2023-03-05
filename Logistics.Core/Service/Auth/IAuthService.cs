using Logistics.Shared;
using Logistics.Shared.Model;

namespace Logistics.Core.Service.Auth
{
    public interface IAuthService
    {
        Task<ApiResponse<int>> Ragister(Administrators administrators, string password);
        Task<bool> AdminExists(string name, string password);
        Task<ApiResponse<string>> Login(string name, string password);
    }
}
