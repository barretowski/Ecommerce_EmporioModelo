using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.DAL
{
    public class CidadeDAL
    {

        public (int, string) Gravar(Cidade cidade)
        {
            int linhasAfetadas = 0;
            string msg = "";
            try
            {
                string sql = "insert into cidade (nome, uf) values (@nome, @uf)";
                Dictionary<string, object> ps = new Dictionary<string, object>();
                ps.Add("@nome", cidade.Nome);
                ps.Add("@uf", cidade.Uf);

                MySQLPersistence bd = new MySQLPersistence();
                /*bd.LimparParametros();
                bd.AdicionarParametro("@nome", cidade.Nome);
                bd.AdicionarParametro("@uf", cidade.Uf);*/

                bd.AbrirConexao();
                linhasAfetadas = bd.ExecutarNonQuery(sql, ps);
                bd.FecharConexao();
            }
            catch
            {
                msg = "Não foi possível salvar. Tente novamente.";
            }
            return (linhasAfetadas, msg);
        }

        public Cidade Obter(Cidade cidade,int id)
        {
            MySQLPersistence bd = new MySQLPersistence();
            string select = $@"select * from cidade where id = {id}";
            bd.AbrirConexao();
            DataTable dt = bd.ExecutarSelect(select);

            if( dt.Rows.Count >0 )
            {
                cidade.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                cidade.Nome = dt.Rows[0]["Nome"].ToString();
                cidade.Uf = dt.Rows[0]["Uf"].ToString();
            }

            bd.FecharConexao();

            return cidade;
        }
    }
}
