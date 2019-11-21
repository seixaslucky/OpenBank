using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces.Service;
using OpenBank.Domain.Models;

namespace OpenBank.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciaController : ControllerBase
    {
        private IAgenciaService _service;
        public AgenciaController(IAgenciaService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("{id}", Name = "GetAgenciaWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetAll();
                var agenciaModels = result.Select(x => new AgenciaModel
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    Code = x.Code,
                    Name = x.Name
                });
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AgenciaModel agencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Agencia agenciatoInsert = new Agencia
                {
                    Name = agencia.Name,
                };
                var result = await _service.Post(agenciatoInsert);
                if (result != null)
                {
                    ClientModel agenciaModel = new ClientModel
                    {
                        Id = result.Id,
                        CreatedAt = result.CreatedAt,
                        Name = result.Name
                    };
                    return Created(new Uri(Url.Link("GetAgenciaWithId", new { id = result })), agenciaModel);
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
        public async Task<ActionResult> Put([FromBody] AgenciaModel agencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Agencia agenciatoUpdate = new Agencia
                {
                    Id = agencia.Id,
                    Code = agencia.Code,
                    Name = agencia.Name
                };
                var result = await _service.Put(agenciatoUpdate);
                if (result != null)
                {
                    Agencia agenciaModel = new Agencia
                    {
                        Id = result.Id,
                        Code = result.Code,
                        Name = result.Name
                    };
                    return Ok(agenciaModel);
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