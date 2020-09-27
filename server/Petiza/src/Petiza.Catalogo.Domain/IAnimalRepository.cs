using Petiza.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Petiza.Catalogo.Domain
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        Task<IEnumerable<Animal>> ObterTodos();
        Task<Animal> ObterPorId(Guid id);
        Task<IEnumerable<Animal>> ObterPorCategoria(int codigo);
        Task<IEnumerable<Categoria>> ObterCategorias();

        void Adicionar(Animal Animal);
        void Atualizar(Animal Animal);

        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
    }
}
