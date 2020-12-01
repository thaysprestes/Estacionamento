using Estacionamento.DAL;
using Estacionamento.Models;
using Estacionamento.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteAPIController : ControllerBase
    {
        private readonly ClienteDAO _clienteDAO;

        public ClienteAPIController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (ValidarCpf.Validar(cliente.CPF))
                {
                    if (_clienteDAO.Cadastrar(cliente))
                    {
                        return Created("", cliente);
                    }
                    return Conflict(new { msg = "não deu boa, cliente já cadastrado" });
                }
                return Conflict(new { msg = "não deu boa, cpf inválido" });
            }
            return BadRequest(ModelState);
        }
    }
}
