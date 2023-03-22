using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Logistics.AppClient.Messager;
using Logistics.AppClient.Pages;
using Logistics.Shared.Model;
using Logistics.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AppClient.ViewModels
{ 
    public partial class MeViewModel : ObservableRecipient 
    {
        private readonly IUserService _userService;
        private readonly IDeliveryService _deliveryService;
        [ObservableProperty]
        private User user;
        [ObservableProperty]
        private Delivery delivery;

        [ObservableProperty]
        private int loginType = 1;


        [ObservableProperty]
        private bool isDelivery = false;
        

        public MeViewModel(IUserService userService, IDeliveryService deliveryService)
        {
            this._userService = userService;
            this._deliveryService = deliveryService;
			
            Task.Run(async () =>
            {
				await GetUser();
			});
            WeakReferenceMessenger.Default.Register<MeViewModel, LoginMessage>(this, async (r,i) =>
            {
                LoginType = Preferences.Default.Get<int>("Type", -1);
                await r.GetUser();
            });
        }

        private async Task GetUser()
        {
            IsDelivery = LoginType == 2;

            if(Preferences.Default.ContainsKey("UserName"))
            {
				switch (LoginType)
                {
                    case 1:
						User = await _userService.GetFirstOfDefaultAsync(Preferences.Default.Get("Id", -1));
						break;
                    case 2:
						Delivery = await _deliveryService.GetFirstOfDefaultAsync(Preferences.Default.Get<int>("Type", -1));
                        break;
                    default:
                        break;
                }
                
            }
        }

        [RelayCommand]
        private async void Logout()
        {
            Preferences.Default.Clear();
			SecureStorage.RemoveAll();
            SecureStorage.Default.RemoveAll();
            SecureStorage.Remove("IsLogin");
			await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
		}

    }
}
