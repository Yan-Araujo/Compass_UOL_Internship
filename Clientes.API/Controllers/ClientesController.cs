using Microsoft.AspNetCore.Mvc;
using Clientes.Application;
using Clientes.Domain;

namespace Clientes.API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ClienteController : ControllerBase
    {

        private readonly IClientesService _service;

        public ClienteController(IClientesService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCliente([FromBody] CreateClientesDTO clienteDTO)
        {
            try
            {
                await _service.Create(clienteDTO);
                return Ok(clienteDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> ObterClienteQuery([FromQuery] GetClientesDTO clienteDTO)
        {
            if (!string.IsNullOrEmpty(clienteDTO.id))
            {
                var guidId = Guid.Parse(clienteDTO.id);
                var clienteId = await _service.GetById(guidId);
                if (clienteId == null)
                    return NotFound();

                return Ok(clienteId);
            }
            if (!string.IsNullOrEmpty(clienteDTO.query))
            {
                var clienteQuery = await _service.ObterClienteQuery(clienteDTO.query);
                if (clienteQuery == null || clienteQuery.Cliente == null || clienteQuery.Cliente.Count == 0)
                    return NotFound();
                
                return Ok(clienteQuery);
            }
            var clienteAll = await _service.GetAll();
            if (clienteAll == null || clienteAll.Cliente == null || clienteAll.Cliente.Count == 0)
                return NotFound();
    
            return Ok(clienteAll);

        }

        [HttpPut("{Id}")]

        public async Task<IActionResult> AtualizarCliente(Guid Id, [FromBody] EditClientesDTO clienteDTO)
        {
            var cliente = await _service.GetById(Id);
            if (cliente != null)
            {
                await _service.Update(Id, clienteDTO);
                return Ok(clienteDTO);
            }
            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletarCliente(string Id)
        {
            var idParaGuid = Guid.Parse(Id);
            var cliente = await _service.GetById(idParaGuid);
            if (cliente != null)
            {
                await _service.Delete(Id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}