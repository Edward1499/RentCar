using BLL.DTOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IModelService
    {
        IEnumerable<ModelResponse> GetAllActive();
        IEnumerable<ModelResponse> GetAll();
        ModelResponse Get(int id);
        IEnumerable<ModelResponse> GetByBrandId(int brandId);
        ModelResponse Add(CreateModelRequest request);
        ModelResponse Update(int id, CreateModelRequest request);
        void Delete(int id);
    }
}
