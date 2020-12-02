using Estacionamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.DAL
{
    public class ClienteDAO
    {

        private readonly Context _context;

        public ClienteDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Cliente cliente)
        {
            if(BuscarPorCpf(cliente.CPF) == null)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Cliente BuscarPorCpf(string cpf) => _context.Clientes.FirstOrDefault(x => x.CPF == cpf);


        public bool Alterar(Cliente c)
        {
            if (BuscarPorId(c.Id) != null)
            {
                _context.Clientes.Update(c);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Cliente> Listar() => _context.Clientes.ToList(); // listar pela id
        public Cliente BuscarPorId(int id) => _context.Clientes.Find(id);
        public List<Cliente> ListarASC() => _context.Clientes.OrderBy(p => p.Nome).ToList(); // listar pelo nome ascendente
        public List<Cliente> ListarDESC() => _context.Clientes.OrderByDescending(p => p.Nome).ToList(); // listar pelo nome descendente


    }
}
