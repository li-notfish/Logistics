using Logistics.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Service
{
	public interface IAuthService
	{
		Task<ApiResponse<string>> Login(LoginRequest loginRequest);
	}
}
