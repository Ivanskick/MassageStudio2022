using MassageStudioApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MassageStudioApp.Models.Employee;
using MassageStudioApp.Models.Client;

namespace MassageStudioApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<MassageStudioApp.Models.Employee.CreateEmployeeVM> CreateEmployeeVM { get; set; }
        public DbSet<MassageStudioApp.Models.Client.ClientListingVM> ClientListingVM { get; set; }
        public DbSet<MassageStudioApp.Models.Client.CreateClientVM> CreateClientVM { get; set; }


    }
}
