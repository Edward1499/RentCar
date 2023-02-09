using AutoMapper;
using BLL.DTOs.VehicleTypes;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IMapper mapper;
        private readonly IVehicleTypeRepository vehicleTypeRepository;

        public VehicleTypeService(
            IMapper mapper,
            IVehicleTypeRepository vehicleTypeRepository
        )
        {
            this.mapper = mapper;
            this.vehicleTypeRepository = vehicleTypeRepository;
        }

        public IEnumerable<VehicleTypeResponse> GetAllActive() 
        {
            return mapper.Map<IEnumerable<VehicleTypeResponse>>(vehicleTypeRepository.Find(x => x.IsActive).OrderBy(x => x.Description));
        }

        public IEnumerable<VehicleTypeResponse> GetAll()
        {
            return mapper.Map<IEnumerable<VehicleTypeResponse>>(vehicleTypeRepository.GetAll());
        }

        public VehicleTypeResponse Get(int id) 
        { 
            return mapper.Map<VehicleTypeResponse>(vehicleTypeRepository.GetById(id));
        }

        public VehicleTypeResponse Add(CreateVehicleTypeRequest request)
        {
            return mapper.Map<VehicleTypeResponse>(vehicleTypeRepository.Add(mapper.Map<VehicleType>(request)));
        }

        public VehicleTypeResponse Update(int id, CreateVehicleTypeRequest request)
        {
            var vehicleType = vehicleTypeRepository.GetById(id);

            if (vehicleType == null)
            {
                throw new Exception("Pending Implementation...");
            }

            vehicleType.Description = request.Description;
            vehicleType.IsActive= request.IsActive;
            return mapper.Map<VehicleTypeResponse>(vehicleTypeRepository.Update(vehicleType));
        }

        public void Delete(int id) 
        {
            var vehicleType = vehicleTypeRepository.GetById(id);

            if (vehicleType != null)
            {
                vehicleTypeRepository.Remove(vehicleType);
            }
        }
    }
}
