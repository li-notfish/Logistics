using Logistics.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Service.WarehouseGoodsServices
{
    public class WarehouseService : BaseService<Warehouse>, IWarehouseService
    {
        private readonly HttpClient httpClient;

        public WarehouseService(HttpClient httpClient) : base("warehouse",httpClient)
        {
            this.httpClient = new HttpClient();
        }
    }
}
