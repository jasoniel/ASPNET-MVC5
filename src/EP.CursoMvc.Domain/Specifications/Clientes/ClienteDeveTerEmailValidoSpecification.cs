using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Model;
using EP.CursoMvc.Domain.ValueObjects;

namespace EP.CursoMvc.Domain.Specifications.Clientes
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {

            return Email.Validar(cliente.Email);
        }
    }
}
