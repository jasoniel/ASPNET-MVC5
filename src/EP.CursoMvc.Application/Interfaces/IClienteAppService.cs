using EP.CursoMvc.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace EP.CursoMvc.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {

        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);

        ClienteViewModel ObterPorId(Guid id);

        IEnumerable<ClienteViewModel> ObterTodos();

        IEnumerable<ClienteViewModel> obterAtivos();

        ClienteViewModel ObterPorCpf(string cpf);

        ClienteViewModel ObterPorEmail(string email);

        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);

        void Remover(Guid id);

        //EnderecoViewModel AdicionarEndereco(EnderecoViewModel enderecoViewModel);
        //EnderecoViewModel AtualizarEndereco(EnderecoViewModel enderecoViewModel);
        //EnderecoViewModel ObterEnderecoPorId(Guid id);
        //void RemoverEndereco(Guid id);

    }
}
