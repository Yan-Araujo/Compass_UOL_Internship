using Clientes.Data.Maps;
using Microsoft.EntityFrameworkCore;
using Clientes.Domain;
using Pomelo.EntityFrameworkCore.MySql;


namespace Clientes.Data;


    public class ClientesContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClientesAlteracao> newClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql(@"Server=localhost;Port=55000;Database=clientesdb;Uid=root;Pwd=mysqlpw;", new MySqlServerVersion(new Version(8, 0, 11)));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new clienteMap());
            modelBuilder.ApplyConfiguration(new clientesAlteracaoMap());
        }
    }
