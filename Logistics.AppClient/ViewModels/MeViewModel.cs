using CommunityToolkit.Mvvm.ComponentModel;
using Logistics.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AppClient.ViewModels
{
    public class MeViewModel : ObservableObject 
    {
        private readonly IUserService _userService;

        public MeViewModel(IUserService userService)
        {
            this._userService = userService;
        }
    }
}
