﻿using System;
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
        public List<Animaizinhos> Get()
        {
            List<Animaizinhos> animais = new List<Animaizinhos>();
            Animaizinhos animal1 = new Animaizinhos() { imageUrl = "images/welcome1.png" };
            Animaizinhos animal2 = new Animaizinhos() { imageUrl = "http://10.0.2.2:5001/Resources/Images/foo.jpeg" };
            animais.Add(animal1);
            animais.Add(animal2);
            return animais;
        }

        // GET: api/Animal/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Animal
        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            Ok();
        }

        [HttpPost]
        [Route("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _animalApplicationService.ObterTodos());
        }

        [HttpPost]
        [Route("cadastrar")]
        public void CadastrarAnimal([FromForm] AnimalViewModel animalVM)
        {
            var content = Request.ContentType;
            Ok(_animalApplicationService.AdicionarAnimal(animalVM));
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

        public class Cliente
        {
            public string token { get; set; }
            public Animaizinhos animal { get; set; }
        }
        public class Animaizinhos
        {
            public string id { get; set; }
            public string imageUrl { get; set; }
        }
        public class Teste
        {
            public string title { get; set; }
        }
    }
}
