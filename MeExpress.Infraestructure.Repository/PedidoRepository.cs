using MeExpress.Domain.Enums;
using MeExpress.Domain.Interfaces;
using MeExpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Infraestructure.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private static List<Pedido> pedidos = new List<Pedido>();
        public void AlterarStatusDoPedido(string pedidoId, PedidoStatus status)
        {
            var pedido = pedidos.Where(p => p.Id == pedidoId).FirstOrDefault();
            pedido.Status = status;
        }

        public void Incluir(Pedido pedido)
        {
            pedidos.Add(pedido);
        }

        public List<Pedido> ObterPedidos()
        {
            return pedidos;
        }

        public List<Pedido> ObterPedidosEmProducao()
        {
            return pedidos.Where(p => p.Status == PedidoStatus.EmProducao).ToList();
        }

        public List<Pedido> ObterPedidosEmTransporte()
        {
            return pedidos.Where(p => p.Status == PedidoStatus.EmTransporte).ToList();
        }

        public List<Pedido> ObterPedidosEntregues()
        {
            return pedidos.Where(p => p.Status == PedidoStatus.Entregue).ToList();
        }

        public List<Pedido> ObterPedidosProduzidos()
        {
            return pedidos.Where(p => p.Status == PedidoStatus.Produzido).ToList();
        }

        public List<Pedido> ObterPedidosSolicitados()
        {
            return pedidos.Where(p => p.Status == PedidoStatus.Solicitado).ToList();
        }
    }
}
