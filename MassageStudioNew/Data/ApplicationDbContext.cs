using MassageStudioApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MassageStudioApp.Models.Employee;
using MassageStudioApp.Models.Client;
using MassageStudioApp.Models.Hour;
using MassageStudioApp.Models.Reservation;
using MassageStudioApp.Models.Category;

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
  
        public  DbSet<Category> Categories { get; set; }

        public DbSet<MassageStudioApp.Entities.Hour> Hours { get; set; }

        public DbSet<MassageStudioApp.Entities.Reservation> Reservations { get; set; }

        public DbSet<MassageStudioApp.Entities.Massage> Massages { get; set; }

    }
}
