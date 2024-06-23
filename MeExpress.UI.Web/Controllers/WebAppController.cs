using MeExpress.Application.Service.Interfaces;
using MeExpress.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeExpress.UI.Web.Controllers
{
    public class WebAppController : Controller
    {
        private readonly IClienteAppService _clienteAppService;
        private readonly IPedidoAppService _pedidoAppService;

        public WebAppController(IClienteAppService clienteAppService, IPedidoAppService pedidoAppService)
        {
            _clienteAppService = clienteAppService;
            _pedidoAppService = pedidoAppService;
        }

        public IActionResult Inicio()
        {
            return View();
        }

        public ActionResult PedidoNovo()
        {
            return View();
        }

        public ActionResult PedidoNovoConfirmarCliente(string CPF)
        {
            var cliente = _clienteAppService.ObterPorCpf(CPF);
            if (cliente == null)
            {
                cliente = new Cliente()
                {
                    CPF = CPF
                };

            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult PedidoNovoConfirmarCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Id))
            {
                cliente.Id = Guid.NewGuid().ToString();
                _clienteAppService.Incluir(cliente);
            }
            else
            {
                _clienteAppService.Alterar(cliente);
            }
            return RedirectToAction("PedidoIncluir", "WebApp", new { clienteId = cliente.Id });
        }
    }
}
