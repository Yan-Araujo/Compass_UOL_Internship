namespace Clientes.Application.OutPutDTO;

public class GetAllOutputDTO
{
    public GetAllOutputDTO(List<ClienteOutputDTO> cliente)
    {
        Cliente = cliente;
    }
    public List<ClienteOutputDTO> Cliente { get; set; }
}