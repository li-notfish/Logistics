using Logistics.Shared.Model;
using Logistics.Shared;

namespace Logistics.Core.Service
{
    public interface IBaseService<T> where T : class
    {
        Task<ApiResponse<T>> CreateAsync(T entity);
        Task<ApiResponse<T>> UpdateAsync(T entity);
        Task<ApiResponse<T>> DeleteAsync(int id);
        Task<ApiResponse<T>> GetAsync(int id);
        Task<ApiResponse<List<T>>> GetAllAsync();
    }
}
