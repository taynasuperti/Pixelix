using Pixelix.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pixelix.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
{
    #region Populate Roles
    List<IdentityRole> roles =
    [
        new IdentityRole()
        {
            Id = "ROLE-ADMIN-0001",
            Name = "Administrador",
            NormalizedName = "ADMINISTRADOR"
        },
        new IdentityRole()
        {
            Id = "ROLE-CLIENT-0001",
            Name = "Cliente",
            NormalizedName = "CLIENTE"
        },
    ];
    builder.Entity<IdentityRole>().HasData(roles);
    #endregion

    #region Populate Usuário
    List<Usuario> usuarios =
    [
        new Usuario()
        {
            Id = "USER-ADMIN-0001",
            Email = "taynasuperti@gmail.com",
            NormalizedEmail = "TAYNASUPERTI@GMAIL.COM",
            UserName = "taynasuperti@gmail.com",
            NormalizedUserName = "TAYNASUPERTI@GMAIL.COM",
            LockoutEnabled = true,
            EmailConfirmed = true,
            Nome = "Tayná Carolina Miguel Superti",
            DataNascimento = new DateTime(2006, 11, 6), // FIXO
            Foto = "/img/usuarios/avatar.png"
        }
    ];

    foreach (var user in usuarios)
    {
        PasswordHasher<Usuario> pass = new();
        user.PasswordHash = pass.HashPassword(user, "123456");
    }

    builder.Entity<Usuario>().HasData(usuarios);
    #endregion

    #region Populate UserRole
    List<IdentityUserRole<string>> userRoles =
    [
        new IdentityUserRole<string>()
        {
            UserId = "USER-ADMIN-0001",
            RoleId = "ROLE-ADMIN-0001"
        }
    ];
    builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    #endregion
}

    private static void SeedCategoriaPadrao(ModelBuilder builder)
    {
        List<Categoria> categorias = new()
        {
            // Criar suas categorias
        };
        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProdutoPadrao(ModelBuilder builder)
    {
        List<Produto> produtos = new()
        {
            // Criar seus produtos
        };
        builder.Entity<Produto>().HasData(produtos);
    }

}