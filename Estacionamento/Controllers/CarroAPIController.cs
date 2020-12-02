using Estacionamento.DAL;
using Estacionamento.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Controllers
{
    [Route("api/Carro")]
    [ApiController]
    public class CarroAPIController : ControllerBase
    {
        private readonly CarroDAO _carroDAO;
        private readonly ClienteDAO _clienteDAO;

        public CarroAPIController(CarroDAO carroDAO, ClienteDAO clienteDAO)
        {
            _carroDAO = carroDAO;
            _clienteDAO = clienteDAO;
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<Carro> carros = _carroDAO.Listar();

            if (carros.Count > 0)
            {
                //foreach (var item in carros)
                //{
                //    item.Cliente = _clienteDAO.BuscarPorId(item.ClienteId);
                //}
                return Ok(carros);
            }

            return BadRequest(new { msg = "Não deu boa" });
        }

        [HttpGet]
        [Route("Buscar/{placa}")]
        public IActionResult Buscar(string placa)
        {
            Carro carro = _carroDAO.BuscarCarroPorPlaca(placa);

            if (carro != null)
            {
                //carro.Cliente = _clienteDAO.BuscarPorId(carro.ClienteId);
                return Ok(carro);
            }

            return NotFound(new { msg = "Não deu boa" });
        }
    }
}
