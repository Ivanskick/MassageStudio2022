using MassageStudioApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Abstractions
{

        public interface IClientService
        {
            List<Client> GetClients();

            Client GetClientById(int clientId);

            public bool RemoveById(int clientId);

            string GetFullName(int clientId);

            bool CreateClient(string firstName, string lastName, string phone, DateTime birthDate, string userId);

        public Client GetClientByUserId(string userId);
        }
    
}
