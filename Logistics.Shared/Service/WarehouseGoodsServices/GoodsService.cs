using Logistics.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Service.WarehouseGoodsServices
{
    public class GoodsService : BaseService<Goods> , IGoodsService
    {
        private readonly HttpClient httpClient;

        public GoodsService(HttpClient httpClient) : base("goods",httpClient)
        {
            this.httpClient = httpClient;   
        }
    }
}
