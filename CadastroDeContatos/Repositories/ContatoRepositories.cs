using CadastroDeContatos.Data;
using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositories
{
    public class ContatoRepositories : IContatoRepositories
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositories(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            // gravar no banco de dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
    }
}
