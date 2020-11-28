using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    [Table("Carros")]
    public class Carro : BaseModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Placa { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }

    }
}
