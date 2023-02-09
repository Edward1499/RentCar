using BLL.DTOs.Clients;
using BLL.DTOs.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientResponse> GetAllActive();
        IEnumerable<ClientResponse> GetAll();
        ClientResponse Get(int id);
        ClientResponse Add(CreateClientRequest request);
        ClientResponse Update(int id, CreateClientRequest request);
        void Delete(int id);
    }
}
