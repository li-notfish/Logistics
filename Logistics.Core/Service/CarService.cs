using Logistics.Core.Context;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Core.Service {
    public class CarService : ICarService {

        private readonly LogisticsContext logisticsContext;

        public CarService(LogisticsContext logisticsContext)
        {
            this.logisticsContext = logisticsContext;
        }

        public async Task<ApiResponse<Car>> CreateAsync(Car entity) {
            try {
                logisticsContext.Cars.Add(entity);
                if(await logisticsContext.SaveChangesAsync() > 0) {
                    return new ApiResponse<Car>(entity,true,"success");
                }

                return new ApiResponse<Car>(false,"创建失败");
            }
            catch (Exception ex) {
                return new ApiResponse<Car>(false,ex.Message);
            }
        }

        public async Task<ApiResponse<Car>> GetAsync(int id) {
            try {
                var car = await logisticsContext.Cars.FindAsync(id);
                return new ApiResponse<Car>(car,true,"success");
            }
            catch (Exception ex) {
                return new ApiResponse<Car>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<Car>> DeleteAsync(int id) {
            try {
                var car = await logisticsContext.Cars.FindAsync(id);
                if(car != null) {
                    logisticsContext.Remove(car);
                    if(await logisticsContext.SaveChangesAsync() > 0) {
                        return new ApiResponse<Car>(car, true, "success");
                    }
                }
                return new ApiResponse<Car>(false,"删除失败");
            }
            catch (Exception ex) {
                return new ApiResponse<Car>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<List<Car>>> GetAllAsync() {
            try {
                if(logisticsContext.Cars.Count() == 0) {
                    return new ApiResponse<List<Car>>(false,"列表是空的");
                }
                var cars = await logisticsContext.Cars.ToListAsync();
                return new ApiResponse<List<Car>>(cars, true, "success");
            }
            catch (Exception ex) {
                return new ApiResponse<List<Car>>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<Car>> UpdateAsync(Car entity) {
            try {
                logisticsContext.Cars.Attach(entity).State = EntityState.Modified;
                if(await logisticsContext.SaveChangesAsync() > 0) {
                    return new ApiResponse<Car>(entity,true, "success");
                }
                return new ApiResponse<Car>(false, "");
            
            }
            catch (Exception ex) {
                return new ApiResponse<Car>(false, ex.Message);
            }
        }
    }
}
