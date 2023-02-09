using AutoMapper;
using BLL.DTOs.Inspections;
using BLL.DTOs.VehicleTypes;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class InspectionService : IInspectionService
    {
        private readonly IMapper mapper;
        private readonly IInspectionRepository inspectionRepository;

        public InspectionService(
            IMapper mapper,
            IInspectionRepository inspectionRepository
        )
        {
            this.mapper = mapper;
            this.inspectionRepository = inspectionRepository;
        }

        public IEnumerable<InspectionResponse> GetAllActive()
        {
            return mapper.Map<IEnumerable<InspectionResponse>>(inspectionRepository.Find(x => x.IsActive));
        }

        public IEnumerable<InspectionResponse> GetAll()
        {
            return mapper.Map<IEnumerable<InspectionResponse>>(inspectionRepository.GetAll());
        }

        public InspectionResponse Get(int id)
        {
            return mapper.Map<InspectionResponse>(inspectionRepository.GetById(id));
        }

        public InspectionResponse Add(CreateInspectionRequest request)
        {
            return mapper.Map<InspectionResponse>(inspectionRepository.Add(mapper.Map<Inspection>(request)));
        }

        public InspectionResponse Update(int id, CreateInspectionRequest request)
        {
            var inspection = inspectionRepository.GetById(id);

            if (inspection == null)
            {
                throw new Exception("Pending Implementation...");
            }

            inspection.VehicleId = request.VehicleId;
            inspection.ClientId = request.ClientId;
            inspection.HasScratches = request.HasScratches;
            inspection.FuelQuantity = request.FuelQuantity;
            inspection.HasSpareTire = request.HasSpareTire;
            inspection.HasHydraulicJack = request.HasHydraulicJack;
            inspection.HasGlassBreak = request.HasGlassBreak;
            inspection.IsRightFrontTireOk = request.IsRightFrontTireOk;
            inspection.IsLeftFrontTireOk = request.IsLeftFrontTireOk;
            inspection.IsRightRearTireOk = request.IsRightRearTireOk;
            inspection.IsLeftRearTireOk = request.IsLeftRearTireOk;
            inspection.EmployeeId = request.EmployeeId;
            inspection.IsActive = request.IsActive;
            return mapper.Map<InspectionResponse>(inspectionRepository.Update(inspection));
        }

        public void Delete(int id)
        {
            var inspection = inspectionRepository.GetById(id);

            if (inspection != null)
            {
                inspectionRepository.Remove(inspection);
            }
        }
    }
}
