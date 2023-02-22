using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Model
{
    public class Administrators
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }

        public Administrators()
        {
            
        }

        public Administrators(int id, string name, string password, string createTime)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.CreateTime = DateTime.Parse(createTime);
        }
    }
}
