using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    [Table("Movimentacao")]
    public class Movimentacao : BaseModel
    {
        public DateTime Entrada { get; set; }

        public DateTime Saida { get; set; }

        public Carro Carro { get; set; }

        public Vaga Vaga { get; set; }

        public double Total { get; set; }

        public Movimentacao()
        {
            Entrada = DateTime.Now;
        }
    }
}
