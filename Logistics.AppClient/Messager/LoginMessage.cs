using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AppClient.Messager
{
	public class LoginMessage : ValueChangedMessage<int>
	{
        public LoginMessage(int type): base(type)
        {
            
        }
    }
}
