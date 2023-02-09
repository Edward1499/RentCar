using BLL.DTOs.Fuels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IFuelService
    {
        IEnumerable<FuelResponse> GetAllActive();
        IEnumerable<FuelResponse> GetAll();
        FuelResponse Get(int id);
        FuelResponse Add(CreateFuelRequest request);
        FuelResponse Update(int id, CreateFuelRequest request);
        void Delete(int id);
    }
}
