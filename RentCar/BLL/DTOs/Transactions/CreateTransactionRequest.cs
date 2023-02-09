using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Transactions
{
    public class CreateTransactionRequest
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
        public DateTime RentDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double AmountDay { get; set; }
        public int TotalDays { get; set; }
        public string Description { get; set; }
    }
}
