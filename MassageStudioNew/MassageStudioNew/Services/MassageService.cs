using MassageStudioApp.Abstractions;
using MassageStudioApp.Data;
using MassageStudioApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Services
{
    public class MassageService : IMassageService
    {
        private readonly ApplicationDbContext _context;

        public MassageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Massage> GetMassages()
        {
            return _context.Massages.ToList();
        }
    }
}
