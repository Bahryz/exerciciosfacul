using API.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Data
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDataContext _context;

        public ProdutoRepository(AppDataContext context)
        {
            _context = context;
        }

        public void Cadastrar(Produto produto)
        {
            // Lógica para adicionar o produto ao banco de dados
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public List<Produto> Listar()
        {
            // Lógica para listar todos os produtos
            return _context.Produtos.ToList();
        }
    }
}
