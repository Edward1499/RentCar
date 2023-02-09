using BLL.DTOs.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<TransactionResponse> GetAllActive();
        IEnumerable<TransactionResponse> GetAll();
        TransactionResponse Get(int id);
        TransactionResponse Add(CreateTransactionRequest request);
        TransactionResponse CompleteTransaction(int vehicleId);
        TransactionResponse Update(int id, CreateTransactionRequest request);
        void Delete(int id);
    }
}
