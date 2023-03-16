using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Model {
    public partial class WareHouseGoods : ObservableObject {

        [ObservableProperty]
        private int? warehouseId;
        [ObservableProperty]
        private Warehouse? warehouse;

        [ObservableProperty]
        private int? goodsId;
        [ObservableProperty]
        private Goods? goods;

    }
}
