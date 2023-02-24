using Logistics.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Service {
    public class AdminService : BaseService<Administrators>, IAdminService {

        public AdminService(HttpClient httpClient): base("Admin",httpClient)
        {
            
        }
    }
}
