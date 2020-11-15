using Estacionamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.DAL
{
    public class EstacionamentoDAO
    {

        private readonly Context _context;

        public EstacionamentoDAO(Context context)
        {
            _context = context;
        }

    }
}
