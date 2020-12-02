using Estacionamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.DAL
{
    public class FuncionarioDAO
    {

        private readonly Context _context;

        public FuncionarioDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Funcionario funcionario)
        {
           
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return true;
            
        }

        public Funcionario BuscarPorCpf(string cpf) => _context.Funcionarios.FirstOrDefault(x => x.CPF == cpf);

        public bool Remover(string cpf)
        {
            if(BuscarPorCpf(cpf) != null)
            {
                _context.Funcionarios.Remove(BuscarPorCpf(cpf));
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
