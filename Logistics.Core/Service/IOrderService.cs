using Logistics.Shared.Model;
using Logistics.Shared;

namespace Logistics.Core.Service {
    public interface IOrderService<T> where T : class {
        Task<ApiResponse<T>> CreateAsync(T entity);
        Task<ApiResponse<T>> UpdateAsync(T entity);
        Task<ApiResponse<T>> DeleteAsync(string id);
        Task<ApiResponse<T>> GetAsync(string id);
        Task<ApiResponse<List<T>>> GetAllAsync();
    }
}
