using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Model
{
    public class Car
    {
        public string CarId { get; set; }
        public string CarName { get; set; }
        public string CarType { get; set; }

        public Car()
        {
            
        }

        public Car(string carId, string carName, string carType)
        {
            this.CarId = carId;
            this.CarName = carName;
            this.CarType = carType;
        }
    }
}
