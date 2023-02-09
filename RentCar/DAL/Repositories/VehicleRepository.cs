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
    public class VehicleRepository : BaseRepositoryDAO<Vehicle>, IVehicleRepository
    {
        private readonly ApplicationDbContext dbContext;

        public VehicleRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override IEnumerable<Vehicle> GetAll()
        {
            return dbContext.Vehicles
                .Include(x => x.Images)
                .Include(x => x.Brand)
                .Include(x => x.Model)
                .Include(x => x.Fuel)
                .Include(x => x.VehicleType);
        }

        public override Vehicle GetById(int id)
        {
            return dbContext.Vehicles.AsNoTracking()
                .Include(x => x.Images)
                .Include(x => x.Brand)
                .Include(x => x.Model)
                .Include(x => x.Fuel)
                .Include(x => x.VehicleType)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
