using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendBG.Models;

public partial class DatabaseBgContext : DbContext
{
    public DatabaseBgContext()
    {
    }

    public DatabaseBgContext(DbContextOptions<DatabaseBgContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Favorito> Favoritos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DatabaseBG;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK_CATEGORIA");

            entity.ToTable("categoria");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.DescripCategoria)
                .IsUnicode(false)
                .HasColumnName("descripCategoria");
        });

        modelBuilder.Entity<Favorito>(entity =>
        {
            entity.HasKey(e => e.IdFavorito).HasName("PK_FAVORITO");

            entity.ToTable("favoritos");

            entity.Property(e => e.IdFavorito).HasColumnName("idFavorito");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_FAVORITO_CATEGORIA");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_FAVORITO_PRODUCTO");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK_PRODUCTO");

            entity.ToTable("producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.DescripProducto)
                .IsUnicode(false)
                .HasColumnName("descripProducto");
            entity.Property(e => e.FotoProducto)
                .IsUnicode(false)
                .HasColumnName("fotoProducto");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.NameProducto)
                .IsUnicode(false)
                .HasColumnName("nameProducto");
            entity.Property(e => e.Precio).HasColumnName("precio");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_PRODUCTO_CATEGORIA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
