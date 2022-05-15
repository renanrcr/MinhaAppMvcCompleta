using RCR.Business.Models;

namespace RCR.Business.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor?> ObterFornecedorEndereco(Guid id);
        
        Task<Fornecedor?> ObterFornecedorProdutoEndereco(Guid id);
    }
}
