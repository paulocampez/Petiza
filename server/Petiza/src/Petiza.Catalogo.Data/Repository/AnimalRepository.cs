using Microsoft.EntityFrameworkCore;
using Petiza.Catalogo.Domain;
using Petiza.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Petiza.Catalogo.Data.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly CatalogoContext _context;
        public AnimalRepository(CatalogoContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Animal Animal)
        {
            _context.Animals.Add(Animal);
        }

        public void Adicionar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Animal Animal)
        {
            _context.Animals.Add(Animal);
        }

        public void Atualizar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
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

        public async Task<IEnumerable<Animal>> ObterTodos()
        {
            return await _context.Animals.AsNoTracking().ToListAsync();
        }
    }
}
