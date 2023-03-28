using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Logistics.AppClient.Pages;
using Logistics.AppClient.View;
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
    public partial class MeDetailViewModel : ObservableObject
    {
        private readonly IUserService userService;
        private readonly IDeliveryService deliveryService;


        [ObservableProperty]
        private User user;
        [ObservableProperty]
        private Delivery delivery;
        [ObservableProperty]
        private int loginType = 1;
        [ObservableProperty]
        private bool isDelivery = false;

        private string OldPassword = string.Empty;

        public MeDetailViewModel(IUserService userService, IDeliveryService deliveryService)
        {
            this.deliveryService = deliveryService;
            this.userService = userService;

            Task.Run(async () =>
            {
                await GetInfo();
                
            });
        }


        private async Task GetInfo()
        {
            LoginType = Preferences.Default.Get<int>("Type", -1);
            IsDelivery = LoginType == 2;

            if (Preferences.Default.ContainsKey("UserName"))
            {
                switch (LoginType)
                {
                    case 1:
                        User = await userService.GetFirstOfDefaultAsync(Preferences.Default.Get("Id", -1));

                        OldPassword = User?.Password;
                        break;
                    case 2:
                        Delivery = await deliveryService.GetFirstOfDefaultAsync(Preferences.Default.Get<int>("Id", -1));
                        OldPassword = Delivery?.Password;
                        break;
                    default:
                        break;
                }

            }
        }

        [RelayCommand]
        private async Task PopToChangePassword()
        {
            var popup = new ChangePassword();
            var result = await Shell.Current.DisplayPromptAsync("确保安全","请输入你之前的密码：");
            if(!string.IsNullOrEmpty(result))
            {
                if(result.Equals(OldPassword))
                {
                    var updated = userService.UpdateAsync(User);

                    if(updated != null)
                    {
                        var toast = Toast.Make("信息更新成功啦，由于涉及密码修改请重新登录。");
                        await toast.Show();
                        await Shell.Current.GoToAsync("..");
                        await Logout();
                    }
                }
                else
                {
                    var toast = Toast.Make("啊哈，您输入的密码好像和您之前的密码不一致呢？要不再想想看？");
                    await toast.Show();
                }
            }
            else
            {
                var toast = Toast.Make("要修改信息，请输入您的信息。");
                await toast.Show();
            }
        }

        [RelayCommand]
        private async Task Back()
        {
            await Shell.Current.GoToAsync("..");
        }


        private async Task Logout()
        {
            Preferences.Default.Clear();
            SecureStorage.RemoveAll();
            SecureStorage.Default.RemoveAll();
            SecureStorage.Remove("IsLogin");
            await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
        }
    }
}
