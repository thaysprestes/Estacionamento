﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Controllers
{
    public class VagaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
