using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Service {
    public interface IBaseService<T> where T : class {

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<T> DeleteAsync(string id);
        Task<T> GetFirstOfDefaultAsync(int id);
        Task<T> GetFirstOfDefaultAsync(string id);
        Task<List<T>> GetAllAsync();
    }
}
