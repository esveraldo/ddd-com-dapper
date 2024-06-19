using MeExpress.Domain.Interfaces;
using MeExpress.Domain.Models;
using MeExpress.Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Domain.Tests.UnitTests
{
    public class PedidoUnitTest
    {
        [Fact]
        public void PedidoTest()
        {
            var produtoRep = new ProdutoRepository();
            var pedidoProdutoItemRep = new PedidoProdutoItemRepository();

            var produtoList = produtoRep.ObterProdutoList();
            var itemList = new List<PedidoProdutoItem>();

            foreach (var p in produtoList)
            {
                itemList.Add(new PedidoProdutoItem() {
                    Quantidade = 0,
                    Produto = new Produto()
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Preco = p.Preco,
                    }
                });
            }

            foreach (var item in itemList)
            {
                Console.WriteLine(item.Quantidade + " " 
                    + item.Produto.Nome + " " 
                    + item.Produto.Preco.ToString("C") + " " 
                    + item.Produto.Id);
            }

            Assert.Equal(produtoList.Count, itemList.Count);
        }
    }
}
