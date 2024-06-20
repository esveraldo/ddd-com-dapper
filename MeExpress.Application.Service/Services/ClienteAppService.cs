using MeExpress.Application.Service.Interfaces;
using MeExpress.Domain.Interfaces;
using MeExpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Application.Service.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private IClienteRepository clienteRepository;

        public ClienteAppService(IClienteRepository clienteRepositoryInstance)
        {
            this.clienteRepository = clienteRepositoryInstance;
        }


        public void Alterar(Cliente cliente)
        {
            clienteRepository.Alterar(cliente);
        }

        public void Incluir(Cliente cliente)
        {
            clienteRepository.Incluir(cliente);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return clienteRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorId(string id)
        {
            return clienteRepository.ObterPorId(id);
        }
    }
}
