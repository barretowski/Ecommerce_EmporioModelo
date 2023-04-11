using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class ProdutoTipo
    {
        int _id;
        string _nome;

        public ProdutoTipo()
        {

        }
        public ProdutoTipo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }

        public bool Gravar(string nome)
        {
            bool ok = true;

            return ok;
        }
    }
}
