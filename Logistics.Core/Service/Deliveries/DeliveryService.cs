using Logistics.Core.Context;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Core.Service.Deliveries
{
    public class DeliveryService : IDeliveryService
    {

        private readonly LogisticsContext logisticsContext;

        public DeliveryService(LogisticsContext logisticsContext)
        {
            this.logisticsContext = logisticsContext;
        }

        public async Task<ApiResponse<Delivery>> CreateAsync(Delivery entity)
        {
            try
            {
                await logisticsContext.Deliveries.AddAsync(entity);
                if (await logisticsContext.SaveChangesAsync() > 0)
                {
                    return new ApiResponse<Delivery>(entity, true, "success");
                }
                return new ApiResponse<Delivery>(false, "");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Delivery>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<Delivery>> DeleteAsync(int id)
        {
            try
            {
                var delivery = await logisticsContext.Deliveries.FirstOrDefaultAsync(x => x.Id == id);
                if (delivery != null)
                {
                    logisticsContext.Deliveries.Remove(delivery);
                    if (await logisticsContext.SaveChangesAsync() > 0)
                    {
                        return new ApiResponse<Delivery>(delivery, true, "");
                    }
                }
                return new ApiResponse<Delivery>(false, "");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Delivery>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<List<Delivery>>> GetAllAsync()
        {
            try
            {
                if (logisticsContext.Deliveries.Count() == 0)
                {
                    return new ApiResponse<List<Delivery>>(false, "");
                }

                var deliveries = await logisticsContext.Deliveries.ToListAsync();
                return new ApiResponse<List<Delivery>>(deliveries, true, "success");
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Delivery>>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<Delivery>> GetAsync(int id)
        {
            try
            {
                if (logisticsContext.Deliveries.Count() == 0)
                {
                    return new ApiResponse<Delivery>(false, "");
                }

                var delivery = await logisticsContext.Deliveries.FirstOrDefaultAsync(x => x.Id == id);

                return new ApiResponse<Delivery>(delivery, true, "success");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Delivery>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<Delivery>> UpdateAsync(Delivery entity)
        {
            try
            {
                logisticsContext.Deliveries.Attach(entity).State = EntityState.Modified;
                if (await logisticsContext.SaveChangesAsync() > 0)
                {
                    return new ApiResponse<Delivery>(entity, true, "更新成功");
                }
                return new ApiResponse<Delivery>(false, "");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Delivery>(false, ex.Message);
            }
        }
    }
}
