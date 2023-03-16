using Logistics.Core.Context;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Core.Service.WarehouseGoodes
{
    public class WarehouseService : IWarehouseService
    {
        private readonly LogisticsContext logisticsContext;

        public WarehouseService(LogisticsContext logisticsContext)
        {
                this.logisticsContext = logisticsContext;
        }

        public async Task<ApiResponse<Warehouse>> CreateAsync(Warehouse entity)
        {
            try
            {
                await logisticsContext.Warehouses.AddAsync(entity);
                if(await logisticsContext.SaveChangesAsync() > 0)
                {
                    return new ApiResponse<Warehouse>(entity,true,"添加成功!");
                }

                return new ApiResponse<Warehouse>(false,"添加失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Warehouse>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<Warehouse>> DeleteAsync(int id)
        {
            try
            {
                var warehouse = logisticsContext.Warehouses.FirstOrDefault(x => x.Id == id);
                if(warehouse != null)
                {
                    logisticsContext.Warehouses.Remove(warehouse);
                    if(await logisticsContext.SaveChangesAsync() > 0)
                    {
                        return new ApiResponse<Warehouse>(warehouse,true,"删除成功");
                    }
                }
                return new ApiResponse<Warehouse>( false, "删除失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Warehouse>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<List<Warehouse>>> GetAllAsync()
        {
            try
            {
                if (logisticsContext.Warehouses.Count() == 0)
                {
                    return new ApiResponse<List<Warehouse>>(true,"数据库中没有仓库");
                }

                var reuslt = await logisticsContext.Warehouses.Include(g =>g.Goods).ToListAsync<Warehouse>();
                return new ApiResponse<List<Warehouse>>(reuslt, true, "查询完成");
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Warehouse>>(false,ex.Message);
            }
        }

        public async Task<ApiResponse<Warehouse>> GetAsync(int id)
        {
            try
            {
                if (logisticsContext.Warehouses.Count() == 0)
                {
                    return new ApiResponse<Warehouse>(true, "数据库中没有仓库");
                }

                var result = await logisticsContext.Warehouses.Include(x => x.Goods).FirstOrDefaultAsync(w => w.Id == id);
                if(result != null)
                {
                    return new ApiResponse<Warehouse>(result, true, "查询完成");
                }
                else
                {
                    return new ApiResponse<Warehouse>(false,"数据库中并没有这个仓库的ID");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<Warehouse>(false,ex.Message);
            }
        }

        public async Task<ApiResponse<Warehouse>> UpdateAsync(Warehouse entity)
        {
            try
            {
                logisticsContext.Warehouses.Update(entity);
                if(await logisticsContext.SaveChangesAsync() > 0)
                {
                    return new ApiResponse<Warehouse>(entity,true,"更新成功");
                }
                return new ApiResponse<Warehouse>(false, "更新失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Warehouse>(false, ex.Message);
            }
        }
    }
}
