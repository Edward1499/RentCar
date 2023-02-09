using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Inspections
{
    public class InspectionResponse
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        public bool HasScratches { get; set; }
        public string FuelQuantity { get; set; }
        public bool HasSpareTire { get; set; }
        public bool HasHydraulicJack { get; set; }
        public bool HasGlassBreak { get; set; }
        public bool IsRightFrontTireOk { get; set; }
        public bool IsLeftFrontTireOk { get; set; }
        public bool IsRightRearTireOk { get; set; }
        public bool IsLeftRearTireOk { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
