using AutoMapper;
using BLL.DTOs.Brands;
using BLL.DTOs.VehicleImages;
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
    public class VehicleImageService : IVehicleImageService
    {
        private readonly IMapper mapper;
        private readonly IVehicleImageRepository vehicleImageRepository;

        public VehicleImageService(
            IMapper mapper,
            IVehicleImageRepository vehicleImageRepository
        )
        {
            this.mapper = mapper;
            this.vehicleImageRepository = vehicleImageRepository;
        }

        public IEnumerable<VehicleImageDTO> GetAll()
        {
            return mapper.Map<IEnumerable<VehicleImageDTO>>(vehicleImageRepository.GetAll());
        }

        public VehicleImageDTO Get(int id)
        {
            return mapper.Map<VehicleImageDTO>(vehicleImageRepository.GetById(id));
        }

        public VehicleImageDTO Add(VehicleImageDTO request)
        {
            return mapper.Map<VehicleImageDTO>(vehicleImageRepository.Add(mapper.Map<VehicleImage>(request)));
        }

        public VehicleImageDTO Update(int id, VehicleImageDTO request)
        {
            var vehicleImage = vehicleImageRepository.GetById(id);

            if (vehicleImage == null)
            {
                throw new Exception("Pending Implementation...");
            }

            return mapper.Map<VehicleImageDTO>(vehicleImageRepository.Update(vehicleImage));
        }

        public void Delete(int id)
        {
            var vehicleImage = vehicleImageRepository.GetById(id);

            if (vehicleImage != null)
            {
                vehicleImageRepository.Remove(vehicleImage);
            }
        }

        public void Delete(List<VehicleImage> images, string filePath)
        {
            vehicleImageRepository.RemoveRange(images);
        }
    }
}
