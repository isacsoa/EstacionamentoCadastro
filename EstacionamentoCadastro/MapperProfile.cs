using AutoMapper;
using EstacionamentoCadastro.Modelo;
using EstacionamentoCadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoCadastro
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Carro, CarroViewModel>();
            CreateMap<CarroViewModel, Carro>();

            CreateMap<Manobrista, ManobristaViewModel>();
            CreateMap<ManobristaViewModel, Manobrista>();

            CreateMap<CarroManobrado, CarroManobradoViewModel>();
            CreateMap<CarroManobradoViewModel, CarroManobrado>();

        }
    }
}
