using BLL.DTOs.Brands;
using BLL.DTOs.Fuels;
using BLL.DTOs.Models;
using BLL.DTOs.VehicleImages;
using BLL.DTOs.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Vehicles
{
    public class VehicleResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ChasisNumber { get; set; }
        public string EngineNumber { get; set; }
        public string LicensePlate { get; set; }
        public int Year { get; set; }
        public int VehicleTypeId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int FuelId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public List<VehicleImageDTO> Images { get; set; }
        public BrandResponse Brand { get; set; }
        public ModelResponse Model { get; set; }
        public FuelResponse Fuel { get; set; }
        public VehicleTypeResponse VehicleType { get; set; }

    }
}
