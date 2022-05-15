using RCR.Business.Interfaces;
using RCR.Business.Models;
using RCR.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace RCR.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext dbContext) : base(dbContext) { }

        public async Task<Fornecedor?> ObterFornecedorEndereco(Guid id) => await _dbContext.Fornecedores.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Fornecedor?> ObterFornecedorProdutoEndereco(Guid id) => await _dbContext.Fornecedores.AsNoTracking().Include(x => new { x.Produtos, x.Endereco })
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
