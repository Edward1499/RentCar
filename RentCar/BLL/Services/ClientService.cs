using AutoMapper;
using BLL.DTOs.Clients;
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
    public class ClientService : IClientService
    {
        private readonly IMapper mapper;
        private readonly IClientRepository clientRepository;

        public ClientService(
            IMapper mapper,
            IClientRepository clientRepository
        )
        {
            this.mapper = mapper;
            this.clientRepository = clientRepository;
        }

        public IEnumerable<ClientResponse> GetAllActive()
        {
            return mapper.Map<IEnumerable<ClientResponse>>(clientRepository.Find(x => x.IsActive));
        }

        public IEnumerable<ClientResponse> GetAll()
        {
            return mapper.Map<IEnumerable<ClientResponse>>(clientRepository.GetAll());
        }

        public ClientResponse Get(int id)
        {
            return mapper.Map<ClientResponse>(clientRepository.GetById(id));
        }

        public ClientResponse Add(CreateClientRequest request)
        {
            return mapper.Map<ClientResponse>(clientRepository.Add(mapper.Map<Client>(request)));
        }

        public ClientResponse Update(int id, CreateClientRequest request)
        {
            var client = clientRepository.GetById(id);

            if (client == null)
            {
                throw new Exception("Pending Implementation...");
            }

            client.Name = request.Name;
            client.LastName = request.LastName;
            client.PersonalNumber = request.PersonalNumber;
            client.CRNumber = request.CRNumber;
            client.CRName = request.CRName;
            client.CRExpiration = request.CRExpiration;
            client.CRCCVNumber = request.CRCCVNumber;
            client.CreditLimit = request.CreditLimit;
            client.PersonType = request.PersonType;
            client.IsActive = request.IsActive;
            return mapper.Map<ClientResponse>(clientRepository.Update(client));
        }

        public void Delete(int id)
        {
            var client = clientRepository.GetById(id);

            if (client != null)
            {
                clientRepository.Remove(client);
            }
        }
    }
}
