using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Carro> Carros { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Estacionamento> Estacionamento { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Movimentacao> Movimentacao { get; set; }

        public DbSet<Vaga> Vagas { get; set; }


    }
}
