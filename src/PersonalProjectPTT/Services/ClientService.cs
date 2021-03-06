﻿using PersonalProjectPTT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProjectPTT.Models;

namespace PersonalProjectPTT.Services
{
    public class ClientService : IClientService

    {
        private IGenericRepository _repo;
        private IProjectService _ps;

        public ClientService(IGenericRepository repo, IProjectService ps)
        {
            _repo = repo;
            _ps = ps;
        }

        public void AddClient(Client client)
        {
            _repo.Add(client);
        }

        public List<Client> AllClients()
        {
            List<Client> clients = (from c in _repo.Query<Client>()
                             select c
                           ).ToList();



            return clients;
        }

        public void DeleteClient(int id)
        {
            Client toDelete = GetClient(id);

            string client_name = toDelete.Name;

            if (_ps.GetProjectsByClientName(client_name).Count == 0)
                _repo.Delete(toDelete);
            else
                throw new Exception();
        }

        public Client GetClient(int id)
        {
            Client client = (from c in _repo.Query<Client>()
                           where c.Id == id
                             select c
                           ).FirstOrDefault();
            return client;
        }

        public void UpdateClient(Client client)
        {
            _repo.Update(client);
        }
    }
}
