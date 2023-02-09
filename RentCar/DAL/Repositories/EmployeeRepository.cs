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
    public class EmployeeRepository : BaseRepositoryDAO<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override IEnumerable<Employee> GetAll()
        {
            return dbContext.Employees.OrderByDescending(x => x.CreatedAt);
        }
    }
}
