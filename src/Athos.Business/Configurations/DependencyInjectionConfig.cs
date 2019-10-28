using Athos.Domain.Notifications;
using Athos.Domain.Notifications.Interfaces;
using Athos.Domain.Repository.Interfaces.Entities;
using Athos.Domain.Service.Interfaces.Entities;
using Athos.Domain.Service.Services.Entities;
using Athos.Repository.Context;
using Athos.Repository.Repository.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athos.Business.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services) 
        {


            services.AddScoped<AthosDbContext>();
            services.AddScoped<INotification, Notifier>();

            #region Repository

            services.AddScoped<IAdministradoraRepository, AdministradoraRepository>();
            services.AddScoped<IAssuntoRepository, AssuntoRepository>();
            services.AddScoped<ICondominioRepository, CondominioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IComunicadoRepository, ComunicadoRepository>();
            services.AddScoped<IComunicadoAcaoRepository, ComunicadoAcaoRepository>();


            #endregion

            #region Service

            services.AddScoped<IAdministradoraService, AdministradoraService>();
            services.AddScoped<IAssuntoService, AssuntoService>();
            services.AddScoped<ICondominioService, CondominioService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IComunicadoService, ComunicadoService>();
            services.AddScoped<IComunicadoAcaoService, ComunicadoAcaoService>();


            #endregion

            return services;
        }
    }
}
