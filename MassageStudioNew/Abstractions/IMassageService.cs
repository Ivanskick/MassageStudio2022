using MassageStudioApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Abstractions
{
    interface IMassageService
    {
        public List<Massage> GetMassages();
    }
}
