using MeExpress.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Domain.Models
{
    public class Pedido
    {
        public Pedido()
        {
            Status = PedidoStatus.Solicitado;
        }
        public string Id { get; set; }
        public int Numero {  get; set; }
        public Cliente Cliente { get; set; }
        public PedidoStatus Status { get; set; }
        public DateTime DataSolicitado { get; set; }
        public DateTime? DataEmProducao { get; set; }
        public DateTime? DataProduzido { get; set; }
        public DateTime? DataEmTransporte { get; set; }
        public DateTime? DataEntregue { get; set; }
        public List<PedidoProdutoItem> ProdutoList { get; set; }

        public string StatusDescricao
        {
            get
            {
                switch (Status)
                {
                    case PedidoStatus.Solicitado:
                        return "Solicitado";
                    case PedidoStatus.EmProducao:
                        return "Em Produção";
                    case PedidoStatus.Produzido:
                        return "Produzido";
                    case PedidoStatus.EmTransporte:
                        return "Em transporte";
                    case PedidoStatus.Entregue:
                        return "Entregue";
                    default:
                        return string.Empty;
                }
            }
        }

        public string ProximoStatus
        {
            get
            {
                switch (Status)
                {
                    case PedidoStatus.Solicitado:
                        return "Em Produção";
                    case PedidoStatus.EmProducao:
                        return "Produzido";
                    case PedidoStatus.Produzido:
                        return "Em transporte";
                    case PedidoStatus.EmTransporte:
                        return "Entregue";
                    default:
                        return string.Empty;
                }
            }
        }

        public decimal ValorTotal
        {
            get
            {
                return ProdutoList.Sum(t => t.Total);
            }
        }
    }
}
