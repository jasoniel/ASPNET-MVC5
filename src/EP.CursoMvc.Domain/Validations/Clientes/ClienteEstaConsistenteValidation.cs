using DomainValidation.Validation;
using EP.CursoMvc.Domain.Model;
using EP.CursoMvc.Domain.Specifications.Clientes;

namespace EP.CursoMvc.Domain.Validations.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {

        public ClienteEstaConsistenteValidation()
        {
            var CPFCliente = new ClienteDeveTerCpfValidoSpecification();
            var ClienteEmail = new ClienteDeveTerEmailValidoSpecification();
            var clienteMaiorIdade = new ClienteDeveSerMaiorDeIdadeSpecification();

            base.Add("CPFClienteValido", new Rule<Cliente>(CPFCliente, "Cliente informou um CPF inválido."));
            base.Add("ClienteEmail", new Rule<Cliente>(ClienteEmail, "Cliente informou um e-mail inválido."));
            base.Add("ClienteMaiorIdade", new Rule<Cliente>(clienteMaiorIdade, "Cliente não tem maioridade para cadastro."));



        }

    }
}
