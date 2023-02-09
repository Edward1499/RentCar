using BLL.DTOs.Brands;
using BLL.DTOs.VehicleImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    internal interface IVehicleImageService
    {
        IEnumerable<VehicleImageDTO> GetAll();
        VehicleImageDTO Get(int id);
        VehicleImageDTO Add(VehicleImageDTO request);
        VehicleImageDTO Update(int id, VehicleImageDTO request);
        void Delete(int id);
    }
}
