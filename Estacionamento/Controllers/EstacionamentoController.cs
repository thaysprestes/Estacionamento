using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.DAL;
using Estacionamento.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    public class EstacionamentoController : Controller
    {
        private readonly CarroDAO _carroDAO;
        private readonly EstacionamentoDAO _estacionamentoDAO;

        public EstacionamentoController(CarroDAO carroDAO, EstacionamentoDAO estacionamentoDAO)
        {
            _carroDAO = carroDAO;
            _estacionamentoDAO = estacionamentoDAO;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Estacionamento JRT";
            return View(_carroDAO.Listar());
        }

        [Authorize]
        public IActionResult Configurar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Configurar(Estacionamentos estacionamento)
        {
            if (ModelState.IsValid)
            {
                _estacionamentoDAO.CadastrarVagas(estacionamento.Vagas);
                if (_estacionamentoDAO.Configurar(estacionamento))
                {
                    return RedirectToAction("Index", "Estacionamento");
                }
                ModelState.AddModelError("", "Não foi possível configurar o estacionamento");
            }
            return View();
        }
    }
}
