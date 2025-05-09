using CadastroDeContatos.Models;
using CadastroDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositories _usuarioRepositories;
        public UsuarioController(IUsuarioRepositories usuarioRepositories)
        {
            _usuarioRepositories = usuarioRepositories;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositories.BuscarTodos();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositories.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário adicionado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos adicionar seu usuário, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
