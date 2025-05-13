using CadastroDeContatos.Data;
using CadastroDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeContatos.Repositories
{
    public class UsuarioRepositories : IUsuarioRepositories
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositories(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());

        }

        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios
                .Include(x => x.Contatos)
                .ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            // gravar no banco de dados
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarPorId(usuario.Id);

            if(usuarioDB == null)
            {
                throw new Exception("Houve um erro na atualização do usuário");
            }
            // atualizar o usuário
            usuarioDB.Name = usuario.Name;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();
            return usuarioDB;
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDB = BuscarPorId(alterarSenhaModel.Id);

            if (usuarioDB == null)
            {
                throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");
            }

            if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual))
            {
                throw new Exception("Senha atual não confere!");
            }

            if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha))
            {
                throw new Exception("Nova senha deve ser diferente da senha atual!");
            }

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = BuscarPorId(id);

            if (usuarioDB == null)
            {
                throw new Exception("Houve um erro na deleção do usuário!");
            }

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
