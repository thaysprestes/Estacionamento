using Estacionamento.Models;
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
                _context.Carros.Update(c);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        //public bool Remover(Carro c)
        //{
        //    if (MovimentacaoDAO.ConsultarSeCarroEstacionado(c) == null)
        //    {
        //        _context.Carros.Remove(c);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    return false;

        //}

        public Carro BuscarCarroPorPlaca(string placa)
        {
            return _context.Carros.FirstOrDefault(c => c.Placa.Equals(placa.ToUpper()));
        }

        public int ContarCarrosProprietario(int id)
        {
            return _context.Carros.Where(c => c.Cliente.Id == id).Count(); ;
        }

        public Carro BuscarPorId(int id) => _context.Carros.Find(id);

        public List<Carro> ListarCarroIdProprietarioASC(int id) => _context.Carros.Where(c => c.ClienteId == id).ToList();


    }
}
