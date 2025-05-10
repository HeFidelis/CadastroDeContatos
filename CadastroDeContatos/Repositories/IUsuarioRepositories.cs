    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositories
{
    public interface IUsuarioRepositories
    {
        UsuarioModel BuscarPorLogin(string login);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel BuscarPorId(int id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
    }
}
