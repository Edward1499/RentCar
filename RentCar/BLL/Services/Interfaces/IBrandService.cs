using BLL.DTOs.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IBrandService
    {
        IEnumerable<BrandResponse> GetAllActive();
        IEnumerable<BrandResponse> GetAll();
        BrandResponse Get(int id);
        BrandResponse Add(CreateBrandRequest request);
        BrandResponse Update(int id, CreateBrandRequest request);
        void Delete(int id);
    }
}
