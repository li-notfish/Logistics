﻿using Logistics.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Service {
    public class BaseService<T> : IBaseService<T> where T : class {
        private readonly HttpClient _httpClient;
        private readonly string serviceName;
        private readonly string Route;

        public BaseService() {

        }
        public BaseService(string serviceName, HttpClient client)
        {
            this.serviceName = serviceName;
            this._httpClient = client;
            this.Route = $"api/{serviceName}/";
        }

        public async Task<T> AddAsync(T entity) {
            if(entity is Order) {
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                var time = Convert.ToInt64(ts.TotalSeconds).ToString();
                (entity as Order).OrderId ??= "LS" + time;
                (entity as Order).Goods.OrderId = (entity as Order).OrderId;
            }
            var response = await _httpClient.PostAsJsonAsync(Route,entity);
            return response.Content.ReadFromJsonAsync<ApiResponse<T>>().Result.Data;
        }

        public async Task<T> DeleteAsync(int id) {
            var result = await _httpClient.DeleteAsync(Route+$"{id}");
            return result.Content.ReadFromJsonAsync<ApiResponse<T>>().Result.Data;
        }

        public async Task<List<T>> GetAllAsync() {
            var result = await _httpClient.GetFromJsonAsync<ApiResponse<List<T>>>(Route);
            return result.Data;
        }

        public async Task<T> GetFirstOfDefaultAsync(int id) {
            var result = await _httpClient.GetFromJsonAsync<ApiResponse<T>>(Route + $"{id}");
            return result.Data;
        }

        public async Task<T> UpdateAsync(T entity) {
            var result = await _httpClient.PutAsJsonAsync(Route,entity);

            var content = await result.Content.ReadFromJsonAsync<ApiResponse<T>>();
            return content.Data;
        }

        public async Task<T> DeleteAsync(string id) {
            var result = await _httpClient.DeleteAsync(Route + $"{id}");
            return result.Content.ReadFromJsonAsync<ApiResponse<T>>().Result.Data;
        }

        public async Task<T> GetFirstOfDefaultAsync(string id) {
            var result = await _httpClient.GetFromJsonAsync<ApiResponse<T>>(Route + $"{id}/detail");
            return result.Data;
        }

    }
}
