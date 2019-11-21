using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenBank.Domain.Entities;
using OpenBank.Domain.Models;
using OpenBank.Domain.Interfaces.Service;
using System.Linq;
using Enums;

namespace OpenBank.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _service;
        private IClientService _serviceClient;
        private IAgenciaService _serviceAgencia;
        public AccountController(IAccountService service, IClientService serviceClient, IAgenciaService serviceAgencia)
        {
            _service = service;
            _serviceClient = serviceClient;
            _serviceAgencia = serviceAgencia;
        }

        [HttpGet]
        public async Task<ActionResult> GetAccount(int agenciaCode, int accountCode, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Get(agenciaCode, accountCode, password);
                AccountModel accountModel = new AccountModel
                {
                    Active = result.Active,
                    Code = result.Code,
                    CreatedAt = result.CreatedAt,
                    Id = result.Id,
                    IdAgencia = result.IdAgencia
                };
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateAccount",Name = "CreateAccount")]
        public async Task<ActionResult> CreateAccount(Guid idAgencia, Guid idClient, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (String.IsNullOrEmpty(password)) return StatusCode((int)HttpStatusCode.BadRequest, "Password invalid");
            try
            {
                Client client = await _serviceClient.Get(idClient);
                if (client == null) return StatusCode((int)HttpStatusCode.NotFound, "Client not found");
                Agencia agencia = await _serviceAgencia.Get(idAgencia);
                if (agencia == null) return StatusCode((int)HttpStatusCode.NotFound, "Agencia not found");
                var result = await _service.Post(agencia, client, password);
                AccountModel accountModel = new AccountModel
                {
                    Active = result.Active,
                    Code = result.Code,
                    CreatedAt = result.CreatedAt,
                    Id = result.Id,
                    IdAgencia = result.IdAgencia
                };
                return Created(new Uri(Url.Link("CreateAccount", new { id = accountModel.Id })), accountModel);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> AddClientToAccount(Guid idAccount, Guid idClient, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Client client = await _serviceClient.Get(idClient);
                if (client == null) return StatusCode((int)HttpStatusCode.NotFound, "Client not found");

                var result = await _service.AddClientToAccount(idAccount, client, password);
                AccountModel accountModel = new AccountModel
                {
                    Active = result.Active,
                    Code = result.Code,
                    CreatedAt = result.CreatedAt,
                    Id = result.Id,
                    IdAgencia = result.IdAgencia
                };
                return Ok(accountModel);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetHistory")]
        public async Task<ActionResult> GetHistory(int agenciaCode, int accountCode, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetHistory(agenciaCode, accountCode, password);
                var history = result.Select(x => new MovementModel
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    IdAccount = x.IdAccount,
                    Success = x.Success,
                    Type = ((TypeMovement)Enum.ToObject(typeof(TypeMovement), x.Type)).GetEnumDisplayName(),
                    Value = x.Value
                });

                return Ok(history);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Withdraw")]
        public async Task<ActionResult> Withdraw(Guid id, decimal value, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Withdraw(id, value, password);
                AccountModel accountModel = new AccountModel
                {
                    Active = result.Active,
                    Code = result.Code,
                    CreatedAt = result.CreatedAt,
                    Id = result.Id,
                    IdAgencia = result.IdAgencia,
                    Balance = result.Balance
                };
                return Ok(accountModel);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Deposit")]
        public async Task<ActionResult> Deposit(Guid id, decimal value, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Deposit(id, value, password);
                AccountModel accountModel = new AccountModel
                {
                    Active = result.Active,
                    Code = result.Code,
                    CreatedAt = result.CreatedAt,
                    Id = result.Id,
                    IdAgencia = result.IdAgencia,
                    Balance = result.Balance
                };
                return Ok(accountModel);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}