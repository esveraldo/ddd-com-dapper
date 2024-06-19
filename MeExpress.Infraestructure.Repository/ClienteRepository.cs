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
        private static List<Cliente> clientes = new List<Cliente>();

        public void Alterar(Cliente cliente)
        {
            var c = clientes.Where(c => c.Id == cliente.Id).FirstOrDefault();
            if (c != null) { return; }

            c.Nome = cliente.Nome;
            c.CPF = cliente.CPF;
            c.Email = cliente.Email;
            c.Empresa = cliente.Empresa;
            c.Endereco = cliente.Endereco;
            c.Bairro = cliente.Bairro;
            c.Numero = cliente.Numero;
            c.Complemento = cliente.Complemento;
            c.Cidade = cliente.Cidade;
            c.Estado = cliente.Estado;
        }

        public void Incluir(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            var c = clientes.Where(c=> c.CPF == cpf).FirstOrDefault();
            return c;
        }
    }
}
