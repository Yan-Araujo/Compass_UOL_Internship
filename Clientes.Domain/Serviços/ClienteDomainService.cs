namespace Clientes.Domain;

public sealed class ClienteDomainService : IClienteDomainService
{
    private readonly IClientesRepository _repository;
    
    public ClienteDomainService(IClientesRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Create(Cliente cliente)
    {
        var resultado = await _repository.Create(cliente);
        return resultado;
    }

    public async Task<bool> Delete(Guid id)
    {
        var cliente = await _repository.GetById(id);
        bool validoParaDeletar = (DateTime.Now.Year - cliente.DataCadastro.Year) >= 1;

        if (validoParaDeletar)
        {
            bool deletar = await _repository.Delete(id); 
            return deletar;
        }

        return validoParaDeletar;
    }

    public async Task<Cliente> Edit(Guid Id, Cliente cliente)
    {
            bool clienteValido = false;
            if (!clienteValido)
            {
                var atualizar = await _repository.Update(Id, cliente);
                return atualizar;
            }
            return null;
    }

    public async Task<ClientesAlteracao> ObterUltimaAlteracao(Guid id)
    {
        var cliente = await _repository.GetById(id);
        var ultimaAlteracao = cliente.ObterUltimaAlteracao();
        return ultimaAlteracao;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}