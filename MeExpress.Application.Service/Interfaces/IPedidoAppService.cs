using MeExpress.Domain.Interfaces;
using MeExpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Application.Service.Interfaces
{
    public interface IPedidoAppService : IPedidoRepository
    {
        Pedido ObterNovoPedido(string clienteId);
    }
}
