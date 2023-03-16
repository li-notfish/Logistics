using Logistics.Core.Context;
using Logistics.Shared;
using Logistics.Shared.Enums;
using Logistics.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
                var order = context.Orders.Include(x => x.Goods).FirstOrDefault(x => x.OrderId.Equals(id));
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

        public async Task<ApiResponse<List<Order>>> GetAllAsync(OrderState? orderState)
        {
            try
            {
                var orders = await context.Orders.Include(x => x.Goods).Where(x => x.OrderState == orderState).ToListAsync();
                return new ApiResponse<List<Order>>(orders, true, "查询成功");
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Order>>(false, ex.Message);
            }

        }

        public async Task<ApiResponse<List<Order>>> GetAllAsync() {
            try {
                var orders = await context.Orders.Include(x => x.Goods).ToListAsync();
                return new ApiResponse<List<Order>>(orders, true, "查询成功");
            }
            catch (Exception ex) {
                return new ApiResponse<List<Order>>(false, ex.Message);
            }

        }

        public async Task<ApiResponse<Order>> GetAsync(string id)
        {
            try
            {
                var order = await context.Orders.Include(x => x.Goods).FirstOrDefaultAsync(x => x.OrderId == id);
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
                context.Orders.Update(entity);
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
