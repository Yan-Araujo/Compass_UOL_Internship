using Clientes.Application;
using Clientes.Data;
using Clientes.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ClientesController : ControllerBase
    {
        private ClienteContext _context;
        private object _service;

        public ClientesController(ClienteContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarClientes([FromBody]CreateClientesDTO clienteDTO)
        {

            await _service.CriarClienteAsync(clienteDTO);
            return Ok(clienteDTO);
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarClientes()
        {
            return Ok(await _service.ObterClienteAsync());
        } 

        [HttpGet] //id ou query
        public IActionResult ObterClienteQuery([FromBody]GetClientesDTO clienteDTO)
        {
            return Ok();
           
        }

        [HttpPut("{id}")] 

        public async Task<IActionResult> AtualizarCliente(Guid Id, [FromBody] EditClientesDTO clientesDTO)
        {
            var cliente = await _service.ClienteId(Id);
            if (cliente != null)
            {
                await _service.AtualizarClienteAsync(cliente, clientesDTO);
                return Ok(cliente);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarClientes([FromBody] Guid Id)
        {
            var cliente = await _service.ClienteId(Id);
            if (cliente != null)
            {
                await _service.DeletarClienteAsync(cliente);
                return NoContent();
            }
            return NotFound();

        }
    }



}
