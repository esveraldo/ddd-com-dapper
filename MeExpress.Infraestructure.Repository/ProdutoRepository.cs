using ExemploDDD.Repository.Connection;
using MeExpress.Domain.Interfaces;
using MeExpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Infraestructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public List<Produto> ObterList()
        {
            return DbHelper.Query<Produto>("ProdutoObterList", null);
        }
    }
}
