﻿using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FuelRepository : BaseRepositoryDAO<Fuel>, IFuelRepository
    {
        private readonly ApplicationDbContext dbContext;

        public FuelRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override IEnumerable<Fuel> GetAll()
        {
            return dbContext.Fuels.OrderByDescending(x => x.CreatedAt);
        }
    }
}
