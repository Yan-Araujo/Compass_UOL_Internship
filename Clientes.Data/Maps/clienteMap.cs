using Clientes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clientes.Data.Maps;

public class clienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Nome)
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(x => x.DataNascimento)
            .IsRequired();
        
        builder.Property(x => x.DataCadastro)
            .IsRequired();
        
        builder.Property(x => x.DocIdentificacao)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasMany(x => x.Alteracao)
            .WithOne(x => x.Cliente)
            .HasForeignKey(x => x.ClienteId);
    }
}