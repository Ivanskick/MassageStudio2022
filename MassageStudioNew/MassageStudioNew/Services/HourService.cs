using MassageStudioApp.Abstractions;
using MassageStudioApp.Data;
using MassageStudioApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Services
{
    public class HourService : IHourService
    {
        private readonly ApplicationDbContext _context;

        public HourService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateHour(DateTime freeHour, int employeeId)
        {
            var hour = new Hour
            {
                FreeHour = freeHour,
                EmployeeId = employeeId,
            };

            _context.Hours.Add(hour);
            return _context.SaveChanges() != 0;
        }

        public List<Hour> GetFreeHours()
        {
            List<Hour> hours = _context.Hours
               .Where(c => c.IsBusy == false)
               .ToList();
            return hours;
        }

        public Hour GetHourById(int hourId)
        {
            return _context.Hours.Find(hourId);
        }

        public List<Hour> GetHours()
        {
            List<Hour> hours = _context.Hours
                .ToList();
            return hours;
        }

        public List<Reservation> GetReservationsByHour(int hourId)
        {
            return _context.Reservations
               .Where(r => r.HourId == hourId)
               .ToList();
        }

        public bool RemoveById(int hourId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHour(int hourId, DateTime freeHour, int employeeId)
        {
            var hour = GetHourById(hourId);
            if (hour == default(Hour))
            {
                return false;
            }
            hour.FreeHour = freeHour;
            hour.EmployeeId = employeeId;
            hour.Employee = _context.Employees.Find(employeeId);


            _context.Update(hour);
            return _context.SaveChanges() != 0;
        }
    }
}
