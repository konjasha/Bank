using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KursovayaBank.Models.BaDB;

public partial class BaDB : DbContext
{
    public BaDB()
    {
    }

    public BaDB(DbContextOptions<BaDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Credit> Credits { get; set; }

    public virtual DbSet<VidCredit> VidCredits { get; set; }

    public virtual DbSet<adres> adress { get; set; }

    public virtual DbSet<creditHist> creditHists { get; set; }

    public virtual DbSet<document> documents { get; set; }

    public virtual DbSet<statusCredit> statusCredits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BankDB;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.idclient).HasName("Client_pkey");

            entity.ToTable("Client");

            entity.Property(e => e.idclient).UseIdentityAlwaysColumn();
            entity.Property(e => e.fio).HasMaxLength(100);
            entity.Property(e => e.gender).HasMaxLength(100);
        });

        modelBuilder.Entity<Credit>(entity =>
        {
            entity.HasKey(e => e.idCredit).HasName("Credit_pkey");

            entity.ToTable("Credit");

            entity.Property(e => e.idCredit).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.idClientNavigation).WithMany(p => p.Credits)
                .HasForeignKey(d => d.idClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clientCredit");

            entity.HasOne(d => d.idV).WithMany(p => p.Credits)
                .HasForeignKey(d => d.idVid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_vidCredit");
        });

        modelBuilder.Entity<VidCredit>(entity =>
        {
            entity.HasKey(e => e.idVid).HasName("vidCredit_pkey");

            entity.ToTable("VidCredit");

            entity.Property(e => e.idVid).UseIdentityAlwaysColumn();
            entity.Property(e => e.Srok_dney_).HasColumnName("Srok(dney)");
        });

        modelBuilder.Entity<adres>(entity =>
        {
            entity.HasKey(e => e.idAdres).HasName("Adres_pkey");

            entity.Property(e => e.idAdres).UseIdentityAlwaysColumn();
            entity.Property(e => e.adresFact).HasMaxLength(100);
            entity.Property(e => e.adresReg).HasMaxLength(100);

            entity.HasOne(d => d.klient).WithMany(p => p.adres)
                .HasForeignKey(d => d.klientId)
                .HasConstraintName("fk_clientAdres");
        });

        modelBuilder.Entity<creditHist>(entity =>
        {
            entity.HasKey(e => e.idCredithist).HasName("creditHist_pkey");

            entity.ToTable("creditHist");

            entity.Property(e => e.idCredithist).UseIdentityAlwaysColumn();
            entity.Property(e => e.Bank).HasMaxLength(100);
            entity.Property(e => e.StatusHist).HasMaxLength(100);

            entity.HasOne(d => d.idClientNavigation).WithMany(p => p.creditHists)
                .HasForeignKey(d => d.idClient)
                .HasConstraintName("fk_clientHist");
        });

        modelBuilder.Entity<document>(entity =>
        {
            entity.HasKey(e => e.idDocument).HasName("document_pkey");

            entity.ToTable("document");

            entity.Property(e => e.idDocument).UseIdentityAlwaysColumn();
            entity.Property(e => e.vidDocument).HasMaxLength(100);

            entity.HasOne(d => d.idClientNavigation).WithMany(p => p.documents)
                .HasForeignKey(d => d.idClient)
                .HasConstraintName("fk_clientDocument");
        });

        modelBuilder.Entity<statusCredit>(entity =>
        {
            entity.HasKey(e => e.idStatus).HasName("statusCredit_pkey");

            entity.ToTable("statusCredit");

            entity.Property(e => e.idStatus).UseIdentityAlwaysColumn();
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.Zayavka).HasMaxLength(100);

            entity.HasOne(d => d.idCreditNavigation).WithMany(p => p.statusCredits)
                .HasForeignKey(d => d.idCredit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkcreditStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
