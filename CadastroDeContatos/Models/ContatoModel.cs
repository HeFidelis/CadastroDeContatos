﻿using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "O email informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o numero do contato")]
        [Phone(ErrorMessage = "O número de celular informado não é válido!")]
        public string Celular { get; set; }

        public int? UsuarioId { get; set; }
        
        public UsuarioModel? Usuario { get; set; }
    }
}
