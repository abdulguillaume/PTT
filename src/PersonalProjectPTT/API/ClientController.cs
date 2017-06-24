using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalProjectPTT.Interfaces;
using PersonalProjectPTT.Models;
using Microsoft.AspNetCore.Authorization;

namespace PersonalProjectPTT.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
    public class ClientController : Controller
    {
        private IClientService _client;

        public ClientController(IClientService client)
        {
            _client = client;
        }

        [HttpGet]
        [Authorize]
        public List<Client> Get()
        {

            return _client.AllClients();

        }


        [HttpGet("{id}")]
        [Authorize]
        public Client Get(int id)
        {
            return _client.GetClient(id);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            else if (client.Id == 0)
            {
                client.CreateDate = DateTime.Now;
                _client.AddClient(client);
                return Ok();
            }
            else
            {
                _client.UpdateClient(client);
                return Ok();
            }

        }


        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public void Delete(int id)
        {
            _client.DeleteClient(id);
        }
    }
}