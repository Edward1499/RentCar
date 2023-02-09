using AutoMapper;
using BLL.DTOs.Fuels;
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
    public class FuelService : IFuelService
    {
        private readonly IMapper mapper;
        private readonly IFuelRepository fuelRepository;

        public FuelService(
            IMapper mapper,
            IFuelRepository fuelRepository
        )
        {
            this.mapper = mapper;
            this.fuelRepository = fuelRepository;
        }

        public IEnumerable<FuelResponse> GetAllActive()
        {
            return mapper.Map<IEnumerable<FuelResponse>>(fuelRepository.Find(x => x.IsActive)).OrderBy(x => x.Description);
        }

        public IEnumerable<FuelResponse> GetAll()
        {
            return mapper.Map<IEnumerable<FuelResponse>>(fuelRepository.GetAll());
        }

        public FuelResponse Get(int id)
        {
            return mapper.Map<FuelResponse>(fuelRepository.GetById(id));
        }

        public FuelResponse Add(CreateFuelRequest request)
        {
            return mapper.Map<FuelResponse>(fuelRepository.Add(mapper.Map<Fuel>(request)));
        }

        public FuelResponse Update(int id, CreateFuelRequest request)
        {
            var fuel = fuelRepository.GetById(id);

            if (fuel == null)
            {
                throw new Exception("Pending Implementation...");
            }

            fuel.Description = request.Description;
            fuel.IsActive = request.IsActive;
            return mapper.Map<FuelResponse>(fuelRepository.Update(fuel));
        }

        public void Delete(int id)
        {
            var fuel = fuelRepository.GetById(id);

            if (fuel != null)
            {
                fuelRepository.Remove(fuel);
            }
        }
    }
}
