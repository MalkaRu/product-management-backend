using Clean.Core.Entities;
using Clean.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Services
{
    public interface IClientService
    {
        List<ClientDto> GetClients();
        ClientDto GetById(int id);
        ClientDto Add(ClientDto clientDto);
        void Update(ClientDto clientDto);
        void Delete(int id);
    }
}
