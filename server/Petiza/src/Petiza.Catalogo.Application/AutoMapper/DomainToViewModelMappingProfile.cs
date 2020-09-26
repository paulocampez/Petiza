using Petiza.Catalogo.Application.ViewModels;
using Petiza.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Petiza.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Animal, AnimalViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
