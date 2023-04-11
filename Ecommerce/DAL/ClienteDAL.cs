using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.DAL
{
    public class ClienteDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();
        public (Models.Cliente, string) Login(Models.Cliente cli,string Email, string Senha)
        {
            cli = null;
            string msg = "";
            try
            {

                string select = $"select * from cliente where email = '{Email}' and senha = '{Senha}'";
                _bd.AbrirConexao();
                DataTable dt = _bd.ExecutarSelect(select);

                if (dt.Rows.Count > 0)
                {
                    cli = new Cliente();
                    cli.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                    cli.Email = dt.Rows[0]["email"].ToString();
                    cli.Senha = dt.Rows[0]["senha"].ToString();
                    cli.Cpf = dt.Rows[0]["cpf"].ToString();
                }

                _bd.FecharConexao();
                
            }
            catch
            {
                msg = "Não foi possivel encontrar o login no banco, tente novamente";
            }
                return (cli,msg);
        }


    }
}
