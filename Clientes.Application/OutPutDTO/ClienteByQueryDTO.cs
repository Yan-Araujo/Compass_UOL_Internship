namespace Clientes.Application.OutPutDTO
{
    public class ClienteByQueryDTO
    {
        public ClienteByQueryDTO(List<ClienteOutputDTO> cliente)
        {
            Cliente = cliente;
        }
        public List<ClienteOutputDTO> Cliente { get; set; }
    }
}