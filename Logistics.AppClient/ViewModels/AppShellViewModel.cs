using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Logistics.AppClient.Messager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace Logistics.AppClient.ViewModels
{
	public partial class AppShellViewModel : ObservableRecipient
	{
		[ObservableProperty]
		private bool isDelivery = false;

        public AppShellViewModel()
        {
            if(Preferences.Default.ContainsKey("Type"))
            {
                var type = Preferences.Default.Get<int>("Type", -1);
                IsDelivery = type == 1 ? false : true;
			}

            WeakReferenceMessenger.Default.Register<AppShellViewModel,LoginMessage>(this, (r,i) => r.IsDelivery = i.Value == 2 ? true : false);
        }
    }
}
