using MassageStudioApp.Abstractions;
using MassageStudioApp.Data;
using MassageStudioApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateClient(string firstName, string lastName, string phone, DateTime birthDate, string userId)
        {
                if (_context.Clients.Any(p => p.UserId == userId))
                {
                    throw new InvalidOperationException("Client already exist.");
                }
            Client clientForDb = new Client()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = phone,
                    BirthDate = birthDate,
                    UserId = userId
                };
                _context.Clients.Add(clientForDb);

                return _context.SaveChanges() != 0;
        }

        public List<Client> GetClients()
        {
            List<Client> clients = _context.Clients.ToList();

            return clients;
        }

        public Client GetClientById(int clientId)
        {
            Client client = _context.Clients.Find(clientId);

            return client;
        }

        public string GetFullName(int clientId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int clientId)
        {
            throw new NotImplementedException();
        }

        public Client GetClientByUserId(string userId)
        {
            var client = _context.Clients.FirstOrDefault(x => x.UserId == userId);

            return client;
        }
    }
}
