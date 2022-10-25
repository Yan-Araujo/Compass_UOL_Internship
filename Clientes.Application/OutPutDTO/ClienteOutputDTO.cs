namespace Clientes.Application.OutPutDTO
{
    public class ClienteOutputDTO
    {
        public ClienteOutputDTO(Guid id, string nome, DateTime dataNascimento, string documento)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            DocIdentificacao = documento;
        }
        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string DocIdentificacao { get; set; }
    }
}