
namespace Logistics.Shared.Enums {
    public enum OrderState {
        None,
        InWay,
        Dispatch,
        Received,
        SigningFailed,
        SendBack,
        WaitRecived,

    }
    public enum DeliveryState {
        Busy,
        Idle
    }

    public enum GoodsStates
    {
        Out,
        In,
    }
}
