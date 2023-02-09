using AutoMapper;
using BLL.DTOs.Models;
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
    public class ModelService : IModelService
    {
        private readonly IMapper mapper;
        private readonly IModelRespository modelRespository;

        public ModelService(
            IMapper mapper,
            IModelRespository modelRespository
        )
        {
            this.mapper = mapper;
            this.modelRespository = modelRespository;
        }

        public IEnumerable<ModelResponse> GetAllActive()
        {
            return mapper.Map<IEnumerable<ModelResponse>>(modelRespository.Find(x => x.IsActive)).OrderBy(x => x.Description);
        }

        public IEnumerable<ModelResponse> GetAll()
        {
            return mapper.Map<IEnumerable<ModelResponse>>(modelRespository.GetAll());
        }

        public ModelResponse Get(int id)
        {
            return mapper.Map<ModelResponse>(modelRespository.GetById(id));
        }

        public IEnumerable<ModelResponse> GetByBrandId(int brandId)
        {
            return mapper.Map<IEnumerable<ModelResponse>>(modelRespository.Find(x => x.BrandId == brandId));
        }

        public ModelResponse Add(CreateModelRequest request)
        {
            return mapper.Map<ModelResponse>(modelRespository.Add(mapper.Map<Model>(request)));
        }

        public ModelResponse Update(int id, CreateModelRequest request)
        {
            var model = modelRespository.GetById(id);

            if (model == null)
            {
                throw new Exception("Pending Implementation...");
            }

            model.BrandId = request.BrandId;
            model.Description = request.Description;
            model.IsActive = request.IsActive;
            return mapper.Map<ModelResponse>(modelRespository.Update(model));
        }

        public void Delete(int id)
        {
            var model = modelRespository.GetById(id);

            if (model != null)
            {
                modelRespository.Remove(model);
            }
        }
    }
}
