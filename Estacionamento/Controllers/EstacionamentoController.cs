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
            Estacionamentos estacionamento = _estacionamentoDAO.Buscar();
            if (estacionamento != null)
            {
                return View(estacionamento);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Configurar(Estacionamentos estacionamento)
        {
            if (ModelState.IsValid)
            {
                if (_estacionamentoDAO.LimparVagas())
                {
                    if (_estacionamentoDAO.Configurar(estacionamento))
                    {
                        _estacionamentoDAO.CadastrarVagas(estacionamento.Vagas);
                        return RedirectToAction("Index", "Estacionamento");
                    }
                    ModelState.AddModelError("", "Não foi possível configurar o estacionamento");
                }
            }
            return View();
        }
    }
}
