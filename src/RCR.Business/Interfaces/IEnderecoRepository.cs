using RCR.Business.Models;

namespace RCR.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco?> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
