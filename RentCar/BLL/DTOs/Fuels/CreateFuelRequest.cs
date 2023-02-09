using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Fuels
{
    public class CreateFuelRequest
    {
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
