using Logistics.Core.Context;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Core.Service {
    public class UserService : IUserService {
        private readonly LogisticsContext logisticsContext;

        public UserService(LogisticsContext logisticsContext)
        {
            this.logisticsContext = logisticsContext;
        }

        public async Task<ApiResponse<User>> CreateAsync(User entity) {
            try {
                entity.CreateTime = DateTime.Now;
                logisticsContext.Users.Add(entity);
                if(await logisticsContext.SaveChangesAsync() > 0) {
                    return new ApiResponse<User>(entity, true, "success");
                }
                return new ApiResponse<User>( false, "error");
            }
            catch (Exception ex) {
                return new ApiResponse<User>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<User>> DeleteAsync(int id) {
            try {
                var user = logisticsContext.Users.FirstOrDefault(x => x.Id == id);
                if (user != null) {
                    logisticsContext.Users.Remove(user);
                }
                if(await logisticsContext.SaveChangesAsync() > 0)
                    {
                    return new ApiResponse<User>(user, true, "success");
                    }
                return new ApiResponse<User>(false,"faild");
            }

            catch (Exception ex) {
                return new ApiResponse<User>(false,ex.Message);
            }
        }

        public async Task<ApiResponse<List<User>>> GetAllAsync() {
            try {
                if(logisticsContext.Users.Count() == 0) {
                    return new ApiResponse<List<User>>(false,"没有用户");
                }
                var userList = await logisticsContext.Users.ToListAsync();
                return new ApiResponse<List<User>>(userList,true, "success");
            }
            catch (Exception ex) {
                return new ApiResponse<List<User>>(false,ex.Message);
            }
        }

        public async Task<ApiResponse<User>> GetAsync(int id) {
            try {
                var user = await logisticsContext.Users.FirstOrDefaultAsync(x => x.Id == id);
                return new ApiResponse<User>(user,true,"success");
            }
            catch (Exception ex) {
                return new ApiResponse<User>(false, ex.Message);
            }
        }

        public async Task<ApiResponse<User>> UpdateAsync(User entity) {
            try {
                logisticsContext.Users.Attach(entity).State = EntityState.Modified;
                if(await logisticsContext.SaveChangesAsync() > 0) {
                    return new ApiResponse<User>(entity,true,"success");
                }
                return new ApiResponse<User>(false, "");
            }
            catch (Exception ex) {
                return new ApiResponse<User>(false, ex.Message);
            }
        }
    }
}
