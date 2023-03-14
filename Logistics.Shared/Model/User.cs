using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Model
{
    public class User : ObservableValidator
    {
        private int id;
        [DisplayName("ID")]
        public int Id {
            get => id;
            set => this.SetProperty(ref id, value,true);
        }

        private string name;
        [Required]
        [DisplayName("用户名")]
        public string Name {
            get => name;
            set => SetProperty(ref name, value, true);
        }

        private string phone;
        [Required,Phone]
        [DisplayName("手机号码")]
        public string Phone {
            get => phone;
            set => SetProperty(ref phone, value, true);
        }

        private string address;
        [Required]
        [DisplayName("用户地址")]
        public string Address {
            get => address;
            set => SetProperty(ref address, value, true);
        }

        private string password;
        [Required, StringLength(18,MinimumLength = 8)]
        [DisplayName("用户密码")]
        public string Password {
            get => password;
            set => SetProperty(ref password,value,true);
        }

        private DateTime createTime;
        [DisplayName("创建日期")]
        [DataType(DataType.Date)]
        public DateTime CreateTime {
            get => createTime;
            set => SetProperty(ref createTime,value, true);
        }

        public User()
        {
            
        }

        public User(int id, string name, string password, string phone, string address, DateTime createTime)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Address = address;
            this.Password = password;
            this.CreateTime = createTime;
        }
    }
}
