using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class MeViewModel : ObservableObject 
    {
        private readonly IUserService _userService;
        [ObservableProperty]
        private User user;

        public MeViewModel(IUserService userService)
        {
            this._userService = userService;
            GetUser();
        }

        private async Task GetUser()
        {
            if(Preferences.Default.ContainsKey("UserName"))
            {
                User = await _userService.GetFirstOfDefaultAsync(Preferences.Default.Get("Id",-1));
            }
        }

        [RelayCommand]
        private async void Logout()
        {
            Preferences.Default.Clear();
			SecureStorage.RemoveAll();
			await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
		}
    }
}
