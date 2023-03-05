using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Model
{
    public class User
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [Required]
        [DisplayName("用户名")]
        public string Name { get; set; }

        [Required,Phone]
        [DisplayName("手机号码")]
        public string Phone { get; set; }

        [Required]
        [DisplayName("用户地址")]
        public string Address { get; set; }

        [Required, StringLength(18,MinimumLength = 8)]
        [DisplayName("用户密码")]
        public string Password { get; set; }

        [DisplayName("创建日期")]
        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }

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
