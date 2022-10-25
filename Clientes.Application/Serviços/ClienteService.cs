using Clientes.Application.OutPutDTO;
using Clientes.Domain;

namespace Clientes.Application
{
    public class ClienteService : IClientesService
    {
        private readonly IClientesRepository _repository;
        
        private readonly IClienteDomainService _service;

        public ClienteService(IClientesRepository repository, IClienteDomainService service)
        {
            _repository = repository;
            _service = service;
        }
        public async Task<bool> Create(CreateClientesDTO clienteDTO)
        {
            var cliente = new Cliente(nome: clienteDTO.Nome, documento: clienteDTO.docIdentificacao,
                dataNascimento: clienteDTO.dataNascimento);
            var resultado = await _service.Create(cliente);
            return resultado;
        }

        public async Task<GetAllOutputDTO> GetAll()
        {
            var resultado = await _repository.GetAll();
            var clienteDtos = MapToClienteOutputDTO(resultado);
            var outputDTO = new GetAllOutputDTO(clienteDtos);
            return outputDTO;
            throw new Exception();
        }

        public async Task<Cliente> Update(Guid Id, EditClientesDTO clienteDTO)
        {
            var cliente = new Cliente(id: clienteDTO.Id, nome: clienteDTO.Nome, documento: clienteDTO.docIdentificacao,
                dataNascimento: clienteDTO.dataNascimento);
            var result = await _service.Edit(Id, cliente);
            return result;
        }
        public async Task<ClienteOutputDTO> GetById(Guid Id)
        {
            var resultado = await _repository.GetById(Id);
            var dto = MapToDTO(resultado);
            return dto;
        }
        public async Task Delete(string id)
        {
            var idParaGuid = Guid.Parse(id);
            await _repository.Delete(idParaGuid);
        }

        public async Task<ClienteByQueryDTO> ObterClienteQuery(string query)
        {
            var result = await _repository.Get(cliente => cliente.Nome.ToLower()
                .Contains(query.ToLower()) || cliente.DocIdentificacao.ToLower().Contains(query.ToLower()));
            var clienteDTOs = MapToClienteOutputDTO(result);
            var outputDTO = new ClienteByQueryDTO(clienteDTOs);
            return outputDTO;
        }

        public async Task<ClientesAlteracao> ObterUltimaAlteracao(Guid id)
        {
            var resultado = await _repository.GetById(id);
            var ultimaAlteracao = resultado.ObterUltimaAlteracao();
            return ultimaAlteracao;
        }

        static ClienteOutputDTO MapToDTO(Cliente cliente)
        {
            var dto = new ClienteOutputDTO(id: cliente.Id, nome: cliente.Nome, dataNascimento: cliente.DataNascimento,
                documento: cliente.DocIdentificacao);
            return dto;
        }

        static List<ClienteOutputDTO> MapToClienteOutputDTO(IEnumerable<Cliente> clientes)
        {
            var clientesDtos = new List<ClienteOutputDTO>();
            foreach (var item in clientes)
            {
                var Dto = MapToDTO(item);
                clientesDtos.Add(Dto);
            }
            return clientesDtos;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}