using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.ViewModels;
using EP.CursoMvc.Infra.CrossCutting.MvcFilters;
using System;
using System.Net;
using System.Web.Mvc;

namespace Ep.CursoMvc.UI.Site.Controllers
{
    [Authorize]
    [RoutePrefix("gestao/crm")]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;


        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [Route("listar-clientes")]
        [ClaimsAuthorize("Cliente", "LT")]
        public ActionResult Index()
        {
            return View(_clienteAppService.obterAtivos());
        }

        [Route("{id:guid}/detalhe-cliente")]
        [ClaimsAuthorize("Cliente", "VI")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }


        [Route("novo-cliente")]
        [ClaimsAuthorize("Cliente", "IN")]
        public ActionResult Create()
        {
            return View();
        }


        [Route("novo-cliente")]
        [ClaimsAuthorize("Cliente", "IN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (!ModelState.IsValid)  return View(clienteEnderecoViewModel);

            clienteEnderecoViewModel = _clienteAppService.Adicionar(clienteEnderecoViewModel);

            if (clienteEnderecoViewModel.Cliente.ValidationResult.IsValid) return RedirectToAction("Index");
            
            foreach(var error in clienteEnderecoViewModel.Cliente.ValidationResult.Erros)
            {
                ModelState.AddModelError(String.Empty, error.Message);
            }

            return View(clienteEnderecoViewModel);
            
        }


        [Route("{id:guid}/editar-cliente")]
        [ClaimsAuthorize("Cliente", "ED")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/editar-cliente")]
        [ClaimsAuthorize("Cliente", "ED")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {

                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/excluir-cliente")]
        [ClaimsAuthorize("Cliente", "EX")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var  clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }


        [Route("{id:guid}/excluir-cliente")]
        [ClaimsAuthorize("Cliente","EX")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
