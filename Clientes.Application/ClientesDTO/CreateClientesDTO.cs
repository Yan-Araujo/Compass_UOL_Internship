namespace Clientes.Application;

public class CreateClientesDTO
{
    public string Nome { get; set; }
    public Guid id { get; set; }
    public DateTime dataNascimento { get; set; }
    public DateTime dataCadastro { get; set; }
    public string docIdentificacao { get; set; }
}