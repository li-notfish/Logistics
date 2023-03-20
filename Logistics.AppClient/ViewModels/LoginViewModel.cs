using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Logistics.AppClient.Pages;
using Logistics.Shared.Enums;
using Logistics.Shared.Model;
using Logistics.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AppClient.ViewModels
{
	public partial class LoginViewModel : ObservableObject
	{
		private readonly IAuthService authService;
		private IUserService userService;
		private IDeliveryService deliveryService;

		HttpClient http = new HttpClient();
		
		[ObservableProperty]
		private int select = 1;

        public LoginViewModel()
        {
			http.BaseAddress = new Uri("http://localhost:5173/");
			this.authService = new AuthService(http);
			this.LoginRequestdto = new LoginRequest();
        }

        [ObservableProperty]
		private LoginRequest loginRequestdto;

		[RelayCommand]
		private async Task Login()
		{
			try
			{
				LoginRequestdto.LoginType = (LoginType)Select;
				var result = await authService.Login(LoginRequestdto);
				if (result.Success)
				{
					if (Select == 1)
					{
						userService = new UserService(http);
						var list = await userService.GetAllAsync();
						LoginRequestdto.Id = list.FirstOrDefault(x => x.Name == LoginRequestdto.Name && x.Password.Equals(LoginRequestdto.Password)).Id;
					}
					else
					{
						deliveryService = new DeliveryService(http);
						var list = await deliveryService.GetAllAsync();
						LoginRequestdto.Id = list.FirstOrDefault(x => x.Name == LoginRequestdto.Name && x.Password.Equals(LoginRequestdto.Password)).Id;
					}

					await SecureStorage.SetAsync("IsLogin","true");
					Preferences.Default.Set("UserName", LoginRequestdto.Name);
					Preferences.Default.Set("Id", LoginRequestdto.Id);
					await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
				}
				else
				{
					var toast = Toast.Make("账号或者密码不正确", ToastDuration.Short, 14);
					await toast.Show();
				}
				
			}
			catch (Exception ex)
			{
				var toast = Toast.Make(ex.Message, ToastDuration.Short, 14);
				await toast.Show();
			}
			
			
		}
	}
}
