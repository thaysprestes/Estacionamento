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


    }
}
