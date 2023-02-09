using AutoMapper;
using Azure.Core;
using BLL.DTOs.Transactions;
using BLL.DTOs.VehicleTypes;
using BLL.Services.Interfaces;
using DAL;
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
    public class TransactionService : ITransactionService
    {
        private readonly IMapper mapper;
        private readonly ITransactionRepository transactionRepository;
        private readonly IInspectionRepository inspectionRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly ApplicationDbContext dbContext;

        public TransactionService(
            IMapper mapper,
            ITransactionRepository transactionRepository,
            IInspectionRepository inspectionRepository,
            IVehicleRepository vehicleRepository,
            ApplicationDbContext dbContext
        )
        {
            this.mapper = mapper;
            this.transactionRepository = transactionRepository;
            this.inspectionRepository = inspectionRepository;
            this.vehicleRepository = vehicleRepository;
            this.dbContext = dbContext;
        }

        public IEnumerable<TransactionResponse> GetAllActive()
        {
            return mapper.Map<IEnumerable<TransactionResponse>>(transactionRepository.Find(x => x.IsActive));
        }

        public IEnumerable<TransactionResponse> GetAll()
        {
            return mapper.Map<IEnumerable<TransactionResponse>>(transactionRepository.GetAll());
        }

        public TransactionResponse Get(int id)
        {
            return mapper.Map<TransactionResponse>(transactionRepository.GetById(id));
        }

        public TransactionResponse Add(CreateTransactionRequest request)
        {
            dbContext.Database.BeginTransaction();

            var inspection = new Inspection
            {
                VehicleId = request.VehicleId,
                ClientId = request.ClientId,
                EmployeeId = request.EmployeeId,
                HasScratches = request.HasScratches,
                FuelQuantity = request.FuelQuantity,
                HasSpareTire = request.HasSpareTire,
                HasHydraulicJack = request.HasHydraulicJack,
                HasGlassBreak = request.HasGlassBreak,
                IsRightFrontTireOk = request.IsRightFrontTireOk,
                IsLeftFrontTireOk = request.IsLeftFrontTireOk,
                IsRightRearTireOk = request.IsRightRearTireOk,
                IsLeftRearTireOk = request.IsLeftRearTireOk
            };

            inspectionRepository.Add(inspection);

            var transaction = new Transaction
            {
                EmployeeId = request.EmployeeId,
                VehicleId = request.VehicleId,
                ClientId = request.ClientId,
                RentDate = request.RentDate,
                DeliveryDate = request.DeliveryDate,
                AmountDay = request.AmountDay,
                TotalDays = request.TotalDays,
                Description = request.Description
            };

            transactionRepository.Add(transaction);


            var vehicle = vehicleRepository.GetById(request.VehicleId);
            vehicle.IsActive = true;

            vehicleRepository.Update(vehicle);

            dbContext.Database.CommitTransaction();

            return mapper.Map<TransactionResponse>(transaction);
        }

        public TransactionResponse CompleteTransaction(int vehicleId)
        {
            dbContext.Database.BeginTransaction();

            var vehicle = vehicleRepository.GetById(vehicleId);
            vehicle.IsActive = false;

            vehicleRepository.Update(vehicle);

            var transaction = transactionRepository.Find(x => x.VehicleId == vehicleId && x.IsActive).FirstOrDefault();
            transaction.IsActive= false;

            transactionRepository.Update(transaction);

            dbContext.Database.CommitTransaction();

            return mapper.Map<TransactionResponse>(transaction);
        }

        public TransactionResponse Update(int id, CreateTransactionRequest request)
        {
            var transaction = transactionRepository.GetById(id);

            if (transaction == null)
            {
                throw new Exception("Pending Implementation...");
            }

            transaction.EmployeeId = request.EmployeeId;
            transaction.VehicleId = request.VehicleId;
            transaction.ClientId = request.ClientId;
            transaction.RentDate = request.RentDate;
            transaction.DeliveryDate = request.DeliveryDate;
            transaction.AmountDay = request.AmountDay;
            transaction.TotalDays = request.TotalDays;
            transaction.Description = request.Description;
            return mapper.Map<TransactionResponse>(transactionRepository.Update(transaction));
        }

        public void Delete(int id)
        {
            var transaction = transactionRepository.GetById(id);

            if (transaction != null)
            {
                transactionRepository.Remove(transaction);
            }
        }
    }
}
