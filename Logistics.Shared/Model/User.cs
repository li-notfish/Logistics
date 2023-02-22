using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
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
