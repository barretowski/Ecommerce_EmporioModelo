using Ecommerce.DAL;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class CadastroProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Gravar([FromBody]System.Text.Json.JsonElement dados)
        {
            return Json(new
            {
                msg = "Ok"
            });
        }
        [HttpGet]
        public IActionResult ObterCategorias()
        {
            System.Threading.Thread.Sleep(3000);
            CadastroProdutoDAL cd = new CadastroProdutoDAL();
            return Json(cd.CarregarCategoriasBD());
        }
    }
}
