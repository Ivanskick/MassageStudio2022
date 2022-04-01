using MassageStudioApp.Abstractions;
using MassageStudioApp.Data;
using MassageStudioApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateReservation(int hourId, string userId, int categoryId)
        {
            var client = _context.Clients.FirstOrDefault(x => x.UserId == userId);
            var reservation = new Reservation
            {
                HourId = hourId,
                ClientId = client.Id,
                CategoryId = categoryId
            };

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            var hour = _context.Hours.Find(hourId);
            hour.ReservationId = reservation.Id;
            _context.Update(hour);
            return _context.SaveChanges() != 0;
        }
    }
}
