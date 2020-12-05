using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.DAL
{
    public class CarroDAO
    {
        private readonly Context _context;

        public CarroDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Carro c)
        {
            if (BuscarCarroPorPlaca(c.Placa) == null)
            {
                _context.Carros.Add(c);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Alterar(Carro c)
        {
            if (BuscarPorId(c.Id) != null)
            {
                var local = _context.Set<Carro>().Local.FirstOrDefault(entry => entry.Id.Equals(c.Id));

                // check if local is not null 
                if (local != null)
                {
                    // detach
                    _context.Entry(local).State = EntityState.Detached;
                }
                // set Modified flag in your entry
                _context.Entry(c).State = EntityState.Modified;

                // save 
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Remover(Carro c)
        {
            _context.Carros.Remove(c);
            _context.SaveChanges();
        }



        public Carro BuscarCarroPorPlaca(string placa)
        {
            return _context.Carros.Include(x => x.Cliente).FirstOrDefault(c => c.Placa.Equals(placa.ToUpper()));
        }

        public int ContarCarrosProprietario(int id)
        {
            return _context.Carros.Include(x => x.Cliente).Where(c => c.Cliente.Id == id).Count(); ;
        }

        public Carro BuscarPorId(int id) => _context.Carros.Include(x => x.Cliente).Where(c => c.Id == id).FirstOrDefault();

        public List<Carro> ListarCarroIdProprietarioASC(int id) => _context.Carros.Where(c => c.ClienteId == id).ToList();

        public List<Carro> Listar() => _context.Carros.Include(x => x.Cliente).ToList();


    }
}
