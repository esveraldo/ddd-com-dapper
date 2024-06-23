using MeExpress.Application.Service.Interfaces;
using MeExpress.Application.Service.Services;
using MeExpress.Domain.Interfaces;
using MeExpress.Infraestructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Infraestructure.IoC.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            //Repository
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPedidoProdutoItemRepository, PedidoProdutoItemRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();

            //Application
            services.AddTransient<IClienteAppService, ClienteAppService>();
            services.AddTransient<IPedidoAppService, PedidoAppService>();
            services.AddTransient<IProdutoAppService, ProdutoAppService>();

            return services;
        }
    }
}
