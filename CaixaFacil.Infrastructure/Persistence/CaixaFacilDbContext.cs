using CaixaFacil.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaixaFacil.Infrastructure.Persistence;
public class CaixaFacilDbContext : DbContext
{
    public CaixaFacilDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Caixa> Caixas { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>(entity =>
        {
        entity.ToTable("Pedidos");

        entity.HasKey(p => p.Id);

        entity.HasMany(p => p.Produtos)
           .WithOne(p => p.Pedido)
           .HasForeignKey(p => p.PedidoId)
           .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.ToTable("Produtos");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);


            entity.Property(p => p.Altura)
                  .IsRequired()
                  .HasColumnType("decimal(10,2)");

            entity.Property(p => p.Largura)
                  .IsRequired()
                  .HasColumnType("decimal(10,2)");

            entity.Property(p => p.Comprimento)
                  .IsRequired()
                  .HasColumnType("decimal(10,2)");
        });


        modelBuilder.Entity<Caixa>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Name)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(c => c.Altura)
                  .IsRequired()
                  .HasColumnType("decimal(10,2)");

            entity.Property(c => c.Largura)
                  .IsRequired()
                  .HasColumnType("decimal(10,2)");

            entity.Property(c => c.Comprimento)
                  .IsRequired()
                  .HasColumnType("decimal(10,2)");
        });

        base.OnModelCreating(modelBuilder);
    }
}
