using Dapper;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Model;
using EP.CursoMvc.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EP.CursoMvc.Infra.Data.Repositoty
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {


        public ClienteRepository(CursoMvcContext context) : base(context)
        {

        }

        public  IEnumerable<Cliente> ObterAtivos()
        {


            var sql = @"SELECT * FROM Clientes c  WHERE c.Excluido = 0 AND c.Ativo = 1";
            return Db.Database.Connection.Query<Cliente>(sql);
        }



        //Usando Dapper =)
        public override IEnumerable<Cliente> ObterTodos()
        {


            var sql = @"SELECT * FROM Clientes c  WHERE c.Excluido = 0";
            return Db.Database.Connection.Query<Cliente>(sql);
        }

        public override Cliente ObterPorId(Guid id)
        {
            


            var sql = @"SELECT * FROM Clientes c " +
                       "LEFT JOIN Enderecos e  " +
                       "ON c.Id = e.ClienteId  " +
                       "WHERE c.Id = @uid";


            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) => { c.Enderecos.Add(e); return c; }, new { uid = id }).FirstOrDefault();
        }
    


        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {

            var cliente = ObterPorId(id);

            cliente.Ativo = false;
            cliente.Excluido = true;

            Atualizar(cliente);
        }
    }
}
