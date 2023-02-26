using Logistics.Core.Context;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Core.Service {
    public class OrderService : IOrderService<Order> {
        private readonly LogisticsContext context;

        public OrderService(LogisticsContext context)
        {
            this.context = context;
        }

        public async Task<ApiResponse<Order>> CreateAsync(Order entity) {
            try {
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                var time = (Convert.ToInt64(ts.TotalSeconds).ToString());
                entity.OrderId = "LS" + time;
                context.Orders.Add(entity);
                if(await context.SaveChangesAsync() > 0) {
                    return new ApiResponse<Order>(entity,true,"success");
                }
                else {
                    return new ApiResponse<Order>(false, "创建订单失败！");
                }

            }
            catch (Exception ex) {
                return new ApiResponse<Order>(false,ex.Message);
            }
        }

        public async Task<ApiResponse<Order>> DeleteAsync(string id) {
            try {
                var order = context.Orders.FirstOrDefault(x => x.OrderId.Equals(id));
                if(order != null) {
                    context.Orders.Remove(order);
                    if(await context.SaveChangesAsync() > 0) {
                       return new ApiResponse<Order>(order,true,"success");
                    }
                }
                return new ApiResponse<Order>(false,"删除失败！");
            }
            catch (Exception ex) {
                return new ApiResponse<Order>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<List<Order>>> GetAllAsync() {
            try {
                var orders = await context.Orders.ToListAsync();
                return new ApiResponse<List<Order>>(orders, true, "查询成功");
            }
            catch (Exception ex) {
                return new ApiResponse<List<Order>>(false, "查询失败");
            }

        }

        public async Task<ApiResponse<Order>> GetAsync(string id) {
            try {
                var order = await context.Orders.FindAsync(id);
                return new ApiResponse<Order>(order, true, "查询完成");
            }
            catch (Exception ex) {
                return new ApiResponse<Order>(false, "查询失败");
            }
        }

        public async Task<ApiResponse<Order>> UpdateAsync(Order entity) {
            try {
                context.Orders.Attach(entity).State = EntityState.Modified;
                if (await context.SaveChangesAsync() > 0) {
                    return new ApiResponse<Order>(entity, true, "更新成功");
                }
                return new ApiResponse<Order>(false, "");
            }
            catch (Exception ex) {
                return new ApiResponse<Order>(false, ex.Message);
            }
        }
    }
}
