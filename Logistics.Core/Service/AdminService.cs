using Logistics.Core.Context;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Core.Service
{
    public class AdminService : IAdminService
    {
        private readonly LogisticsContext logisticsContext;

        public AdminService(LogisticsContext logisticsContext)
        {
            this.logisticsContext = logisticsContext;
        }

        public async Task<ApiResponse<Administrators>> CreateAsync(Administrators entity)
        {
            try
            {
                entity.CreateTime = DateTime.Now;
                logisticsContext.Administrators.Add(entity);
                if(await logisticsContext.SaveChangesAsync() > 0)
                {
                    return new ApiResponse<Administrators>(entity, true, "success");
                }
                return new ApiResponse<Administrators>(false,"创建失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Administrators>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<Administrators>> DeleteAsync(int id)
        {
            try
            {
                var admin = logisticsContext.Administrators.FirstOrDefault(x => x.Id == id);
                if (admin != null)
                {
                    logisticsContext.Administrators.Remove(admin);
                    if(await logisticsContext.SaveChangesAsync() > 0)
                    {
                        return new ApiResponse<Administrators>(admin,true,"删除成功");
                    }
                }
                return new ApiResponse<Administrators>(false, "删除失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Administrators>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<List<Administrators>>> GetAllAsync()
        {
            try
            {
                var context = logisticsContext.Administrators;
                var admins = await context.ToListAsync();
                return new ApiResponse<List<Administrators>>(admins,true,"查询成功");
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Administrators>>(false,"查询失败");
            }

        }

        public async Task<ApiResponse<Administrators>> GetAsync(int id)
        {
            try
            {
                var context = logisticsContext.Administrators;
                var admin = await context.FindAsync(id);
                return new ApiResponse<Administrators>(admin, true, "查询完成");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Administrators>(false, "查询失败");
            }
            
        }

        public async Task<ApiResponse<Administrators>> UpdateAsync(Administrators entity)
        {
            try
            {
                var context = logisticsContext.Administrators;
                context.Attach(entity).State = EntityState.Modified;
                if(await logisticsContext.SaveChangesAsync()>0)
                {
                    return new ApiResponse<Administrators>(entity,true,"更新成功");
                }
                return new ApiResponse<Administrators>(false,"");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Administrators>(false, ex.Message);
            }
        }
    }
}
