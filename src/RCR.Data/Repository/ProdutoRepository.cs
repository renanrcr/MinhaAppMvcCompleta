using RCR.Business.Interfaces;
using RCR.Business.Models;
using Microsoft.EntityFrameworkCore;
using RCR.Data.Context;

namespace RCR.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext dbContext) : base(dbContext) { }

        public async Task<Produto?> ObterProdutoPorFornecedor(Guid id) => await _dbContext.Produtos.AsNoTracking().Include(x => x.Fornecedor)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IList<Produto>> ObterProdutosFornecedores() => await _dbContext.Produtos.AsNoTracking().Include(x => x.Fornecedor)
            .OrderBy(x => x.Nome).ToListAsync();

        public async Task<IList<Produto>> ObterProdutosPorFornecedor(Guid id) => await Buscar(x => x.FornecedorId == id);
    }
}
