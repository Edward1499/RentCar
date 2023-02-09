using BLL.DTOs.VehicleImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Vehicles
{
    public class CreateVehicleRequest
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
        public bool IsActive { get; set; } = true;
        public List<VehicleImageDTO> Images { get; set; }
    }
}
