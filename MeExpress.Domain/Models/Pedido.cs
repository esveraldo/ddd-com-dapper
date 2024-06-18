using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Domain.Models
{
    public class Pedido
    {
        public string Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataSolicitado { get; set; }
        public DateTime? DataEmProducao { get; set; }
        public DateTime? DataProduzido { get; set; }
        public DateTime? DataEmTransporte { get; set; }
        public DateTime? DataEntregue { get; set; }
        public List<PedidoProdutoItem> ProdutoList { get; set; }
    }
}
