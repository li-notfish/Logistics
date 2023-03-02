using Logistics.Shared.Model;

namespace Logistics.Shared.Service {
    public class AdminService : BaseService<Administrators>, IAdminService {

        public AdminService(HttpClient httpClient): base("Admin",httpClient)
        {
            
        }
    }
}
