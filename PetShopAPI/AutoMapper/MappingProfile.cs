using AutoMapper;
using Dominio.Entidades;
using PetShopAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAPI.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateDono, Dono>()
                .ForMember(dest => dest.Id, map => 
                    map.MapFrom(src => src.DonoId))
                .ReverseMap();
            CreateMap<CreateDono, Authentication>()
                .ForMember(dest => dest.Id, map => 
                    map.MapFrom(src => src.AuthenticationId))
                .ReverseMap();


            CreateMap<CreateFuncionario, Funcionario>()
                .ForMember(dest => dest.Id, map =>
                    map.MapFrom(src => src.FuncionarioId))
                .ReverseMap();
            CreateMap<CreateFuncionario, Authentication>()
                .ForMember(dest => dest.Id, map =>
                    map.MapFrom(src => src.AuthenticationId))
                .ReverseMap();


            CreateMap<CreateAnimal, Animal>()
                .ForMember(dest => dest.Id, map =>
                     map.MapFrom(src => src.AnimalId))
                .ReverseMap();
            CreateMap<CreateAnimal, DonoAnimal>()
                .ForMember(dest => dest.AnimalId, map =>
                    map.MapFrom(src => src.AnimalId))
                .ReverseMap();
        }
    }
}
