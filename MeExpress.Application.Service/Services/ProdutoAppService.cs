using MeExpress.Application.Service.Interfaces;
using MeExpress.Domain.Interfaces;
using MeExpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Application.Service.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private IProdutoRepository produtoRepository;
        public ProdutoAppService(IProdutoRepository produtoRepositoryInstance)
        {
            this.produtoRepository = produtoRepositoryInstance;
        }
        public List<Produto> ObterList()
        {
            return produtoRepository.ObterList();
        }
    }
}
