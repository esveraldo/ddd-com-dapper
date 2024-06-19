using MeExpress.Domain.Models;

namespace MeExpress.Domain.Tests.DomainTests
{
    public class TCliente
    {
        [Fact]
        public void ClienteTeste()
        {
            var cliente = new Cliente();
            cliente.Id = Guid.NewGuid().ToString();
            cliente.Nome = "Esveraldo Martins";
            cliente.CPF = "111.222.333-00";
            cliente.Email = "esveraldo@teste.com";
            cliente.Empresa = "XPTO";
            cliente.Endereco = "Avenida Amaral Peixoto";
            cliente.Numero = "576 fundos";
            cliente.Complemento = "Lojas A,B e C";
            cliente.Bairro = "Gávea";

            Console.WriteLine(cliente.Id);
            Console.WriteLine(cliente.Nome);
            Console.WriteLine(cliente.CPF);
            Console.WriteLine(cliente.Email);
            Console.WriteLine(cliente.Empresa);
            Console.WriteLine(cliente.Endereco);
            Console.WriteLine(cliente.Numero);
            Console.WriteLine(cliente.Complemento);
            Console.WriteLine(cliente.Bairro);
            Console.WriteLine(cliente.Cidade);
            Console.WriteLine(cliente.Estado);

            Assert.Equal("São Paulo", cliente.Cidade);
        }
    }
}