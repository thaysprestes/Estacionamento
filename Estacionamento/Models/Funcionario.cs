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
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Senha { get; set; }

        [Display(Name = "Confirmação da senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [NotMapped]
        [Compare("Senha", ErrorMessage = "Campos não coincidem")]
        public string ConfirmacaoSenha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Funcao { get; set; }
    }
}
