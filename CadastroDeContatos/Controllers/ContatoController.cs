using CadastroDeContatos.Models;
using CadastroDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositories _contatoRepositories;
        public ContatoController(IContatoRepositories contatoRepositories)
        {
            _contatoRepositories = contatoRepositories;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositories.BuscarTodos();

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositories.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
