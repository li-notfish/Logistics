using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Model
{
    public partial class Administrators : ObservableValidator 
    {
        [ObservableProperty]
        public int id;
        [ObservableProperty]
        [Required(ErrorMessage = "这是必填的")]
        public string name;
        [ObservableProperty]
        [Required(ErrorMessage = "这是必填的"), StringLength(18, MinimumLength = 8, ErrorMessage = "密码长度不符合要求")]
        public string password;
        [ObservableProperty]
        [DataType(DataType.Date)]
        public DateTime createTime;

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
