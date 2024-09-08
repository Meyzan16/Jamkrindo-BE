using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities.Models.DbPenampung;

public partial class dbpenampung_context : DbContext
{
    private readonly IConfiguration _configuration;
    public dbpenampung_context(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public dbpenampung_context(DbContextOptions<dbpenampung_context> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<TblIntegrasi> TblIntegrasis { get; set; }

    public virtual DbSet<TblKlaimLobKurPen> TblKlaimLobKurPens { get; set; }

    public virtual DbSet<TblLogActivity> TblLogActivities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("dbpenampung"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblIntegrasi>(entity =>
        {
            entity.ToTable("Tbl_Integrasi");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.NameLob)
                .HasMaxLength(50)
                .HasColumnName("name_lob");
            entity.Property(e => e.NilaiBebanKlaim).HasColumnName("nilai_beban_klaim");
            entity.Property(e => e.PenyebabKlaim)
                .HasMaxLength(50)
                .HasColumnName("penyebab_klaim");
            entity.Property(e => e.Periode).HasColumnName("periode");
        });

        modelBuilder.Entity<TblKlaimLobKurPen>(entity =>
        {
            entity.ToTable("Tbl_KlaimLobKurPen");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DebetKredit)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("debet_kredit");
            entity.Property(e => e.JumlahTerjamin).HasColumnName("jumlah_terjamin");
            entity.Property(e => e.NamaWilker).HasColumnName("nama_wilker");
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

        modelBuilder.Entity<TblLogActivity>(entity =>
        {
            entity.ToTable("Tbl_logActivity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.JumlahData).HasColumnName("jumlah_data");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
