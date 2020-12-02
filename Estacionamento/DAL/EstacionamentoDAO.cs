using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;
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

        public bool Configurar(Estacionamentos e)
        {
            Estacionamentos estacionamento = Buscar();
   
            if (estacionamento == null)
            {
                estacionamento = e;
                _context.Estacionamento.Add(estacionamento);
                _context.SaveChanges();
                return true;
            }
            else if (estacionamento != null)
            {
                estacionamento.Vagas = e.Vagas;
                estacionamento.Diaria = e.Diaria;
                estacionamento.Horista = e.Horista;
                _context.Estacionamento.Update(estacionamento);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public  bool LimparVagas()
        {
            List<Vaga> vagas = _context.Vagas.Where(v => v.Status == StatusVaga.Ocupado || v.Status == StatusVaga.Reservado).ToList();


            if (vagas.Count == 0)
            {
                _context.Database.ExecuteSqlRaw("ALTER TABLE Movimentacao NOCHECK CONSTRAINT FK_Movimentacao_Vagas_VagaId");
                _context.Vagas.RemoveRange(_context.Vagas);
                _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT(Vagas, RESEED, 0)");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CadastrarVagas(int v)
        {
            int i = 0;
            while (i < v)
            {
                Vaga vaga = new Vaga();
                _context.Vagas.Add(vaga);
                _context.SaveChanges();
                i++;
            }
            return true;
        }

        public Estacionamentos Buscar() => _context.Estacionamento.FirstOrDefault(x => x.Id == 1);

        public List<Estacionamentos> Listar() => _context.Estacionamento.ToList();

    }
}
