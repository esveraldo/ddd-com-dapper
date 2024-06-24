using MeExpress.Domain.Enums;
using MeExpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Domain.ViewModels
{
    public class PedidoListViewModel
    {
        public PedidoStatus Status { get; set; }
        public List<Pedido> PedidoList { get; set; }
    }
}
