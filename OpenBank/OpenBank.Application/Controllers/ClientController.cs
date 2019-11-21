using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces.Service;
using OpenBank.Domain.Models;

namespace OpenBank.Application.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase {
        private IClientService _service;
        public ClientController (IClientService service) {
            _service = service;
        }

        [HttpGet]
        [Route ("{id}", Name = "GetClientWithId")]
        public async Task<ActionResult> Get (Guid id) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            try {
                return Ok (await _service.Get (id));
            } catch (ArgumentException ex) {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route ("getbycpf{cpf}", Name = "GetWithCpf")]
        public async Task<ActionResult> GetByCpf(string cpf)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Get(cpf);

                ClientModel clientModel = new ClientModel
                {
                    Id = result.Id,
                    CreatedAt = result.CreatedAt,
                    BirthDate = result.BirthDate,
                    Cpf = result.Cpf,
                    Email = result.Email,
                    Name = result.Name
                };
                return Ok(clientModel);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(ClientToInsetModel client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Client clienttoInsert = new Client
                {
                    BirthDate = client.BirthDate,
                    Cpf = client.Cpf,
                    Email = client.Email,
                    Name = client.Name
                };
                var result = await _service.Post(clienttoInsert);
                if (result != null)
                {
                    ClientModel clientModel = new ClientModel
                    {
                        Id = result.Id,
                        CreatedAt = result.CreatedAt,
                        BirthDate = result.BirthDate,
                        Cpf = result.Cpf,
                        Email = result.Email,
                        Name = result.Name
                    };
                    return Created(new Uri(Url.Link("GetClientWithId", new { id = clientModel.Id })), clientModel);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(ClientModel client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Client clienttoUpdate = new Client
                {
                    Id = client.Id,
                    BirthDate = client.BirthDate,
                    Cpf = client.Cpf,
                    Email = client.Email,
                    Name = client.Name
                };
                var result = await _service.Put(clienttoUpdate);
                if (result != null)
                {
                    ClientModel clientModel = new ClientModel
                    {
                        Id = result.Id,
                        CreatedAt = result.CreatedAt,
                        BirthDate = result.BirthDate,
                        Cpf = result.Cpf,
                        Email = result.Email,
                        Name = result.Name
                    };
                    return Ok(clientModel);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}