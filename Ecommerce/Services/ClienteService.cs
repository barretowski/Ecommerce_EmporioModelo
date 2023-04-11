using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class ClienteService
    {
        DAL.ClienteDAL _clienteDAL = new DAL.ClienteDAL();
        public (bool,string) ValidarLogin(Models.Cliente cliente, string email, string senha)
        {
            bool sucess = false;
            string msg = "";

            sucess = false;
            
            if(email.Trim().Length >45)
            {
                msg = "O Email atingiu o limite máximo de caracteres. Limite: 45";
            }
            if(senha.Trim().Length >10)
            {
                msg = "A Senha atingiu o limite máximo de caracteres. Limite: 10";
            }


            if(msg == "")
            {
                (cliente, msg) = _clienteDAL.Login(cliente, email, senha);

                if (cliente != null)
                {
                    msg = $"{cliente.Email} logado com sucesso";
                    sucess = true;
                }
                else
                {
                    msg = "Login ou senha incorretos";
                    sucess = false;
                }
            }

            return (sucess, msg);
        }
    }
}
