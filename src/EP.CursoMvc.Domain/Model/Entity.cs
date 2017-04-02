using DomainValidation.Validation;
using System;

namespace EP.CursoMvc.Domain.Model
{
    public abstract class Entity
    {

        public Guid Id { get; set; }


        public ValidationResult ValidationResult { get; set; }


        public abstract Boolean EhValido();
    }
}
