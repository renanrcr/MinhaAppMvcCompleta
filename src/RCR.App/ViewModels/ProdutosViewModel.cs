using System.ComponentModel.DataAnnotations;

namespace RCR.App.ViewModels
{
    public class ProdutosViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string? Descricao { get; set; }

        public IFormFile? ImagemUpload { get; set; }
                
        public string? Imagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal Valor { get; set; }

        
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }


        [Display(Name = "Ativo?")]
        public bool Ativo { get; set; }

        public FornecedorViewModel? Fornecedor { get; set; }

        public IEnumerable<FornecedorViewModel>? Fornecedores { get; set; }
    }
}
