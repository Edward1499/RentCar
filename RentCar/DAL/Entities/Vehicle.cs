using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Description { get; set; }
        public string ChasisNumber { get; set; }
        public string EngineNumber { get; set; }
        public string LicensePlate { get; set; }
        public int Year { get; set; }
        public int VehicleTypeId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int FuelId { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Model Model { get; set; }
        public virtual Fuel Fuel { get; set; }
        public virtual List<VehicleImage> Images { get; set; }
    }
}
