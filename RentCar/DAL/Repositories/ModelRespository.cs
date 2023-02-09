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
    public class ModelRespository : BaseRepositoryDAO<Model>, IModelRespository
    {
        private readonly ApplicationDbContext dbContext;

        public ModelRespository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override IEnumerable<Model> GetAll()
        {
            return dbContext.Models.OrderByDescending(x => x.CreatedAt);
        }
    }
}
