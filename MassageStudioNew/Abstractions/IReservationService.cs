using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Abstractions
{
    public interface IReservationService
    {
        bool CreateReservation(int hourId, string userId, int categoryId);
    }
}
