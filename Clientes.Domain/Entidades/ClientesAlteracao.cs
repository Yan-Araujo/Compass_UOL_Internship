using System.ComponentModel.DataAnnotations;

namespace Clientes.Domain;

public class ClientesAlteracao
{
    public ClientesAlteracao() {}
    
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public DateTime DataAlteracao { get; set; }
    public string EstadoPreAlteracao { get; set; }
    public virtual Cliente Cliente { get; set; }
}