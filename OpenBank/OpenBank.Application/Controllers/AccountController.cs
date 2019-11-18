﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces.Service;

namespace OpenBank.Application.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        private IAccountService _service;
        public AccountController (IAccountService service) {
            _service = service;
        }

//todo insert, put, delete;

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

        [HttpPut]
        public async Task<ActionResult> Withdraw (Guid id) {

            return null;
        }

        [HttpPut]
        public async Task<ActionResult> Deposit (Guid id) {

            return null;
        }
    }
}