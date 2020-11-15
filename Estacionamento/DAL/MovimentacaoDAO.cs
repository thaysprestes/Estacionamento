using Estacionamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.DAL
{
    public class MovimentacaoDAO
    {

        private readonly Context _context;

        public MovimentacaoDAO(Context context)
        {
            _context = context;
        }


    }
}
