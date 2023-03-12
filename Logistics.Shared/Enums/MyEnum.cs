
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
