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
        public IActionResult Estacionar(string placa, string id)
        {
            Carro carro = _carroDAO.BuscarCarroPorPlaca(placa);
            if (_movimentacaoDAO.Estacionar(carro, id)){
                return RedirectToAction("Index", "Estacionamento");
            }
            ModelState.AddModelError("", "Placa inválida!");
            return View();
        }

        [HttpPost]
        public IActionResult Retirar(string placa)
        {
            Carro carro = _carroDAO.BuscarCarroPorPlaca(placa);
            Movimentacao movimentacao = _movimentacaoDAO.Retirar(carro);
            if (movimentacao != null)
            {
                ViewBag.Valor = movimentacao.Total.ToString("C2");
                ViewBag.Total = "Total:";
                return View();
            }
            ModelState.AddModelError("", "Placa inválida!");
            return View();
        }

        [HttpPost]
        public IActionResult Reservar(string placa)
        {
            Carro carro = _carroDAO.BuscarCarroPorPlaca(placa);
            if (_movimentacaoDAO.Reservar(carro))
            {
                return RedirectToAction("Index", "Estacionamento");
            }
            ModelState.AddModelError("", "Placa inválida!");
            return View();
        }

    }
}
