using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RCR.App.ViewModels;

namespace RCR.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RCR.App.ViewModels.ProdutosViewModel>? ProdutosViewModel { get; set; }
    }
}