using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Cidade
    {
        int _id;
        string _nome;
        string _uf;

         

        public Cidade()
        {
            _id = 0;
            _nome = "";
            _uf = "";

        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Uf { get => _uf; set => _uf = value; }

       public (bool,string) Validar()
        {
            string msg = "";
            if (Nome.Trim().Length > 45)
            {
                msg = "Nome muito grande. Limite 45 caracteres.";
            }
            else if (Uf.Trim().Length >2)
            {
                msg = "UF muito grande. Limite 2 caracteres.";
            }

            return (msg == "", msg);
        }
    }
}
