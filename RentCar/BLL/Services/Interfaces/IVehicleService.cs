using BLL.DTOs.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IVehicleService
    {
        IEnumerable<VehicleResponse> GetAllActive();
        GetAllVehiclesResponse GetAll(GetAllVehiclesParams vehiclesParams);
        VehicleResponse Get(int id);
        VehicleResponse Add(CreateVehicleRequest request);
        VehicleResponse Update(int id, CreateVehicleRequest request);
        void Delete(int id);
        Task Test(string mainDirectory);
    }
}
