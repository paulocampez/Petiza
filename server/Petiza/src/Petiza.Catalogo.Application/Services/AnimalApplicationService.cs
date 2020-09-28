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
        //private readonly IMapper _mapper;

        public AnimalApplicationService()
        {
            //_mapper = mapper;
            
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Foo()
        {

        }

    
    }
}
