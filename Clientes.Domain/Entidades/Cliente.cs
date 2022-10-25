namespace Clientes.Domain
{
    public class Cliente
    {
        protected Cliente() { }
        
        public Cliente(Guid id, string nome, string documento, DateTime dataNascimento)
        {
            Id = id;
            DataCadastro = DateTime.Now;
            Nome = nome;
            DataNascimento = dataNascimento;
            DocIdentificacao = documento;
        }
        public Cliente(string nome, string documento, DateTime dataNascimento) 
        {
            this.Id = Guid.NewGuid();
            this.DataCadastro = DateTime.Now;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.DocIdentificacao = documento;
        }

        public Guid Id { get; set; }
        
        public string Nome { get; set; }
        
        public DateTime DataNascimento { get; set; }
        
        public DateTime DataCadastro { get; }
        
        public string DocIdentificacao { get; set; }

        public virtual ICollection<ClientesAlteracao>? Alteracao { get; set; } = new List<ClientesAlteracao>();
        
        public ClientesAlteracao ObterUltimaAlteracao()
        {
            return Alteracao.OrderByDescending(clientealteracao => clientealteracao.DataAlteracao).FirstOrDefault();
        }
    }
    
}