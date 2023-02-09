using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Transactions
{
    public class TransactionResponse
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double AmountDay { get; set; }
        public int TotalDays { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
