using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Repositories
{
    public interface IClientRepository
    {
        List<Client> GetClients();
        Client GetById(int id);
        Client Add(Client client);
        void Update(Client client);
        void Delete(int id);
    }
}
