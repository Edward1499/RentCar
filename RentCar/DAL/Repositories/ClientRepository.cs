using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ClientRepository : BaseRepositoryDAO<Client>, IClientRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ClientRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override IEnumerable<Client> GetAll()
        {
            return dbContext.Clients.OrderByDescending(x => x.CreatedAt);
        }
    }
}
