using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Domain.Models
{
    public class PedidoProdutoItem
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
