﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    public class EstacionamentoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Estacionamento JRT";
            return View();
        }
    }
}
