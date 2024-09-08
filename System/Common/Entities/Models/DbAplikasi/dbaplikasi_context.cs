using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities.Models.DbAplikasi;

public partial class dbaplikasi_context : DbContext
{
    private readonly IConfiguration _configuration;
    public dbaplikasi_context(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public dbaplikasi_context(DbContextOptions<dbaplikasi_context> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<TblKlaimLob> TblKlaimLobs { get; set; }

    public virtual DbSet<TblWilayahKerja> TblWilayahKerjas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("dbaplikasi"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblKlaimLob>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_KlaimLob");

            entity.Property(e => e.DebetKredit)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("debet_kredit");
            entity.Property(e => e.IdWilker).HasColumnName("id_wilker");
            entity.Property(e => e.JumlahTerjamin).HasColumnName("jumlah_terjamin");
            entity.Property(e => e.NilaiBebanKlaim)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("nilai_beban_klaim");
            entity.Property(e => e.PenyebabKlaim)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("penyebab_klaim");
            entity.Property(e => e.Periode).HasColumnName("periode");
            entity.Property(e => e.SubCob)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("sub_cob");
            entity.Property(e => e.TglKeputusanKlaim).HasColumnName("tgl_keputusan_klaim");
        });

        modelBuilder.Entity<TblWilayahKerja>(entity =>
        {
            entity.ToTable("Tbl_WilayahKerja");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NamaWilker)
                .HasMaxLength(50)
                .HasColumnName("nama_wilker");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
