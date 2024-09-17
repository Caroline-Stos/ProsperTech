using Microsoft.EntityFrameworkCore;
using RepositorioEntity.Models;

namespace RepositorioEntity.Context;

public partial class GeladeiraDbContext : DbContext
{
    public GeladeiraDbContext()
    {
    }

    public GeladeiraDbContext(DbContextOptions<GeladeiraDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Andar> Andars { get; set; }

    public virtual DbSet<Container> Containers { get; set; }

    public virtual DbSet<Geladeira> Geladeiras { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Posicao> Posicaos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Andar>(entity =>
        {
            entity.HasKey(e => e.AndarId).HasName("PK__Andar__2772D655B0D2E06D");

            entity.ToTable("Andar");

            entity.Property(e => e.NomeAndar).HasMaxLength(30);

            entity.HasOne(d => d.Geladeira).WithMany(p => p.Andars)
                .HasForeignKey(d => d.GeladeiraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Andar_Geladeira");
        });

        modelBuilder.Entity<Container>(entity =>
        {
            entity.HasKey(e => e.ContainerId).HasName("PK__Containe__037960BBF8385074");

            entity.ToTable("Container");

            entity.Property(e => e.NomeContainer).HasMaxLength(100);

            entity.HasOne(d => d.Andar).WithMany(p => p.Containers)
                .HasForeignKey(d => d.AndarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Container_Andar");
        });

        modelBuilder.Entity<Geladeira>(entity =>
        {
            entity.HasKey(e => e.GeladeiraId).HasName("PK__Geladeir__B00035703002D1AA");

            entity.ToTable("Geladeira");

            entity.Property(e => e.Marca).HasMaxLength(100);
            entity.Property(e => e.Modelo).HasMaxLength(100);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Item__727E838BD29C86FB");

            entity.ToTable("Item");

            entity.Property(e => e.NomeItem).HasMaxLength(100);

            entity.HasOne(d => d.Container).WithMany(p => p.Items)
                .HasForeignKey(d => d.ContainerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Container");

            entity.HasOne(d => d.Posicao).WithMany(p => p.Items)
                .HasForeignKey(d => d.PosicaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Posicao");
        });

        modelBuilder.Entity<Posicao>(entity =>
        {
            entity.HasKey(e => e.PosicaoId).HasName("PK__Posicao__4FD57EAFED53CF6F");

            entity.ToTable("Posicao");

            entity.Property(e => e.NomePosicao).HasMaxLength(30);

            entity.HasOne(d => d.Container).WithMany(p => p.Posicaos)
                .HasForeignKey(d => d.ContainerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Posicao_Container");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
