using ExemploDDD.Repository.Connection;
using MeExpress.Domain.Enums;
using MeExpress.Domain.Interfaces;
using MeExpress.Domain.Models;
using MeExpress.Infraestructure.Repository.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Infraestructure.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        public void AlterarStatusDoPedido(string pedidoId, PedidoStatus status)
        {
            DbHelper.Execute("PedidoAlterarStatus", new {PedidoId = pedidoId, PedidoStatus = (int)status});
        }

        public void Incluir(Pedido pedido)
        {
            DbHelper.Execute("PedidoIncluir", new
            {
                Id = pedido.Id,
                DataSolicitado = DateTime.Now,
                ClienteId = pedido.Cliente.Id,
                ClienteNome = pedido.Cliente.Nome,
                ClienteEmail = pedido.Cliente.Email,
                ClienteEmpresa = pedido.Cliente.Empresa,
                ClienteEndereco = pedido.Cliente.Endereco,
                ClienteNumero = pedido.Cliente.Numero,
                ClienteComplemento = pedido.Cliente.Complemento,
                ClienteBairro = pedido.Cliente.Bairro,
                ClienteCidade = pedido.Cliente.Cidade,
                ClienteEstado = pedido.Cliente.Estado,
                ClienteCPF = pedido.Cliente.CPF,
                ClienteCEP = pedido.Cliente.Cep,
                PedidoStatusId = (int)pedido.Status
            });
            foreach (var item in pedido.ProdutoList)
            {
                DbHelper.Execute("PedidoProdutoIncluir", new
                {
                    Id = item.Id,
                    PedidoId = pedido.Id,
                    ProdutoId = item.Produto.Id,
                    ProdutoNome = item.Produto.Nome,
                    ProdutoPreco = item.Produto.Preco,
                    Quantidade = item.Quantidade
                });
            }
        }

        private List<Pedido> ObterPedidoPorStatus(PedidoStatus status)
        {
            var pedidoDataModelList = DbHelper.Query<PedidoDataModel>("PedidoObterPorPedidoStatus", new { PedidoStatusId = (int)status });
            var lista = new List<Pedido>();
            foreach (var pedidoDataModel in pedidoDataModelList)
            {
                lista.Add(ObterPedidoPorId(pedidoDataModel.Id));
            }
            return lista;
        }

        public Pedido ObterPedidoPorId(string id)
        {
            var pedidoDataModel = DbHelper.QueryFirstOrDefault<PedidoDataModel>("PedidoObterPorId", new { Id = id });
            var pedido = pedidoDataModel.ToPedido();

            var produtoListDataModel = DbHelper.Query<PedidoProdutoItemDataModel>("PedidoProdutoItemObterPorPedidoId", new { PedidoId = id }).Where(m => m.Quantidade > 0).ToList();

            pedido.ProdutoList = new List<PedidoProdutoItem>();
            foreach (var p in produtoListDataModel)
            {
                pedido.ProdutoList.Add(new PedidoProdutoItem()
                {
                    Id = p.Id,
                    Produto = new Produto()
                    {
                        Id = p.ProdutoId,
                        Nome = p.ProdutoNome,
                        Preco = p.ProdutoPreco
                    },
                    Quantidade = p.Quantidade
                });
            }
            return pedido;
        }

        public List<Pedido> ObterPedidos()
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObterPedidosEmProducao()
        {
            return ObterPedidoPorStatus(PedidoStatus.EmProducao);
        }

        public List<Pedido> ObterPedidosEmTransporte()
        {
            return ObterPedidoPorStatus(PedidoStatus.EmTransporte);
        }

        public List<Pedido> ObterPedidosEntregues()
        {
            return ObterPedidoPorStatus(PedidoStatus.Entregue);
        }

        public List<Pedido> ObterPedidosProduzidos()
        {
            return ObterPedidoPorStatus(PedidoStatus.Produzido);
        }

        public List<Pedido> ObterPedidosSolicitados()
        {
            return ObterPedidoPorStatus(PedidoStatus.Solicitado);
        }
    }
}
