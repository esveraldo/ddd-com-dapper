using MeExpress.Application.Service.Interfaces;
using MeExpress.Domain.Enums;
using MeExpress.Domain.Models;
using MeExpress.Domain.ViewModels;
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

        public ActionResult PedidoIncluir(string clienteId)
        {
            var pedido = _pedidoAppService.ObterNovoPedido(clienteId);
            return View(pedido);
        }

        [HttpPost]
        public ActionResult PedidoIncluir(Pedido pedido)
        {
            if (HttpContext.Request.Form["submitButton"].ToString() != null)
            {
                pedido.Status = PedidoStatus.Solicitado;
                _pedidoAppService.Incluir(pedido);
                return RedirectToAction("Inicio");
            }
            return View(pedido);

        }

        public ActionResult PedidoPorStatus(PedidoStatus status)
        {
            List<Pedido> pedidos = null;
            switch (status)
            {
                case PedidoStatus.Solicitado:
                    pedidos = _pedidoAppService.ObterPedidosSolicitados();
                    break;
                case PedidoStatus.EmProducao:
                    pedidos = _pedidoAppService.ObterPedidosEmProducao();
                    break;
                case PedidoStatus.Produzido:
                    pedidos = _pedidoAppService.ObterPedidosProduzidos();
                    break;
                case PedidoStatus.EmTransporte:
                    pedidos = _pedidoAppService.ObterPedidosEmTransporte();
                    break;
                case PedidoStatus.Entregue:
                    pedidos = _pedidoAppService.ObterPedidosEntregues();
                    break;

            }

            if (pedidos == null)
            {
                return RedirectToAction("Inicio");
            }

            var lista = new PedidoListViewModel();
            lista.PedidoList = pedidos;
            lista.Status = status;


            return View(lista);
        }


        public ActionResult PedidoAlterarStatus(string pedidoId, PedidoStatus status)
        {
            _pedidoAppService.AlterarStatusDoPedido(pedidoId, status);
            return RedirectToAction("Inicio");

        }
    }
}
