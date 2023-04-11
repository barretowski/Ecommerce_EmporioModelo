using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class CadastroProdutoDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();

        public IEnumerable<Models.Categoria> CarregarCategoriasBD()
        {

            List<Models.Categoria> categoria = new List<Categoria>();

                
            string select = $@"select * from categoria";
            //_bd.LimparPametro();
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(select);

            foreach(DataRow row in dt.Rows)
            {
                var cat = new Models.Categoria()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nome = row["nome"].ToString()
                };
                categoria.Add(cat);
            }
               
            _bd.FecharConexao();


            return categoria.AsEnumerable();
        }
    }
}
