using AutoMapper;
using Petiza.Catalogo.Application.ViewModels;
using Petiza.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petiza.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AnimalViewModel, Animal>().ConstructUsing(p =>
            new Animal(p.Nome, p.Descricao, p.Ativo,
                p.CategoriaId, p.DataCadastro,
                p.Imagem));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}
