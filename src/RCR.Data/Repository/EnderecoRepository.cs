using RCR.Business.Interfaces;
using RCR.Business.Models;
using RCR.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace RCR.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext dbContext) : base(dbContext) { }

        public async Task<Endereco?> ObterEnderecoPorFornecedor(Guid fornecedorId) => await _dbContext.Enderecos.AsNoTracking()
            .FirstOrDefaultAsync(x => x.FornecedorId == fornecedorId);
    }
}
