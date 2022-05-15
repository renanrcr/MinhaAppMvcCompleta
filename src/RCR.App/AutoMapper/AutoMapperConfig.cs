using AutoMapper;
using RCR.App.ViewModels;
using RCR.Business.Models;

namespace RCR.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutosViewModel>().ReverseMap();
        }
    }
}
