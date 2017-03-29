using EP.CursoMvc.Domain.Model;
using System;

namespace EP.CursoMvc.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {

        Cliente Adicionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);




    }
}
