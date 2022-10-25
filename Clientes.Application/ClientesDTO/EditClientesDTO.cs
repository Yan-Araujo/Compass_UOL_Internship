namespace Clientes.Application;

public class EditClientesDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public DateTime dataNascimento { get; set; }
    public DateTime dataAlteracao { get; set; }
    public string docIdentificacao { get; set; }
    
}