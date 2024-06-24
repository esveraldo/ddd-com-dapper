using MeExpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Infraestructure.Repository.DataModel
{
    public class PedidoDataModel
    {
        public string Id { get; set; }
        public int Numero { get; set; }
        public DateTime DataSolicitado { get; set; }
        public DateTime? DataEmProducao { get; set; }
        public DateTime? DataProduzido { get; set; }
        public DateTime? DataEmTransporte { get; set; }
        public DateTime? DataEntregue { get; set; }
        public string ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteEmail { get; set; }
        public string ClienteEmpresa { get; set; }
        public string ClienteEndereco { get; set; }
        public string ClienteNumero { get; set; }
        public string ClienteComplemento { get; set; }
        public string ClienteBairro { get; set; }
        public string ClienteCidade { get; set; }
        public string ClienteEstado { get; set; }
        public string ClienteCPF { get; set; }
        public string ClienteCEP { get; set; }
        public int PedidoStatusId { get; set; }

        public Pedido ToPedido()
        {
            var p = new Pedido();
            p.Id = this.Id;
            p.Numero = this.Numero;
            p.DataSolicitado = this.DataSolicitado;
            p.DataEmProducao = this.DataEmProducao;
            p.DataEmTransporte = this.DataEmTransporte;
            p.DataEntregue = this.DataEntregue;
            p.DataProduzido = this.DataProduzido;
            p.Cliente = new Cliente();
            p.Cliente.Id = this.ClienteId;
            p.Cliente.Nome = this.ClienteNome;
            p.Cliente.Email = this.ClienteEmail;
            p.Cliente.Empresa = this.ClienteEmpresa;
            p.Cliente.Endereco = this.ClienteEndereco;
            p.Cliente.Numero = this.ClienteNumero;
            p.Cliente.Complemento = this.ClienteComplemento;
            p.Cliente.Bairro = this.ClienteBairro;
            p.Cliente.Cidade = this.ClienteCidade;
            p.Cliente.Estado = this.ClienteEstado;
            p.Cliente.Cep = this.ClienteCEP;
            p.Cliente.CPF = this.ClienteCPF;
            return p;

        }
    }
}
