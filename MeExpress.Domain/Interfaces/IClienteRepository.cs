using MeExpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorId(string id);
        void Incluir(Cliente cliente);
        void Alterar(Cliente cliente);
    }
}
