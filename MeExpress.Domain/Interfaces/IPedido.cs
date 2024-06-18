using MeExpress.Domain.Enums;
using MeExpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Domain.Interfaces
{
    public interface IPedido
    {
        void Incluir(Pedido pedido);
        List<Pedido> ObterPedidosSolicitados();
        List<Pedido> ObterPedidosEmProducao();
        List<Pedido> ObterPedidosProduzidos();
        List<Pedido> ObterPedidosEmTransporte();
        List<Pedido> ObterPedidosEntregues();
        List<Pedido> ObterPedidos();
        void AlterarStatusDoPedido(string PedidoId, PedidoStatus status);
    }
}
