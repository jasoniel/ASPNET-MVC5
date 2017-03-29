using EP.CursoMvc.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace EP.CursoMvc.Infra.Data.EntityConfig
{
    class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {

        public EnderecoConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(e => e.Complemento)
                .HasMaxLength(100);

            //HasOptional(e => e.Cliente)
            //    .WithMany(c => c.Enderecos)
            //    .HasForeignKey(e => e.ClienteId);

            // ONE TO ONE OR ZERO
            // ONE TO ONE
            // ONE TO MANY
            // MANY TO MANY

            HasRequired(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);

            ToTable("Enderecos");
        }


    }
}
