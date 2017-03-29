using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Interfaces.Services;
using EP.CursoMvc.Domain.Model;
using System;

namespace EP.CursoMvc.Domain.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;



        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }



        public Cliente Adicionar(Cliente cliente)
        {

            return _clienteRepository.Adicionar(cliente);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepository.Atualizar(cliente);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        public void Remover(Guid id)
        {
             _clienteRepository.Remover(id);
        }
    }
}
