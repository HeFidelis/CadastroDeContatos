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

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositories.BuscarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositories.BuscarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            _contatoRepositories.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositories.Adicionar(contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            _contatoRepositories.Atualizar(contato);
            return RedirectToAction("Index");
        }
    }
}
