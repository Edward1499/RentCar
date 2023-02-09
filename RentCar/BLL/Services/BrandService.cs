using AutoMapper;
using BLL.DTOs.Brands;
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
    public class BrandService : IBrandService
    {
        private readonly IMapper mapper;
        private readonly IBrandRepository brandRepository;

        public BrandService(
            IMapper mapper,
            IBrandRepository brandRepository
        )
        {
            this.mapper = mapper;
            this.brandRepository = brandRepository;
        }

        public IEnumerable<BrandResponse> GetAllActive()
        {
            return mapper.Map<IEnumerable<BrandResponse>>(brandRepository.Find(x => x.IsActive)).OrderBy(x => x.Description);
        }

        public IEnumerable<BrandResponse> GetAll()
        {
            return mapper.Map<IEnumerable<BrandResponse>>(brandRepository.GetAll());
        }

        public BrandResponse Get(int id)
        {
            return mapper.Map<BrandResponse>(brandRepository.GetById(id));
        }

        public BrandResponse Add(CreateBrandRequest request)
        {
            return mapper.Map<BrandResponse>(brandRepository.Add(mapper.Map<Brand>(request)));
        }

        public BrandResponse Update(int id, CreateBrandRequest request)
        {
            var brand = brandRepository.GetById(id);

            if (brand == null)
            {
                throw new Exception("Pending Implementation...");
            }

            brand.Description = request.Description;
            brand.IsActive = request.IsActive;
            return mapper.Map<BrandResponse>(brandRepository.Update(brand));
        }

        public void Delete(int id)
        {
            var brand = brandRepository.GetById(id);

            if (brand != null)
            {
                brandRepository.Remove(brand);
            }
        }
    }
}
