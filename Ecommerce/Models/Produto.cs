using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Produto
    {
        int _id;
        string _nome;
        int _quantidade;
        ProdutoTipo _tipo;
        decimal _precoVenda;

        public Produto()
        {
            _id = 0;
            _nome = "";
            _quantidade = 0;
            _precoVenda = 0;
        }
    }
}
