using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Vehicles
{
    public class GetAllVehiclesParams
    {
        public int PageSize { get; set; } = 12;
        public int PageIndex { get; set; }
        public int FuelId { get; set; }
        public int VehicleTypeId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public string IsActive { get; set; }
    }
}
