using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //importacação do IFormatProvider do mysql


namespace Ecommerce.DAL
{
    public class MySQLPersistence
    {
        string _strCon = "";
        MySqlConnection _conexao;
        MySqlCommand _comando;
        public MySQLPersistence()
        {
            _strCon = "Server = den1.mysql2.gear.host; Database = fipp2021; Uid = fipp2021; Pwd = 2212papo#";
            _conexao = new MySqlConnection(_strCon);
            _comando = _conexao.CreateCommand();
        }
        public void AbrirConexao()
        {
            if(_conexao.State != System.Data.ConnectionState.Open)
            _conexao.Open();
        }
        public void FecharConexao()
        {
            _conexao.Close();
        }

        /// <summary>
        /// _comando.CommandText = "select,. insert..., delete...";
        ///_comando.ExecuteNonQuery(); //insert, delete, update
        ///  _comando.ExecuteReader(); //select
        ///_comando.ExecuteScalar(); // funções de agregação - retorna um unico valor/coluna/linha
        /// </summary>

        public void AdicionarParametro(string nome, object valor)
        {
            _comando.Parameters.AddWithValue(nome, valor);
        }

        /// <summary>
        /// Executa Insert, delete ou uptdate
        /// </summary>

        public int ExecutarNonQuery(string instrucao, Dictionary<string, object> parametros = null) 
        {
            _comando.CommandText = instrucao;
            if(parametros != null)
            {
                foreach(var item in parametros)
                {
                    _comando.Parameters.AddWithValue(item.Key, item.Value);
                }
            }

            int linhasAfetadas = _comando.ExecuteNonQuery();
            return linhasAfetadas;
        }

        public DataTable ExecutarSelect(string select, Dictionary<string, object> parametros = null)
        {
            DataTable tabMemoria = new DataTable();
            _comando.CommandText = select;

            if (parametros != null)
            {
                foreach (var item in parametros)
                {
                    _comando.Parameters.AddWithValue(item.Key, item.Value);
                }
            }

            tabMemoria.Load(_comando.ExecuteReader());
            return tabMemoria;            
        }
    }
}
