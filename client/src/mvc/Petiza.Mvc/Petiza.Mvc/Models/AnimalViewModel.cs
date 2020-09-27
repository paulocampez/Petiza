using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petiza.Mvc.Models
{
    public class AnimalViewModel
    {
        public Guid CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Imagem { get; set; }
        public int QuantidadeEstoque { get; set; }
        public CategoriaViewModel Categoria { get; set; }

    }
}
