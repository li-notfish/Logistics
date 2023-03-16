using Logistics.Core.Context;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Core.Service.WarehouseGoodes
{
    public class GoodsService : IGoodsService
    {
        private readonly LogisticsContext logisticsContext;

        public GoodsService(LogisticsContext logisticsContext)
        {
            this.logisticsContext = logisticsContext;
        }

        public async Task<ApiResponse<Goods>> CreateAsync(Goods entity)
        {
            try
            {
                await logisticsContext.Goodes.AddAsync(entity);
                if(await logisticsContext.SaveChangesAsync() > 0)
                {
                    return new ApiResponse<Goods>(entity, true, "添加完成");
                }
                return new ApiResponse<Goods>( false, "添加失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Goods>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<Goods>> DeleteAsync(int id)
        {
            return new ApiResponse<Goods>();
        }

        public async Task<ApiResponse<List<Goods>>> GetAllAsync()
        {
            try
            {
                if (logisticsContext.Goodes.Count() == 0)
                {
                    return new ApiResponse<List<Goods>>(new List<Goods>(), true, "仓库没有物品");
                }
                var result = await logisticsContext.Goodes.Include(x => x.Order).ToListAsync();

                return new ApiResponse<List<Goods>>(result, true, "查询完成");
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Goods>>(false,ex.Message);
            }
        }

        public async Task<ApiResponse<Goods>> GetAsync(int id)
        {
            try
            {
                if(logisticsContext.Goodes == null)
                {
                    return new ApiResponse<Goods>(false,"数据库中并没有物品");
                }
                var result = await logisticsContext.Goodes.Include(x => x.Order).FirstOrDefaultAsync(g => g.Id == id);

                return new ApiResponse<Goods>(result, true,"查询完成");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Goods>(false,ex.Message);
            }
        }

        public async Task<ApiResponse<Goods>> UpdateAsync(Goods entity)
        {
            try
            {
                logisticsContext.Goodes.Update(entity);
                if(await logisticsContext.SaveChangesAsync() > 0)
                {
                    return new ApiResponse<Goods>(entity, true, "修改成功");
                }
                return new ApiResponse<Goods>(false, "修改失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Goods>(false, ex.Message);
            }
        }
    }
}
