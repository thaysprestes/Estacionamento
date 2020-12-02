using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.DAL;
using Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly CarroDAO _carroDAO;
        private readonly MovimentacaoDAO _movimentacaoDAO;

        public MovimentacaoController(CarroDAO carroDAO, MovimentacaoDAO movimentacaoDAO)
        {
            _carroDAO = carroDAO;
            _movimentacaoDAO = movimentacaoDAO;
        }

        public IActionResult Reservar()
        {
            return View();
        }

        public IActionResult Estacionar()
        {
            return View();
        }

        public IActionResult Retirar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reservar(string placa, string id)
        {
            Carro carro = _carroDAO.BuscarCarroPorPlaca(placa);
            if (_movimentacaoDAO.Estacionar(carro, id)){
                return RedirectToAction("Index", "Estacionamento");
            }
            ModelState.AddModelError("", "Placa inválida!");
            return View();
        }

    }
}
