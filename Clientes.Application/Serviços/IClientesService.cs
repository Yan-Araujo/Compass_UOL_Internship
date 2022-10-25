using Clientes.Domain;
using System.Threading.Tasks;
using Clientes.Application.OutPutDTO;

namespace Clientes.Application;

public interface IClientesService : IDisposable
{
    Task<bool> Create(CreateClientesDTO clienteDTO);
    Task<GetAllOutputDTO> GetAll();
    Task<Cliente> Update(Guid Id, EditClientesDTO clienteDTO);
    Task<ClienteOutputDTO> GetById(Guid Id);
    Task Delete(string id);
    Task<ClienteByQueryDTO> ObterClienteQuery(string query);
    
    Task<ClientesAlteracao> ObterUltimaAlteracao(Guid id);
}

