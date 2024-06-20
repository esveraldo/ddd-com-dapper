using MeExpress.Application.Service.Interfaces;
using MeExpress.Domain.Enums;
using MeExpress.Domain.Interfaces;
using MeExpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Application.Service.Services
{
    public class PedidoAppService : IPedidoAppService
    {
        private IPedidoRepository pedidoRepository;
        private IProdutoRepository produtoRepository;
        private IClienteRepository clienteRepository;

        public PedidoAppService(IPedidoRepository pedidoRepositoryInstance, IProdutoRepository produtoRepositoryInstance, IClienteRepository clienteRepositoryInstance)
        {
            this.pedidoRepository = pedidoRepositoryInstance;
            this.produtoRepository = produtoRepositoryInstance;
            this.clienteRepository = clienteRepositoryInstance;
        }

        public void AlterarStatusDoPedido(string pedidoId, PedidoStatus status)
        {
            pedidoRepository.AlterarStatusDoPedido(pedidoId, status);
        }

        public void Incluir(Pedido pedido)
        {
            pedidoRepository.Incluir(pedido);
        }

        public Pedido ObterNovoPedido(string clienteId)
        {
            var pedido = new Pedido();
            pedido.Cliente = clienteRepository.ObterPorId(clienteId);
            var produtos = produtoRepository.ObterList();
            pedido.ProdutoList = new List<PedidoProdutoItem>();
            foreach (var produto in produtos)
            {
                pedido.ProdutoList.Add(new PedidoProdutoItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    Produto = new Produto()
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Preco = produto.Preco
                    },
                    Quantidade = 0
                });
            }
            pedido.Id = Guid.NewGuid().ToString();
            return pedido;
        }

        public List<Pedido> ObterPedidos()
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObterPedidosEmProducao()
        {
            return pedidoRepository.ObterPedidosEmProducao();
        }

        public List<Pedido> ObterPedidosEmTransporte()
        {
            return pedidoRepository.ObterPedidosEmTransporte();
        }

        public List<Pedido> ObterPedidosEntregues()
        {
            return pedidoRepository.ObterPedidosEntregues();
        }

        public List<Pedido> ObterPedidosProduzidos()
        {
            return pedidoRepository.ObterPedidosProduzidos();
        }

        public List<Pedido> ObterPedidosSolicitados()
        {
            return pedidoRepository.ObterPedidosSolicitados();
        }
    }
}
