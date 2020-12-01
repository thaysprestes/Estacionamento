using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    public class EstacionamentoController : Controller
    {

        private readonly CarroDAO _carroDAO;
      
        public EstacionamentoController(CarroDAO carroDAO)
        {
            _carroDAO = carroDAO;
        }



        public IActionResult Index()
        {
            ViewBag.Title = "Estacionamento JRT";
            return View(_carroDAO.Listar());
        }

        public IActionResult Configurar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Configurar(int vagas, float diaria, float horista)
        {
            return View();
        }
    }
}
