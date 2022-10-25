using System.Linq.Expressions;
using System.Text.Json;
using Clientes.Domain;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Data
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly ClientesContext _context;

        public ClientesRepository(ClientesContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<Cliente> Update(Guid Id, Cliente cliente)
        {
            try
            {
                var registro = await _context.Clientes.FindAsync(Id);

                var json = JsonSerializer.Serialize(registro);

                var alteracao = new ClientesAlteracao()
                {
                    ClienteId = registro.Id,
                    DataAlteracao = DateTime.Now,
                    EstadoPreAlteracao = json
                };

                registro.Alteracao.Add(alteracao);
                
                registro.Nome = cliente.Nome;
                registro.DataNascimento = cliente.DataNascimento;
                registro.DocIdentificacao = cliente.DocIdentificacao;
                
                await _context.SaveChangesAsync();
                return registro;
            }
            catch
            {
                return null;
            }
            
        }
        

        public async Task<Cliente> GetById(Guid Id)
        {
            return await _context.Clientes.FindAsync(Id); 
        }
        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var registro = await _context.Clientes.FindAsync(id);
                _context.Clientes.Remove(registro);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> Get(Expression<Func<Cliente, bool>> predicate)
        { 
            return await _context.Clientes.Where(predicate).ToArrayAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

