using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Enums {
    public enum OrderState {
        None,
        InWay,
        Dispatch,
        Received,
        SigningFailed,
        SendBack
    }
    public enum DeliveryState {
        Busy,
        Idle
    }
}
