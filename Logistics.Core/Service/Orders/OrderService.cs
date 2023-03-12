using Logistics.Core.Context;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Core.Service.Orders
{
    public class OrderService : IOrderService
    {
        private readonly LogisticsContext context;

        public OrderService(LogisticsContext context)
        {
            this.context = context;
        }

        public async Task<ApiResponse<Order>> CreateAsync(Order entity)
        {
            try
            {
                context.Orders.Add(entity);
                if (await context.SaveChangesAsync() > 0)
                {
                    return new ApiResponse<Order>(entity, true, "success");
                }
                else
                {
                    return new ApiResponse<Order>(false, "创建订单失败！");
                }

            }
            catch (Exception ex)
            {
                return new ApiResponse<Order>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<Order>> DeleteAsync(string id)
        {
            try
            {
                var order = context.Orders.Include(x => x.Delivery).FirstOrDefault(x => x.OrderId.Equals(id));
                if (order != null)
                {
                    context.Orders.Remove(order);
                    if (await context.SaveChangesAsync() > 0)
                    {
                        return new ApiResponse<Order>(order, true, "success");
                    }
                }
                return new ApiResponse<Order>(false, "删除失败！");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Order>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<List<Order>>> GetAllAsync()
        {
            try
            {
                var orders = await context.Orders.Include(a => a.Delivery).ToListAsync();
                return new ApiResponse<List<Order>>(orders, true, "查询成功");
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Order>>(false, ex.Message);
            }

        }

        public async Task<ApiResponse<Order>> GetAsync(string id)
        {
            try
            {
                var order = await context.Orders.Include(x => x.Delivery).FirstOrDefaultAsync(x => x.OrderId == id);
                return new ApiResponse<Order>(order, true, "查询完成");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Order>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<Order>> UpdateAsync(Order entity)
        {
            try
            {
                //if(entity.DeliveryId != null) {
                //    var Delivery = await context.Deliveries.FirstOrDefaultAsync(x => x.Id == entity.DeliveryId);
                //    entity.Delivery = Delivery;
                //}
                //if(entity.DeliveryId !=null) {
                //    var delivery = await context.Deliveries.FirstOrDefaultAsync(x => x.Id == entity.DeliveryId);
                //    entity.OrderState = Shared.Enums.OrderState.InWay;
                //    delivery.State = Shared.Enums.DeliveryState.Busy;
                //    context.Deliveries.Attach(delivery).State = EntityState.Modified;
                //}
                context.Orders.Attach(entity).State = EntityState.Modified;
                if (await context.SaveChangesAsync() > 0)
                {
                    return new ApiResponse<Order>(entity, true, "更新成功");
                }
                return new ApiResponse<Order>(false, "");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Order>(false, ex.Message);
            }
        }
    }
}
