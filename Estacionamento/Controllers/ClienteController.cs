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
    public class ClienteController : Controller
    {

        private readonly ClienteDAO _clienteDAO;


        public ClienteController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }



        public IActionResult Cadastrar()
        {
            ViewBag.Title = "Cadastro Cliente";
            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (ValidarCpf.Validar(cliente.CPF))
                {
                    if (_clienteDAO.Cadastrar(cliente))
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
    }
}
