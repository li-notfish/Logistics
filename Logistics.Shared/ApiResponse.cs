using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared {
    public class ApiResponse<T> {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public ApiResponse()
        {
            
        }

        public ApiResponse(T? data,bool success, string meesage) {
            Data = data;
            Success = success;
            Message = meesage;
        }

        public ApiResponse(bool success,string meesage) {
            Success = success;
            Message = meesage;
        }
    }

    public class ApiResponse {
        public object? Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public ApiResponse() {

        }

        public ApiResponse(object? data, bool success, string meesage) {
            Data = data;
            Success = success;
            Message = meesage;
        }

        public ApiResponse(bool success, string meesage) {
            Success = success;
            Message = meesage;
        }
    }
}
