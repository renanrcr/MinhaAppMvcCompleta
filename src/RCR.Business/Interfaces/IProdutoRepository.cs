using RCR.Business.Models;

namespace RCR.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IList<Produto>> ObterProdutosPorFornecedor(Guid id);
        
        Task<IList<Produto>> ObterProdutosFornecedores();
        
        Task<Produto?> ObterProdutoPorFornecedor(Guid id);
    }
}
