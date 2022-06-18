using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RCR.App.ViewModels;
using RCR.Business.Interfaces;
using RCR.Business.Models;

namespace RCR.App.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
            IFornecedorRepository fornecedorRepository,
            IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutosViewModel>>(await _produtoRepository.ObterProdutosFornecedores()));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            var produtosViewModel = await ObterProduto(id.Value);

            if (produtosViewModel == null) return NotFound();

            return View(produtosViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFornecedores(new ProdutosViewModel());
            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutosViewModel produtosViewModel)
        {
            produtosViewModel = await PopularFornecedores(produtosViewModel);

            if (!ModelState.IsValid) return View(produtosViewModel);

            await _produtoRepository.Adicionar(_mapper.Map<Produto>(produtosViewModel));

            return View(produtosViewModel);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            var produtosViewModel = await ObterProduto(id.Value);

            if (produtosViewModel == null) return NotFound();

            return View(produtosViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutosViewModel produtosViewModel)
        {
            if (id != produtosViewModel.Id) return NotFound();
            
            if (!ModelState.IsValid) return View(produtosViewModel);

            await _produtoRepository.Adicionar(_mapper.Map<Produto>(produtosViewModel));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            var produtosViewModel = await ObterProduto(id.Value);

            if (produtosViewModel == null) return NotFound();

            return View(produtosViewModel);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtosViewModel = await ObterProduto(id);

            if (produtosViewModel == null) return NotFound();

            await _produtoRepository.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<ProdutosViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutosViewModel>(await _produtoRepository.ObterProdutoPorFornecedor(id));
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produto;
        }

        private async Task<ProdutosViewModel> PopularFornecedores(ProdutosViewModel produtosViewModel)
        {
            produtosViewModel.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produtosViewModel;
        }
    }
}
