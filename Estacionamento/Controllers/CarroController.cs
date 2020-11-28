using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.DAL;
using Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Estacionamento.Controllers
{
    public class CarroController : Controller
    {
        private readonly CarroDAO _carroDAO;
        private readonly ClienteDAO _clienteDAO;

        public CarroController(CarroDAO carroDAO, ClienteDAO clienteDAO)
        {
            _carroDAO = carroDAO;
            _clienteDAO = clienteDAO;
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Clientes = new SelectList(_clienteDAO.Listar(), "Id", "Nome");
            ViewBag.Title = "Cadastro Carro";
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Carro carro)
        {
           
            if (ModelState.IsValid)
            {
                carro.Cliente = _clienteDAO.BuscarPorId(carro.ClienteId);
                if (_carroDAO.Cadastrar(carro))
                {
                    return RedirectToAction("Index", "Estacionamento");
                }
                ModelState.AddModelError("", "Não foi possível cadastrar pois já existe um carro com essa placa");
               
            }
            ViewBag.Clientes = new SelectList(_clienteDAO.Listar(), "Id", "Nome");
            ViewBag.Title = "Cadastro Carro";
            return View(carro);
        }

    }
}
