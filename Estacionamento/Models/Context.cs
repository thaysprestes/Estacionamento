using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class Context : IdentityDbContext<Usuario>
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Carro> Carros { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Estacionamentos> Estacionamento { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Movimentacao> Movimentacao { get; set; }

        public DbSet<Vaga> Vagas { get; set; }

        public DbSet<Funcionario> Usuarios { get; set; }

    }
}
