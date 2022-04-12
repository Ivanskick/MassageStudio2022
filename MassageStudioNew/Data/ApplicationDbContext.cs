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
        public DbSet<MassageStudioApp.Models.Employee.CreateEmployeeVM> CreateEmployeeVM { get; set; }
        public DbSet<MassageStudioApp.Models.Client.ClientListingVM> ClientListingVM { get; set; }
        public DbSet<MassageStudioApp.Models.Client.CreateClientVM> CreateClientVM { get; set; }
        public DbSet<MassageStudioApp.Models.Employee.EmployeeListingVM> EmployeeListingVM { get; set; }

        public  DbSet<Category> Categories { get; set; }

        public DbSet<MassageStudioApp.Entities.Hour> Hours { get; set; }

        public DbSet<MassageStudioApp.Entities.Reservation> Reservations { get; set; }

        public DbSet<MassageStudioApp.Models.Hour.AddHourVM> AddHourVM { get; set; }

        public DbSet<MassageStudioApp.Models.Hour.AllHoursVM> AllHoursVM { get; set; }

        public DbSet<MassageStudioApp.Models.Reservation.AddReservationVM> AddReservationVM { get; set; }

        public DbSet<MassageStudioApp.Models.Reservation.AllReservationsVM> AllReservationsVM { get; set; }

        public DbSet<MassageStudioApp.Models.Employee.EditEmployeeVM> EditEmployeeVM { get; set; }

        public DbSet<MassageStudioApp.Models.Employee.EmployeeDetailsVM> EmployeeDetailsVM { get; set; }

        public DbSet<MassageStudioApp.Models.Category.CreateCategoryVM> CreateCategoryVM { get; set; }

        public DbSet<MassageStudioApp.Models.Category.CategoryListingVM> CategoryListingVM { get; set; }

        public DbSet<MassageStudioApp.Models.Category.CategoryDetailsVM> CategoryDetailsVM { get; set; }




    }
}
