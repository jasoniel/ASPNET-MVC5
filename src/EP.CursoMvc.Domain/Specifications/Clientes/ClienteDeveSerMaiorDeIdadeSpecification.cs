﻿using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Model;
using System;

namespace EP.CursoMvc.Domain.Specifications.Clientes
{
    public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            
            return DateTime.Now.Year - cliente.DataNascimento.Year >= 18;
        }
    }
}
