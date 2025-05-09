using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositories
{
    public interface IContatoRepositories
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
    }
}
