using Logistics.Core.Context;
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

        public async Task<Administrators> CreateAsync(Administrators entity)
        {
            try
            {
                entity.CreateTime = DateTime.Now;
                logisticsContext.Administrators.Add(entity);
                if(await logisticsContext.SaveChangesAsync() > 0)
                {
                    return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Administrators> DeleteAsync(int id)
        {
            try
            {
                var admin = logisticsContext.Administrators.FirstOrDefault(x => x.Id == id);
                if (admin != null)
                {
                    logisticsContext.Administrators.Remove(admin);
                    if(await logisticsContext.SaveChangesAsync() > 0)
                    {
                        return admin;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Administrators>> GetAllAsync()
        {
            try
            {
                var context = logisticsContext.Administrators;
                var admins = await context.ToListAsync();
                return admins;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<Administrators> GetAsync(int id)
        {
            try
            {
                var context = logisticsContext.Administrators;
                var admin = await context.FindAsync(id);
                return admin;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public async Task<Administrators> UpdateAsync(Administrators entity)
        {
            try
            {
                var context = logisticsContext.Administrators;
                var admins = await context.FindAsync(entity.Id);
                if(admins == null)
                {
                    return null;
                }
                context.Entry(entity).State = EntityState.Modified;
                if(await logisticsContext.SaveChangesAsync()>0)
                {
                    return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
