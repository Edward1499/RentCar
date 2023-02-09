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
    public class BrandRepository : BaseRepositoryDAO<Brand>, IBrandRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BrandRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override IEnumerable<Brand> GetAll()
        {
            return dbContext.Brands.OrderByDescending(x => x.CreatedAt);
        }
    }
}
