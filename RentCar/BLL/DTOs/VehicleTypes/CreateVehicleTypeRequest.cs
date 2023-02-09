using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.VehicleTypes
{
    public class CreateVehicleTypeRequest
    {
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
