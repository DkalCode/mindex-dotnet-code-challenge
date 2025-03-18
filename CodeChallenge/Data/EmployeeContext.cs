using CodeChallenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Compensation> Compensations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Because we are adding Compensation to the EmployeeContext, we need to set a primary key for the Compensation entity.
            modelBuilder.Entity<Compensation>().HasKey(i => i.CompensationId);
        }
    }
}
