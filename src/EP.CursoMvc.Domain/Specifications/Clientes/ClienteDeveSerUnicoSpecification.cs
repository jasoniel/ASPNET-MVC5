using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Model;

namespace EP.CursoMvc.Domain.Specifications.Clientes
{
    public class ClienteDeveSerUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;


        public ClienteDeveSerUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }



        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorCpf(cliente.CPF) == null &&
                _clienteRepository.ObterPorEmail(cliente.Email) == null;
        }
    }
}
