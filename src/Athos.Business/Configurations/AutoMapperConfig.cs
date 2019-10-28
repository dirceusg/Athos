using Athos.Business.ViewModels;
using Athos.Entity.entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athos.Business.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Administradora, AdministradoraViewModel>().ReverseMap();
            CreateMap<Assunto, AssuntoViewModel>().ReverseMap();
            CreateMap<Condominio, CondominioViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
