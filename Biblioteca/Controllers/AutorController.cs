﻿using Microsoft.AspNetCore.Mvc;
using Biblioteca.BL.Interfaces;
using Biblioteca.Entities.DTO;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService service;
        public AutorController(IAutorService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AutorDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]

        public async Task<IActionResult> GetAll()
        {
            IEnumerable<AutorDto> result = (IEnumerable<AutorDto>)await this.service.GetAutoresAsync();
            return (result != null && result.Any()) ? (IActionResult)this.Ok(result) : (IActionResult)this.NoContent();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AutorDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]

        public async Task<IActionResult> Get(int id)
        {
            AutorDto obj = (AutorDto)await this.service.GetAutorByIdAsync(id);
            return (obj != null) ? (IActionResult)this.Ok(obj) : (IActionResult)this.NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Post(AutorDto model)
        {
            if (model == null)
            {
                return (IActionResult)this.BadRequest();
            }
            int result = await this.service.InsertAutorAsync(model);
            return (result > 0) ? (IActionResult)this.CreatedAction("Post", result) : (IActionResult)this.BadRequest();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AutorDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Put(int id, AutorDto model)
        {
            if (model == null)
            {
                return (IActionResult)this.BadRequest();
            }
            AutorDto result = await this.service.UpdateAutorAsync(model);
            return (result != null) ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

       public async Task<IActionResult> Delete(int id)
        {
            bool result = await this.service.DeleteAutorAsync(id);
            return (result) ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest();
        }
    }
}
