using AutoMapper;
using BLL.DTOs.Vehicles;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportExecutionService;
using System.Net;
using System.ServiceModel;
using BLL.Connected_Services.ReportExecutionService;
using DAL;

namespace BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository vehicleRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly ApplicationDbContext dbContext;

        public VehicleService(
            IMapper mapper,
            IVehicleRepository vehicleRepository,
            ITransactionRepository transactionRepository,
            ApplicationDbContext dbContext
        )
        {
            this.mapper = mapper;
            this.vehicleRepository = vehicleRepository;
            this.transactionRepository = transactionRepository;
            this.dbContext = dbContext;
        }

        public async Task Test(string mainDirectory)
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            binding.MaxReceivedMessageSize = 10485760; //10MB limit

            const string SSRSReportExecutionUrl = "http://edward/ReportServer/ReportExecution2005.asmx?wsdl";

            //ReportExecutionService rs = new ReportExecutionService();
            var rsExec = new ReportExecutionServiceSoapClient(binding, new EndpointAddress(SSRSReportExecutionUrl));

            //Setup access credentials.
            var clientCredentials = new NetworkCredential("", "", ".");
            if (rsExec.ClientCredentials != null)
            {
                rsExec.ClientCredentials.Windows.AllowedImpersonationLevel =
                    System.Security.Principal.TokenImpersonationLevel.Impersonation;
                rsExec.ClientCredentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
            }

            // rsExec.ExecutionHeaderValue = new ExecutionHeader();
            var executionInfo = new ExecutionInfo();
            try
            {
                //This handles the problem of "Missing session identifier"
                rsExec.Endpoint.EndpointBehaviors.Add(new ReportingServicesEndpointBehavior());
                await rsExec.LoadReportAsync(null, "/testreport", null);
                //List<ParameterValue> parameters = new List<ParameterValue>();
                //parameters.Add(new ParameterValue { Name = "parameterId", Value = "value" });
                ParameterValue[] parameters = new ParameterValue[2];
                parameters[0] = new ParameterValue();
                parameters[0].Name = "StartDate";
                parameters[0].Value = "2023-02-08";
                parameters[1] = new ParameterValue();
                parameters[1].Name = "EndDate";
                parameters[1].Value = "2023-02-09";
                await rsExec.SetExecutionParametersAsync(null, null, Parameters: parameters, ParameterLanguage: "");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            //List<ParameterValue> parameters = new List<ParameterValue>();

            //parameters.Add(new ParameterValue { Name = "parameterId", Value = "value" });

            //rs.SetExecutionParameters(parameters.ToArray(), "en-US");


            string deviceInfo = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";
            string mimeType;
            string encoding;
            string[] streamId;
            Warning[] warning;

            try
            {
                string path = Path.Combine(mainDirectory, "wwwroot\\Files", "tempreport.pdf");
                var response = await rsExec.RenderAsync(new RenderRequest(null, null, "PDF", deviceInfo));
                File.WriteAllBytes(path, response.Result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<VehicleResponse> GetAllActive()
        {
            return mapper.Map<IEnumerable<VehicleResponse>>(vehicleRepository.Find(x => x.IsActive));
        }

        public GetAllVehiclesResponse GetAll(GetAllVehiclesParams vehiclesParams)
        {
            var vehicles = vehicleRepository
                .GetAll();

            int count = vehicles.Count();

            bool? isActive;

            if (vehiclesParams.IsActive == "null")
            {
                isActive = null;
            } else if (vehiclesParams.IsActive == "true")
            {
                isActive = true;
            } else
            {
                isActive = false;
            }

            //vehicles = vehicles.Where(x => vehiclesParams.FuelId > 0 ? x.FuelId == vehiclesParams.FuelId : true &&
            //                          vehiclesParams.VehicleTypeId > 0 ? x.VehicleTypeId == vehiclesParams.VehicleTypeId : true &&
            //                          vehiclesParams.BrandId > 0 ? x.BrandId == vehiclesParams.BrandId : true &&
            //                          vehiclesParams.ModelId > 0 ? x.ModelId == vehiclesParams.ModelId : true &&
            //                          isActive != null ? x.IsActive == isActive : true
            //                         )
            vehicles = vehicles.Where(x => (vehiclesParams.FuelId > 0 ? x.FuelId == vehiclesParams.FuelId : true) &&
                                      (vehiclesParams.VehicleTypeId > 0 ? x.VehicleTypeId == vehiclesParams.VehicleTypeId : true) &&
                                      (vehiclesParams.BrandId > 0 ? x.BrandId == vehiclesParams.BrandId : true) &&
                                      (vehiclesParams.ModelId > 0 ? x.ModelId == vehiclesParams.ModelId : true) &&
                                      (isActive != null ? x.IsActive == isActive : true)
                                     )
                               .OrderByDescending(x => x.CreatedAt)
                               .Skip(vehiclesParams.PageSize * (vehiclesParams.PageIndex - 1))
                               .Take(vehiclesParams.PageSize)
                               .AsEnumerable();

            var response = new GetAllVehiclesResponse
            {
                PageIndex = vehiclesParams.PageIndex,
                PageSize = vehiclesParams.PageSize,
                Count = count,
                Data = mapper.Map<IEnumerable<VehicleResponse>>(vehicles)
            };

            return response;
        }

        public VehicleResponse Get(int id)
        {
            return mapper.Map<VehicleResponse>(vehicleRepository.GetById(id));
        }

        public VehicleResponse Add(CreateVehicleRequest request)
        {
            return mapper.Map<VehicleResponse>(vehicleRepository.Add(mapper.Map<Vehicle>(request)));
        }

        public VehicleResponse Update(int id, CreateVehicleRequest request)
        {
            var vehicle = vehicleRepository.GetById(id);

            if (vehicle == null)
            {
                throw new Exception("Pending Implementation...");
            }

            vehicle.Description = request.Description;
            vehicle.ChasisNumber = request.ChasisNumber;
            vehicle.EngineNumber = request.EngineNumber;
            vehicle.LicensePlate = request.LicensePlate;
            vehicle.VehicleTypeId = request.VehicleTypeId;
            vehicle.BrandId = request.BrandId;
            vehicle.ModelId = request.ModelId;
            vehicle.FuelId = request.FuelId;
            vehicle.IsActive = request.IsActive;
            return mapper.Map<VehicleResponse>(vehicleRepository.Update(vehicle));
        }

        public void Delete(int id)
        {
            var vehicle = vehicleRepository.GetById(id);

            if (vehicle != null)
            {
                dbContext.Database.BeginTransaction();

                transactionRepository.RemoveRange(transactionRepository.Find(x => x.VehicleId == vehicle.Id).ToList());
                
                vehicleRepository.Remove(vehicle);

                dbContext.Database.CommitTransaction();
            }
        }
    }
}
