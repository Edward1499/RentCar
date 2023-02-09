using BLL.DTOs.Inspections;
using BLL.DTOs.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IInspectionService
    {
        IEnumerable<InspectionResponse> GetAllActive();
        IEnumerable<InspectionResponse> GetAll();
        InspectionResponse Get(int id);
        InspectionResponse Add(CreateInspectionRequest request);
        InspectionResponse Update(int id, CreateInspectionRequest request);
        void Delete(int id);
    }
}
