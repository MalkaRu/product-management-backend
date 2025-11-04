using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Clean.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;
        }
        public List<Client> GetClients()
        {
            return _context.clients.ToList();
        }
        public Client GetById(int id)
        {
            return _context.clients.FirstOrDefault(c => c.Id == id);
        }


        public Client Add(Client client)
        {
            _context.clients.Add(client);
            _context.SaveChanges();
            return client;
        }

        public void Update(Client client)
        {
            _context.clients.Update(client);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var client = GetById(id);
            if (client != null)
            {
                _context.clients.Remove(client);
                _context.SaveChanges();
            }
        }


    }
}
