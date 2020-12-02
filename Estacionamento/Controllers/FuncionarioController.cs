using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.DAL;
using Estacionamento.Models;
using Estacionamento.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    public class FuncionarioController : Controller
    {

        private readonly FuncionarioDAO _funcionarioDAO;

        public FuncionarioController(FuncionarioDAO funcionarioDAO)
        {
            _funcionarioDAO = funcionarioDAO;
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Title = "Cadastro Funcionário";
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                if (ValidarCpf.Validar(funcionario.CPF))
                {
                    if (_funcionarioDAO.Cadastrar(funcionario))
                    {
                        return RedirectToAction("Index", "Estacionamento");
                    }
                    ModelState.AddModelError("", "Cadastro NÃO efetuado! CPF já cadastrado!");
                } else
                {
                    ModelState.AddModelError("", "CPF Inválido!");
                }    
            }
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Remover()
        {
            ViewBag.Title = "Remover Funcionário";
            return View();
        }

        [HttpPost]
        public IActionResult Remover(string cpf)
        {
            if (ModelState.IsValid)
            {
                if (ValidarCpf.Validar(cpf))
                {
                    if (_funcionarioDAO.Remover(cpf))
                    {
                        return RedirectToAction("Index", "Estacionamento");
                    }
                    ModelState.AddModelError("", "Exclusão NÃO efetuado! CPF Inexistente!");
                } else
                {
                    ModelState.AddModelError("", "CPF Inválido!");
                }
            }
            return View();
            
        }
    }
}
