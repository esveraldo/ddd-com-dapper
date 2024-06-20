using ExemploDDD.Repository.Connection;
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

        public List<Pedido> ObterPedidos()
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObterPedidosEmProducao()
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObterPedidosEmTransporte()
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObterPedidosEntregues()
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObterPedidosProduzidos()
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObterPedidosSolicitados()
        {
            throw new NotImplementedException();
        }
    }
}
