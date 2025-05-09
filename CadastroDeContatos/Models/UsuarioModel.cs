using System.ComponentModel.DataAnnotations;
using CadastroDeContatos.Enums;

namespace CadastroDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o email do usuário")]
        [EmailAddress(ErrorMessage = "O email informado não é válido!")]
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Password { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }


    }
}
