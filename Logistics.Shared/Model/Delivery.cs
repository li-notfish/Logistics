using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Model
{
    public class Delivery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string State { get; set; }

        public Delivery()
        {
            
        }

        public Delivery(int id, string name, string password, string address, string phone, string log, string State)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.Address = address;
            this.Phone = phone;
            this.Description = log;
            this.State = State;
        }
    }
}
