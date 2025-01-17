﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using atividade2.Models;

namespace atividade2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Cadastro(ItemPedido novoItem)
        {
            Dados.PedidoAtual.AdicionaPedido(novoItem);
            return View();
        }
         public IActionResult Cadastro()
        {            
            return View();
        }
         public IActionResult Listagem()
        {            
            List<ItemPedido> pedido = Dados.PedidoAtual.ListaPedido();
            return View(pedido);
        }

        public IActionResult Sobre()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
