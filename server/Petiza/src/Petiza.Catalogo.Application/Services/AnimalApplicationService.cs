using AutoMapper;
using Petiza.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Petiza.Catalogo.Domain;
using System.IO;

namespace Petiza.Catalogo.Application.Services
{
    public class AnimalApplicationService : IAnimalApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IAnimalRepository _animalRepository;
        public AnimalApplicationService(IMapper mapper, IAnimalRepository animalRepository)
        {
            _mapper = mapper;
            _animalRepository = animalRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Foo()
        {

        }

        public async Task AdicionarAnimal(AnimalViewModel AnimalViewModel)
        {
            AnimalViewModel.Imagem = SetarUrlImagem(AnimalViewModel);

            AdicionarImagem(AnimalViewModel.File);

            var Animal = _mapper.Map<Animal>(AnimalViewModel);
            _animalRepository.Adicionar(Animal);

            await _animalRepository.UnitOfWork.Commit();
        }

        private string SetarUrlImagem(AnimalViewModel animalVM)
        {
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fullPath = Path.Combine(pathToSave, animalVM.File.FileName);
            return fullPath;
        }

        private void AdicionarImagem(Microsoft.AspNetCore.Http.IFormFile file)
        {
            try
            {
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = file.FileName;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
