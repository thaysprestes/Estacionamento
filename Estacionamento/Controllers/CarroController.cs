using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    public class CarroController : Controller
    {

        public IActionResult Cadastrar()
        {
            ViewBag.Title = "Cadastro Carro";
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Carro Carro)
        {
            if (ModelState.IsValid)
            {
                //incluir cadastro no DAO
                return RedirectToAction("Index", "Estacionamento");
            }
            ModelState.AddModelError("", "Cadastro não realizado");
            return View();
        }

    }
}
