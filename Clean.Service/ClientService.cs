using AutoMapper;
using Clean.Core.Entities;
using Clean.Core.DTOs;
using Clean.Core.Repositories;
using Clean.Core.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Service
{
    public class ClientService:IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<ClientDto> GetClients()
        {
            var clients= _repository.GetClients();
            return _mapper.Map<List<ClientDto>>(clients);
        }

        public ClientDto GetById(int id)
        {
            var c = _repository.GetById(id);
            return _mapper.Map<ClientDto>(c);
        }

        public ClientDto Add(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            var newClient = _repository.Add(client);
            return _mapper.Map<ClientDto>(newClient);
        }

        public void Update(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            _repository.Update(client);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
