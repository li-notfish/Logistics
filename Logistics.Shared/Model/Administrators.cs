using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Model
{
    public class Administrators
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="这是必填的")]
        public string Name { get; set; }
        [Required(ErrorMessage = "这是必填的"), StringLength(18,MinimumLength = 8,ErrorMessage ="密码长度不符合要求")]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "密码不一致")]
        public string ConfirmPassword { get;set; }

        public Administrators()
        {
            
        }

        public Administrators(int id, string name, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
        }
    }
}
