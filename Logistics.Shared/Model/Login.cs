using CommunityToolkit.Mvvm.ComponentModel;
using Logistics.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Model {
    public partial class LoginRequest : ObservableValidator {
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private LoginType loginType;

        public LoginRequest()
        {
            
        }

        public LoginRequest(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }
    }
}
