﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositories
{
    public interface IContatoRepositories
    {
        List<ContatoModel> BuscarTodos(int usuarioId);
        ContatoModel BuscarPorId(int id);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
