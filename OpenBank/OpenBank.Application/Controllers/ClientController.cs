using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces.Service;

namespace OpenBank.Application.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase {
        private IClientService _service;
        public ClientController (IClientService service) {
            _service = service;
        }
        //todo criar view models para vizualização de clients

        [HttpGet]
        [Route ("{id}", Name = "GetWithId")]
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
        [Route ("{cpf}", Name = "GetWithCpf")]
        public async Task<ActionResult> Get (string cpf) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            try {
                return Ok (await _service.Get (cpf));
            } catch (ArgumentException ex) {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] Client client) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            try {
                var result = await _service.Post (client);
                if (result != null) {
                    return Created (new Uri (Url.Link ("GetWithId", new { id = result })), result);
                } else {
                    return BadRequest ();
                }
            } catch (ArgumentException ex) {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put ([FromBody] Client client) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            try {
                var result = await _service.Put (client);
                if (result != null) {
                    return Ok (result);
                } else {
                    return BadRequest ();
                }
            } catch (ArgumentException ex) {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}