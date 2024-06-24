using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Infraestructure.Repository.DataModel
{
    public class PedidoProdutoItemDataModel
    {
        public string Id { get; set; }
        public string PedidoId { get; set; }
        public string ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public decimal ProdutoPreco { get; set; }
        public int Quantidade { get; set; }
    }
}
