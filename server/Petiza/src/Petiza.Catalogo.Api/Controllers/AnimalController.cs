using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petiza.Catalogo.Application.Services;
using Petiza.Catalogo.Application.ViewModels;

namespace Petiza.Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalApplicationService _animalApplicationService;
        public AnimalController(IAnimalApplicationService animalApplicationService)
        {
            _animalApplicationService = animalApplicationService;
        }
        // GET: api/Animal
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Animal/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Animal
        [HttpPost]
        public void CadastrarAnimal([FromBody] AnimalViewModel animalVM)
        {
            Ok();
        }

        // PUT: api/Animal/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
