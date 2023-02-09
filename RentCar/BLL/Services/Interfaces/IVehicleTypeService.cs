using BLL.DTOs.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IVehicleTypeService
    {
        IEnumerable<VehicleTypeResponse> GetAllActive();
        IEnumerable<VehicleTypeResponse> GetAll();
        VehicleTypeResponse Get(int id);
        VehicleTypeResponse Add(CreateVehicleTypeRequest request);
        VehicleTypeResponse Update(int id, CreateVehicleTypeRequest request);
        void Delete(int id);
    }
}
