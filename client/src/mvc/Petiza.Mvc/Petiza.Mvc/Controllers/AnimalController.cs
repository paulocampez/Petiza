using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Petiza.Mvc.Models;

namespace Petiza.Mvc.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public AnimalController(IWebHostEnvironment hostEnvironment)
        {

        this._hostEnvironment = hostEnvironment;
        }
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
            var model = new AnimalViewModel() { Ativo = true, CategoriaId = Guid.Parse("4ee35607-2d8d-4e45-a21d-167ff918ee74"), Categoria = new CategoriaViewModel() { Codigo = 1, Nome = "Cachorro" }
            , DataCadastro = DateTime.Now,
              Descricao = collection["Descricao"],
              Imagem = collection["Imagem"],
              Nome = collection["Nome"],
              QuantidadeEstoque = int.Parse(collection["QuantidadeEstoque"]) };
            var imageModel = new ImageModel()
            {
                ImageFile = collection.Files.First()
            };

            try
            {
                using (var client = new HttpClient())
                {

                    MultipartFormDataContent form = new MultipartFormDataContent();
                    if (imageModel.ImageFile.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            imageModel.ImageFile.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            string s = Convert.ToBase64String(fileBytes);
                            // act on the Base64 data
                            form.Add(new ByteArrayContent(fileBytes, 0, fileBytes.Count()), "File", "foo.jpg");
                            form.Add(new StringContent(collection["Imagem"]), "Imagem");
                            form.Add(new StringContent(collection["Descricao"]), "Descricao");
                            form.Add(new StringContent(collection["Nome"]), "Nome");

                        }
                    }

                    string baseUrl = "http://localhost:5001";
                    client.BaseAddress = new Uri(baseUrl);
                    int result = client.PostAsync("/api/Animal/cadastrar",
                                                  form)
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