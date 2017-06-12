using PersonalProjectPTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectPTT.Interfaces
{
    public interface IClientService
    {
        List<Client> AllClients();
        void AddClient(Client client);
        void DeleteClient(int id);
        Client GetClient(int id);
        void UpdateClient(Client client);
    }
}
