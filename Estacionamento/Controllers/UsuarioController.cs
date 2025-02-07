﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace VendasWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioController(Context context, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Usuario
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionarios.ToListAsync());
        }

        // GET: Usuario/Create
        public IActionResult Cadastrar()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("Email,Senha,Id,CriadoEm,ConfirmacaoSenha,Nome,CPF,Funcao")] Funcionario usuarioView)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario
                {
                    UserName = usuarioView.Email,
                    Email = usuarioView.Email,
                    CPF = usuarioView.CPF,
                    Nome = usuarioView.Nome,
                    Funcao = usuarioView.Funcao
                };
                var resultado = await _userManager.CreateAsync(usuario, usuarioView.Senha);

                if (resultado.Succeeded)
                {
                    _context.Funcionarios.Add(usuarioView);
                    _context.Add(usuarioView);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Estacionamento");
                }
                AdicionarErros(resultado);
            }
            return View(usuarioView);
        }

        public void AdicionarErros(IdentityResult resultado)
        {
            foreach (IdentityError error in resultado.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email, Senha")] Funcionario usuario)
        {
                var resultado = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Senha, false, false);
                string name = _signInManager.Context.User.Identity.Name;
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Estacionamento");
                }
                ModelState.AddModelError("", "Login ou senha inválidos");
                return View(usuario);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Estacionamento");
        }
    }
}
