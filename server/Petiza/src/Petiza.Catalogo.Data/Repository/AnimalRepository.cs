using Petiza.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Petiza.Catalogo.Data.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        public void Adicionar(Animal Animal)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Animal Animal)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> ObterCategorias()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Animal>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<Animal> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Animal>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
