using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Inspection : BaseEntity
    {
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

        public virtual Vehicle Vehicle { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
