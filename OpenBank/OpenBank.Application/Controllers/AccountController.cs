using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces.Service;

namespace OpenBank.Application.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        private IAccountService _service;
        private IClientService _serviceClient;
        private IAgenciaService _serviceAgencia;
        public AccountController (IAccountService service, IClientService serviceClient, IAgenciaService serviceAgencia) {
            _service = service;
            _serviceClient = serviceClient;
            _serviceAgencia = serviceAgencia;
        }

        [HttpGet]
        public async Task<ActionResult> GetAccount ([FromBody] int agenciaCode, int accountCode, string password) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            try {
                return Ok (await _service.Get (agenciaCode, accountCode, password));
            } catch (ArgumentException ex) {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount (Guid idAgencia, Guid idClient, string password) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            if(String.IsNullOrEmpty(password)) return StatusCode ((int) HttpStatusCode.BadRequest, "Password invalid");
            try {
                Client client = await _serviceClient.Get(idClient);
                if(client == null) return StatusCode ((int) HttpStatusCode.NotFound, "Client not found");
                Agencia agencia = await _serviceAgencia.Get(idAgencia);
                if(client == null) return StatusCode ((int) HttpStatusCode.NotFound, "Agencia not found");
                return Ok (await _service.Post (agencia, client, password));
            } catch (ArgumentException ex) {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ActionResult> AddClientToAccount ([FromBody] Guid idAccount, Guid idClient, string password) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            try {
                Client client = await _serviceClient.Get(idClient);
                if(client == null) return StatusCode ((int) HttpStatusCode.NotFound, "Client not found");
                return Ok (await _service.AddClientToAccount (idAccount, client, password));
            } catch (ArgumentException ex) {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult> Withdraw ([FromBody] Guid id, decimal value, string password) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            try {
                return Ok (await _service.Withdraw (id, value, password));
            } catch (ArgumentException ex) {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Deposit ([FromBody] Guid id, decimal value, string password) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            try {
                return Ok (await _service.Deposit (id, value, password));
            } catch (ArgumentException ex) {
                return StatusCode ((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}