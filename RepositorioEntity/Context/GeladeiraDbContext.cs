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

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost;Database=GeladeiraDB;Uid=adm_caroline;Pwd=12345;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Andar>(entity =>
        {
            entity.HasKey(e => e.AndarId).HasName("PK__Andar__2772D655AFB46013");

            entity.ToTable("Andar");

            entity.Property(e => e.NomeAndar).HasMaxLength(30);

            entity.HasOne(d => d.Geladeira).WithMany(p => p.Andars)
                .HasForeignKey(d => d.GeladeiraId)
                .HasConstraintName("FK_Andar_Geladeira");
        });

        modelBuilder.Entity<Container>(entity =>
        {
            entity.HasKey(e => e.ContainerId).HasName("PK__Containe__037960BB84C12246");

            entity.ToTable("Container");

            entity.Property(e => e.Nome).HasMaxLength(100);

            entity.HasOne(d => d.Andar).WithMany(p => p.Containers)
                .HasForeignKey(d => d.AndarId)
                .HasConstraintName("FK_Container_Andar");
        });

        modelBuilder.Entity<Geladeira>(entity =>
        {
            entity.HasKey(e => e.GeladeiraId).HasName("PK__Geladeir__B000357037E509BC");

            entity.ToTable("Geladeira");

            entity.Property(e => e.Marca).HasMaxLength(100);
            entity.Property(e => e.Modelo).HasMaxLength(100);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Item__727E838B15A38A46");

            entity.ToTable("Item");

            entity.Property(e => e.Nome).HasMaxLength(100);

            entity.HasOne(d => d.Container).WithMany(p => p.Items)
                .HasForeignKey(d => d.ContainerId)
                .HasConstraintName("FK_Item_Container");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
