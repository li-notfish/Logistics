using Logistics.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Service {
    public class UserService : BaseService<User>, IUserService {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient) : base("User",httpClient)
        {
            this._httpClient = httpClient;
        }
    }
}
