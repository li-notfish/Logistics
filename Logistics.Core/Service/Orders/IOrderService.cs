using Logistics.Shared;
using Logistics.Shared.Enums;
using Logistics.Shared.Model;

namespace Logistics.Core.Service.Orders
{
    public interface IOrderService
    {
        Task<ApiResponse<Order>> CreateAsync(Order entity);
        Task<ApiResponse<Order>> UpdateAsync(Order entity);
        Task<ApiResponse<Order>> DeleteAsync(string id);
        Task<ApiResponse<Order>> GetAsync(string id);
        Task<ApiResponse<List<Order>>> GetAllAsync();
        Task<ApiResponse<List<Order>>> GetAllAsync(OrderState? orderState);
    }
}
