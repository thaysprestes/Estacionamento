using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    [Table("Estacionamento")]
    public class Estacionamento : BaseModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Vagas { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public double Diaria { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public double Horista { get; set; }
    }
}
