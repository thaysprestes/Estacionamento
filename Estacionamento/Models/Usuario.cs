using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class Usuario : IdentityUser
    {
        public Usuario()
        {
            CriadoEm = DateTime.Now;
        }
        public DateTime CriadoEm { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Telefone { get; set; }

        public List<Carro> Carros { get; set; }
    }
}
