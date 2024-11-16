using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIClientesFinal.Models;

public partial class Umgdesaweb24Context : DbContext
{
    public Umgdesaweb24Context()
    {
    }

    public Umgdesaweb24Context(DbContextOptions<Umgdesaweb24Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Informaciongeneral> Informaciongenerals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=umgdesaweb24;Username=postgres;Password=temporal1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clientes_pkey");

            entity.ToTable("clientes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.Fechanacimiento).HasColumnName("fechanacimiento");
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .HasColumnName("genero");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");
        });

        modelBuilder.Entity<Informaciongeneral>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("informaciongeneral_pkey");

            entity.ToTable("informaciongeneral");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Estadoinformacion)
                .HasMaxLength(50)
                .HasColumnName("estadoinformacion");
            entity.Property(e => e.Fechaactualizacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaactualizacion");
            entity.Property(e => e.Fechacreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Tipoinformacion)
                .HasMaxLength(100)
                .HasColumnName("tipoinformacion");
            entity.Property(e => e.Usuariocreador)
                .HasMaxLength(100)
                .HasColumnName("usuariocreador");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Informaciongenerals)
                .HasForeignKey(d => d.Clienteid)
                .HasConstraintName("informaciongeneral_clienteid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
