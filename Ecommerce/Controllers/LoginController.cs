using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Services;
namespace Ecommerce.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Logar([FromBody]System.Text.Json.JsonElement dados) 
        {
            string email = dados.GetProperty("email").GetString();
            string senha = dados.GetProperty("senha").GetString();

            bool sucesso = false;
            string msg = "";

            ClienteService serv = new ClienteService();
            Models.Cliente cli = new Models.Cliente();
            (bool, string) res = serv.ValidarLogin(cli, email, senha);

       return Json(new
            {
                sucesso = res.Item1,
                msg = res.Item2
            });
        }

        [HttpGet]
        public IActionResult Obter(int id)
        {
            return Json(new
            {
                id,
                idX = id
            });
        }
        [HttpGet]
        public IActionResult Consultar(string nome)
        {
            return Json(new
            {
                nome,
                nomeX = nome
            });
        }

        [HttpPut]
        public IActionResult Alterar(int id, [FromBody] ViewModel.Usuario usuario)
        {
            return Json(new
            {
                id,
                usuario
            });
        }
        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            return Json(new
            {
                id,
                idx = id
            });
        }
    }
    //OBJ ANONIMIO: C#
    //OBJ LITERAL: JS
}

