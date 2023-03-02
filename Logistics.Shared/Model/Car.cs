using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Model
{
    public class Car {
        [DisplayName("Id")]
        public int CarId { get; set; }
        [Required]
        [DisplayName("车名")]
        public string CarName { get; set; }
        [Required]
        [DisplayName("车类型")]
        public string CarType { get; set; } = "大货车";

        public Car()
        {
            
        }

        public Car(int carId, string carName, string carType)
        {
            this.CarId = carId;
            this.CarName = carName;
            this.CarType = carType;
        }
    }
}
