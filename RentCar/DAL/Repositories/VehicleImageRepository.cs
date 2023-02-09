using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class VehicleImageRepository : BaseRepositoryDAO<VehicleImage>, IVehicleImageRepository
    {
        public VehicleImageRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
