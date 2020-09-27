using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Petiza.Mvc.Models;

namespace Petiza.Mvc.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult Index()
        {
            return View();
        }

        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var model = new AnimalViewModel() { Ativo = true, CategoriaId = Guid.NewGuid(), Categoria = new CategoriaViewModel() { Codigo = 1, Nome = "Cachorro" }, DataCadastro = DateTime.Now, Descricao = collection["Descricao"], Imagem = collection["Imagem"], Nome = collection["Nome"], QuantidadeEstoque = int.Parse(collection["QuantidadeEstoque"]) };
            //var model = new AnimalViewModel() { Ativo = true, Categoria = new CategoriaViewModel() { Codigo = 1, Nome = "Cachorro" }, CategoriaId = Guid.NewGuid(), DataCadastro = DateTime.Now, Descricao = "Teste", Imagem = "Imagem", QuantidadeEstoque = 1, Nome = "Toby" };
            //var vm = collection as AnimalViewModel;
            try
            {
                using (var client = new HttpClient())
                {
                    string baseUrl = "http://localhost:5001";
                    client.BaseAddress = new Uri(baseUrl);
                    int result = client.PostAsync("/api/Animal/cadastrar",
                                                  model,
                                                  new JsonMediaTypeFormatter())
                                        .Result
                                        .Content
                                        .ReadAsAsync<int>()
                                        .Result;

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Animal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Animal/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}