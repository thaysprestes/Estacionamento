using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;
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

        public bool Estacionar(Carro carro, string modalidade)
        {
            Vaga vaga = _context.Vagas.FirstOrDefault(v => v.Status == 0);

            if (vaga != null)
            {
                Movimentacao movimentacao = new Movimentacao();
                movimentacao.Carro = carro;
                vaga.Status = StatusVaga.Ocupado;
                movimentacao.Vaga = vaga;
                if (modalidade == "Diaria")
                {
                    movimentacao.Modalidade = Modalidade.Diaria;
                }
                else
                {
                    movimentacao.Modalidade = Modalidade.Horista;
                }
                _context.Movimentacao.Add(movimentacao);
                _context.Vagas.Update(vaga);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Movimentacao Retirar(Carro carro)
        {
            Estacionamentos estacionamento = _context.Estacionamento.FirstOrDefault(x => x.Id == 1);
            Movimentacao movimentacao = _context.Movimentacao.Include(x => x.Vaga).Where(m => m.Carro.Id == carro.Id && m.Total == 0).FirstOrDefault();
            Vaga vaga = movimentacao.Vaga;
            movimentacao.Saida = DateTime.Now;
            int status = (int)vaga.Status;

            if(status == 2)
            {
                movimentacao.Total = (estacionamento.Diaria * Math.Ceiling((movimentacao.Saida - movimentacao.Entrada).TotalDays)) * 0.9;
            }
            else if (movimentacao.Modalidade == Modalidade.Diaria)
            {
                movimentacao.Total = (estacionamento.Diaria * Math.Ceiling((movimentacao.Saida - movimentacao.Entrada).TotalDays));
            } else
            {
                movimentacao.Total = estacionamento.Horista * (movimentacao.Saida - movimentacao.Entrada).TotalHours;
            }

            vaga.Status = StatusVaga.Livre;
            _context.Movimentacao.Update(movimentacao);
            _context.Vagas.Update(vaga);
            _context.SaveChanges();

            return movimentacao;
        }

        public bool Reservar(Carro carro)
        {
            Vaga vaga = _context.Vagas.FirstOrDefault(v => v.Status == 0);

            if (vaga != null)
            {
                Movimentacao movimentacao = new Movimentacao();
                movimentacao.Carro = carro;
                vaga.Status = StatusVaga.Reservado;
                movimentacao.Vaga = vaga;
                movimentacao.Modalidade = Modalidade.Diaria;
                _context.Movimentacao.Add(movimentacao);
                _context.Vagas.Update(vaga);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Movimentacao ConsultarSeCarroEstacionado(Carro carro) => _context.Movimentacao.Where(m => m.Carro.Id == carro.Id && m.Total == 0).FirstOrDefault();

        public List<Movimentacao> ListarCarrosEstacionados() => _context.Movimentacao.Include(x => x.Carro).Where(m => m.Total == 0).ToList();

        //public  List<Movimentacao> ListarCarrosEstacionados(int id) => _context.Movimentacoes.Where(m => m.Carro.Id == id).ToList();
        public List<Movimentacao> Listar() => _context.Movimentacao.ToList();

        public double SomarFaturamento(DateTime dtInicial, DateTime dtFinal) => _context.Movimentacao.Where(m => m.Saida >= dtInicial && m.Saida <= dtFinal).Sum(x => x.Total);

        //talvez tenha que fazer um join? ver exemplo produto/categoria no projeto Vendas WEB
        public List<Movimentacao> BuscarHistoricoDeCarroEstacionado(int id) => _context.Movimentacao.Where(m => m.Carro.Id == id && m.Total != 0).ToList();

        // Metodo criado para não deixar excluir carro que tem histórico de faturamento e não estourar exception de violacao de FK na Movimentacao
        public Movimentacao ConsultarSeCarroTemHistorico(Carro carro) => _context.Movimentacao.Where(m => m.Carro.Id == carro.Id && m.Total > 0).FirstOrDefault(); 

    }
}
