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
        private readonly MovimentacaoDAO _movimentacaoDAO;

        public CarroController(CarroDAO carroDAO, ClienteDAO clienteDAO, MovimentacaoDAO movimentacaoDAO)
        {
            _carroDAO = carroDAO;
            _clienteDAO = clienteDAO;
            _movimentacaoDAO = movimentacaoDAO;
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
                } else
                {
                    ModelState.AddModelError("", "Não foi possível cadastrar pois já existe um carro com essa placa");
                }          
            }
            ViewBag.Clientes = new SelectList(_clienteDAO.Listar(), "Id", "Nome");
            ViewBag.Title = "Cadastro Carro";
            return View(carro);
        }


        public IActionResult Editar()
        {
            return View();
        }

     

        public IActionResult Remover()
        {     
            return View();
        }


        [HttpPost]
        public IActionResult Remover(string placa)
        {
            if (ModelState.IsValid)
            {
                Carro carro = _carroDAO.BuscarCarroPorPlaca(placa);
                if (carro != null)
                {
                    if (_movimentacaoDAO.ConsultarSeCarroEstacionado(carro) == null)
                    {
                        if (_movimentacaoDAO.ConsultarSeCarroTemHistorico(carro) == null)
                        {
                            _carroDAO.Remover(carro);
                            return RedirectToAction("Index", "Estacionamento");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Não foi possível Excluir. Placa com Histórico de estacionamento");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Não foi possível Excluir. Placa Estacionada");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Não foi possível Excluir. Placa Inexistente");
                }
            }
            return View();
        }





        public IActionResult Listar()
        {
            return View(_carroDAO.Listar());
        }


        








    }
}
