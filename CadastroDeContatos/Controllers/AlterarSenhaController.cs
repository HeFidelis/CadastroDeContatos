using CadastroDeContatos.Helper;
using CadastroDeContatos.Models;
using CadastroDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositories _usuarioRepositories;
        private readonly ISessao _sessao;
        public AlterarSenhaController(IUsuarioRepositories usuarioRepositories,
                                      ISessao sessao)
        {
            _usuarioRepositories = usuarioRepositories;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterarSenhaModel.Id = usuarioLogado.Id;

                if (ModelState.IsValid)
                {
                    _usuarioRepositories.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar sua senha, tente novamente, detalhes do erro: {erro.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
