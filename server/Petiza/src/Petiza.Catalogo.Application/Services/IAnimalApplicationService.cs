using Petiza.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Petiza.Catalogo.Application.Services
{
    public interface IAnimalApplicationService : IDisposable
    {
        Task AdicionarAnimal(AnimalViewModel animalViewModel);
    }
}
