﻿using System;

namespace EP.CursoMvc.Domain.Model
{
    public class Endereco : Entity
    {


        public Endereco()
        {
            Id = Guid.NewGuid();
        }
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public Guid ClienteId { get; set; }

        
        //Propriedade de Navegação do EF
        public virtual Cliente Cliente { get; set; }
    }
}