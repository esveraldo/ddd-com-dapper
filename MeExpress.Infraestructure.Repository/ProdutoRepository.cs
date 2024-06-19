using MeExpress.Domain.Interfaces;
using MeExpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Infraestructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public List<Produto> ObterProdutoList()
        {
            var lista = new List<Produto>();
            lista.Add(new Produto()
            {
                Id = "ABC",
                Nome = "Bloco de 500 folhas",
                Preco = 30
            });

            lista.Add(new Produto()
            {
                Id = "XYZ",
                Nome = "Bloco de 500 folhas",
                Preco = 30
            });

            return lista;
        }
    }
}
