using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class VehicleImage
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string ImageUrl { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
