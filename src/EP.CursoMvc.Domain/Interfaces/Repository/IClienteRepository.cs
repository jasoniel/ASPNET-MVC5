using EP.CursoMvc.Domain.Model;
using System.Collections.Generic;

namespace EP.CursoMvc.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {

        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);

        IEnumerable<Cliente> ObterAtivos();
    }
}
