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
    public class VehicleTypeRepository : BaseRepositoryDAO<VehicleType>, IVehicleTypeRepository
    {
        private readonly ApplicationDbContext dbContext;

        public VehicleTypeRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override IEnumerable<VehicleType> GetAll()
        {
            return dbContext.VehicleTypes.OrderByDescending(x => x.CreatedAt);
        }
    }
}
