using ExemploDDD.Repository.Connection;
using MeExpress.Domain.Interfaces;
using MeExpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Infraestructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        
        public void Alterar(Cliente cliente)
        {
            DbHelper.Execute("ClienteAlterar", cliente);
        }

        public void Incluir(Cliente cliente)
        {
            DbHelper.Execute("ClienteIncluir", cliente);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return DbHelper.QueryFirstOrDefault<Cliente>("ClienteObterPorCPF", new { @CPF = cpf });
        }

        public Cliente ObterPorId(string id)
        {
            return DbHelper.QueryFirstOrDefault<Cliente>("ClienteObterPorId", new { @Id = id });
        }
    }
}
