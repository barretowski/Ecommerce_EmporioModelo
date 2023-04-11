using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
namespace Ecommerce.Services //regra de negocios
{
    public class CidadeService
    {
        DAL.CidadeDAL _cidadeDal = new DAL.CidadeDAL();
        public (bool,string) Gravar(Cidade cidade)
        {
            bool res = false;
            string msg = "";
            (res,msg) = cidade.Validar();

            if(res)
            {
                res = false;
                //regra
                int linhas;

                (linhas,msg) = _cidadeDal.Gravar(cidade);

                if(linhas>0)
                {
                    msg = $"{linhas} salvas com sucesso.";
                    res = true;
                }
            }
            return (res, msg);
        }
    }
}
