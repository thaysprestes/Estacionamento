using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public enum StatusVaga
    {
        Livre,
        Ocupado
    }

    [Table("Vagas")]
    public class Vaga : BaseModel
    {
        public StatusVaga Status { get; set; }
    }
}
