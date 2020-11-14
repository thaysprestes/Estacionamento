using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    public class ClienteController : Controller
    {
        //public IActionResult Index()
        //{
            
        //    return View();
        //}

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
                //incluir cadastro no DAO
                return RedirectToAction("Index", "Estacionamento");
            }
            ModelState.AddModelError("", "Cadastro não realizado");
            return View();
        }
    }
}
