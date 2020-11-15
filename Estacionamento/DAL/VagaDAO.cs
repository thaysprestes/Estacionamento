using Estacionamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.DAL
{
    public class VagaDAO
    {
        private readonly Context _context;


        public VagaDAO(Context context)
        {
            _context = context;
        }

    }
}
