namespace Clientes.Domain;

public interface IClienteDomainService
{
    Task<bool> Create(Cliente cliente);
    Task<bool> Delete(Guid id);
    Task<Cliente> Edit(Guid Id, Cliente cliente);
    Task<ClientesAlteracao> ObterUltimaAlteracao(Guid id);
    
}