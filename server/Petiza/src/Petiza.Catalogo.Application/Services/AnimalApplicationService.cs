using AutoMapper;
using Petiza.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Petiza.Catalogo.Domain;

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
            var Animal = _mapper.Map<Animal>(AnimalViewModel);
            _animalRepository.Adicionar(Animal);

            await _animalRepository.UnitOfWork.Commit();
        }
    }
}
