using DomainValidation.Validation;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Model;
using EP.CursoMvc.Domain.Specifications.Clientes;

namespace EP.CursoMvc.Domain.Validations.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {

        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var clienteUnico = new ClienteDeveSerUnicoSpecification(clienteRepository);

            

            base.Add("ClienteUnico", new Rule<Cliente>(clienteUnico, "Cliente com CPF ou E-mail já cadastrado"));
        }
    }
}
