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






    }
}
