using Clientes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clientes.Data.Maps
{
    public class clientesAlteracaoMap : IEntityTypeConfiguration<ClientesAlteracao>
    {
        public void Configure(EntityTypeBuilder<ClientesAlteracao> builder)
        {
            builder.HasKey(x => x.Id);
        
            builder.Property(x => x.EstadoPreAlteracao)
                .IsRequired();
            
            builder.Property(x => x.DataAlteracao)
                .IsRequired();
            
            builder.Property(x => x.ClienteId) 
                .IsRequired();
        }
    }
    
}
