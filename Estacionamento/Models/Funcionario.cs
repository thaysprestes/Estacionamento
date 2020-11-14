using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    [Table("Funcionarios")]
    public class Funcionario : BaseModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Funcao { get; set; }
    }
}
