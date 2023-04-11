using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Cliente
    {
        int _id;
        string _nome;
        string _cpf;
        string _email;
        string _senha;
        Cidade _cidade;
        List<ClienteContato> _contatos;

        public Cliente()
        {
            Id = 0;
            Nome = "";
            Cpf = "";
            Email = "";
            Senha = "";
            Cidade = new Cidade();
            Contatos = new List<ClienteContato>();
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public string Email { get => _email; set => _email = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public Cidade Cidade { get => _cidade; set => _cidade = value; }
        public List<ClienteContato> Contatos { get => _contatos; set => _contatos = value; }

        public (bool, string) Validar()
        {
            string msg = "";
            if (Email.Trim().Length > 45)
            {
                msg = "O Email atingiu o limite máximo de caracteres. Limite: 45";
            }
            if (Senha.Trim().Length > 10)
            {
                msg = "A Senha atingiu o limite máximo de caracteres. Limite: 10";
            }

            return (msg == "",msg);
        }
    }
}
