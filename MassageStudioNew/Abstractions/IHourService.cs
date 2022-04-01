using MassageStudioApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Abstractions
{
    public interface IHourService
    {
        bool CreateHour(DateTime freeHour, int doctorId);
        bool UpdateHour(int hourId, DateTime freeHour, int doctorId);
        List<Hour> GetHours();
        List<Hour> GetFreeHours();
        Hour GetHourById(int hourId);
        List<Reservation> GetReservationsByHour(int hourId);
        public bool RemoveById(int hourId);
    }
}
