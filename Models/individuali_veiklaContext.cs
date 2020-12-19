﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace is_backend.Models
{
    public partial class individuali_veiklaContext : DbContext
    {
        public individuali_veiklaContext()
        {
        }

        public individuali_veiklaContext(DbContextOptions<individuali_veiklaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atsiliepimas> Atsiliepimas { get; set; }
        public virtual DbSet<Imone> Imone { get; set; }
        public virtual DbSet<IndividualiVeikla> IndividualiVeikla { get; set; }
        public virtual DbSet<TrumpalaikisDarbas> TrumpalaikisDarbas { get; set; }
        public virtual DbSet<Vartotojas> Vartotojas { get; set; }
        public virtual DbSet<VartotojoKandidatavimas> VartotojoKandidatavimas { get; set; }
        public virtual DbSet<VartotojoTipas> VartotojoTipas { get; set; }
        public virtual DbSet<VeiklosTipas> VeiklosTipas { get; set; }
        public virtual DbSet<VipUzsakymas> VipUzsakymas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Name=IndividualiVeiklaDB");
                //optionsBuilder.UseMySql("user id=root;persistsecurityinfo=True;server=127.0.0.1;database=individuali_veikla;password=root", x => x.ServerVersion("8.0.20-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atsiliepimas>(entity =>
            {
                entity.HasKey(e => e.IdAtsiliepimas)
                    .HasName("PRIMARY");

                entity.ToTable("atsiliepimas");

                entity.HasIndex(e => e.FkImoneidImone)
                    .HasName("fk_Imoneid_Imone");

                entity.HasIndex(e => e.FkIndividualiVeiklaidIndividualiVeikla)
                    .HasName("fk_Individuali_veiklaid_Individuali_veikla");

                entity.HasIndex(e => e.FkVartotojasidVartotojas)
                    .HasName("fk_Vartotojasid_Vartotojas");

                entity.Property(e => e.IdAtsiliepimas).HasColumnName("id_Atsiliepimas");

                entity.Property(e => e.FkImoneidImone).HasColumnName("fk_Imoneid_Imone");

                entity.Property(e => e.FkIndividualiVeiklaidIndividualiVeikla).HasColumnName("fk_Individuali_veiklaid_Individuali_veikla");

                entity.Property(e => e.FkVartotojasidVartotojas).HasColumnName("fk_Vartotojasid_Vartotojas");

                entity.Property(e => e.Ivertinimas).HasColumnName("ivertinimas");

                entity.Property(e => e.Komentaras)
                    .IsRequired()
                    .HasColumnName("komentaras")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SiuntejoId).HasColumnName("siuntejo_id");

                entity.Property(e => e.SiuntejoTipas)
                    .IsRequired()
                    .HasColumnName("siuntejo_tipas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.FkImoneidImoneNavigation)
                    .WithMany(p => p.Atsiliepimas)
                    .HasForeignKey(d => d.FkImoneidImone)
                    .HasConstraintName("atsiliepimas_ibfk_2");

                entity.HasOne(d => d.FkIndividualiVeiklaidIndividualiVeiklaNavigation)
                    .WithMany(p => p.Atsiliepimas)
                    .HasForeignKey(d => d.FkIndividualiVeiklaidIndividualiVeikla)
                    .HasConstraintName("atsiliepimas_ibfk_3");

                entity.HasOne(d => d.FkVartotojasidVartotojasNavigation)
                    .WithMany(p => p.Atsiliepimas)
                    .HasForeignKey(d => d.FkVartotojasidVartotojas)
                    .HasConstraintName("atsiliepimas_ibfk_1");
            });

            modelBuilder.Entity<Imone>(entity =>
            {
                entity.HasKey(e => e.IdImone)
                    .HasName("PRIMARY");

                entity.ToTable("imone");

                entity.Property(e => e.IdImone).HasColumnName("id_Imone");

                entity.Property(e => e.Adresas)
                    .IsRequired()
                    .HasColumnName("adresas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Aprasymas)
                    .IsRequired()
                    .HasColumnName("aprasymas")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ArUzsaldytas).HasColumnName("ar_uzsaldytas");

                entity.Property(e => e.ElPastas)
                    .IsRequired()
                    .HasColumnName("el_pastas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ImonesKodas)
                    .IsRequired()
                    .HasColumnName("imones_kodas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Miestas)
                    .IsRequired()
                    .HasColumnName("miestas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nuotrauka).HasColumnName("nuotrauka");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TelNr)
                    .IsRequired()
                    .HasColumnName("tel_nr")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Tinklalapis)
                    .HasColumnName("tinklalapis")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Vadovas)
                    .IsRequired()
                    .HasColumnName("vadovas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<IndividualiVeikla>(entity =>
            {
                entity.HasKey(e => e.IdIndividualiVeikla)
                    .HasName("PRIMARY");

                entity.ToTable("individuali_veikla");

                entity.HasIndex(e => e.FkVartotojasidVartotojas)
                    .HasName("turi");

                entity.HasIndex(e => e.FkVeiklosTipasidVeiklosTipas)
                    .HasName("priklauso");

                entity.Property(e => e.IdIndividualiVeikla).HasColumnName("id_Individuali_veikla");

                entity.Property(e => e.Aprasymas)
                    .IsRequired()
                    .HasColumnName("aprasymas")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ArUzsaldytas).HasColumnName("ar_uzsaldytas");

                entity.Property(e => e.FkVartotojasidVartotojas).HasColumnName("fk_Vartotojasid_Vartotojas");

                entity.Property(e => e.FkVeiklosTipasidVeiklosTipas).HasColumnName("fk_Veiklos_tipasid_Veiklos_tipas");

                entity.Property(e => e.Grafikas)
                    .IsRequired()
                    .HasColumnName("grafikas")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Kaina)
                    .HasColumnName("kaina")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Miestas)
                    .IsRequired()
                    .HasColumnName("miestas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Vip).HasColumnName("vip");

                entity.HasOne(d => d.FkVartotojasidVartotojasNavigation)
                    .WithMany(p => p.IndividualiVeikla)
                    .HasForeignKey(d => d.FkVartotojasidVartotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turi");

                entity.HasOne(d => d.FkVeiklosTipasidVeiklosTipasNavigation)
                    .WithMany(p => p.IndividualiVeikla)
                    .HasForeignKey(d => d.FkVeiklosTipasidVeiklosTipas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("priklauso");
            });

            modelBuilder.Entity<TrumpalaikisDarbas>(entity =>
            {
                entity.HasKey(e => e.IdTrumpalaikisDarbas)
                    .HasName("PRIMARY");

                entity.ToTable("trumpalaikis_darbas");

                entity.HasIndex(e => e.FkImoneidImone)
                    .HasName("kuria");

                entity.HasIndex(e => e.FkVeiklosTipasidVeiklosTipas)
                    .HasName("_priklauso");

                entity.Property(e => e.IdTrumpalaikisDarbas).HasColumnName("id_Trumpalaikis_darbas");

                entity.Property(e => e.Adresas)
                    .IsRequired()
                    .HasColumnName("adresas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Aprasymas)
                    .IsRequired()
                    .HasColumnName("aprasymas")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FkImoneidImone).HasColumnName("fk_Imoneid_Imone");

                entity.Property(e => e.FkVeiklosTipasidVeiklosTipas).HasColumnName("fk_Veiklos_tipasid_Veiklos_tipas");

                entity.Property(e => e.Miestas)
                    .IsRequired()
                    .HasColumnName("miestas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Uzmokestis)
                    .HasColumnName("uzmokestis")
                    .HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.FkImoneidImoneNavigation)
                    .WithMany(p => p.TrumpalaikisDarbas)
                    .HasForeignKey(d => d.FkImoneidImone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kuria");

                entity.HasOne(d => d.FkVeiklosTipasidVeiklosTipasNavigation)
                    .WithMany(p => p.TrumpalaikisDarbas)
                    .HasForeignKey(d => d.FkVeiklosTipasidVeiklosTipas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("_priklauso");
            });

            modelBuilder.Entity<Vartotojas>(entity =>
            {
                entity.HasKey(e => e.IdVartotojas)
                    .HasName("PRIMARY");

                entity.ToTable("vartotojas");

                entity.HasIndex(e => e.FkVartotojoTipasidVartotojoTipas)
                    .HasName("fk_Vartotojo_tipasid_Vartotojo_tipas");

                entity.Property(e => e.IdVartotojas).HasColumnName("id_Vartotojas");

                entity.Property(e => e.Aprasymas)
                    .IsRequired()
                    .HasColumnName("aprasymas")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ArUzsaldytas).HasColumnName("ar_uzsaldytas");

                entity.Property(e => e.AsmensKodas)
                    .IsRequired()
                    .HasColumnName("asmens_kodas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FkVartotojoTipasidVartotojoTipas).HasColumnName("fk_Vartotojo_tipasid_Vartotojo_tipas");

                entity.Property(e => e.GimimoMetai)
                    .HasColumnName("gimimo_metai")
                    .HasColumnType("date");

                entity.Property(e => e.Lytis)
                    .IsRequired()
                    .HasColumnName("lytis")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Pavarde)
                    .IsRequired()
                    .HasColumnName("pavarde")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SasNr)
                    .IsRequired()
                    .HasColumnName("sas_nr")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Vardas)
                    .IsRequired()
                    .HasColumnName("vardas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.FkVartotojoTipasidVartotojoTipasNavigation)
                    .WithMany(p => p.Vartotojas)
                    .HasForeignKey(d => d.FkVartotojoTipasidVartotojoTipas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vartotojas_ibfk_1");
            });

            modelBuilder.Entity<VartotojoKandidatavimas>(entity =>
            {
                entity.HasKey(e => new { e.FkTrumpalaikisDarbasidTrumpalaikisDarbas, e.FkVartotojasidVartotojas })
                    .HasName("PRIMARY");

                entity.ToTable("vartotojo_kandidatavimas");

                entity.Property(e => e.FkTrumpalaikisDarbasidTrumpalaikisDarbas).HasColumnName("fk_Trumpalaikis_darbasid_Trumpalaikis_darbas");

                entity.Property(e => e.FkVartotojasidVartotojas).HasColumnName("fk_Vartotojasid_Vartotojas");

                entity.HasOne(d => d.FkTrumpalaikisDarbasidTrumpalaikisDarbasNavigation)
                    .WithMany(p => p.VartotojoKandidatavimas)
                    .HasForeignKey(d => d.FkTrumpalaikisDarbasidTrumpalaikisDarbas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kandidatuoja");
            });

            modelBuilder.Entity<VartotojoTipas>(entity =>
            {
                entity.HasKey(e => e.IdVartotojoTipas)
                    .HasName("PRIMARY");

                entity.ToTable("vartotojo_tipas");

                entity.Property(e => e.IdVartotojoTipas).HasColumnName("id_Vartotojo_tipas");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<VeiklosTipas>(entity =>
            {
                entity.HasKey(e => e.IdVeiklosTipas)
                    .HasName("PRIMARY");

                entity.ToTable("veiklos_tipas");

                entity.Property(e => e.IdVeiklosTipas).HasColumnName("id_Veiklos_tipas");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<VipUzsakymas>(entity =>
            {
                entity.HasKey(e => e.IdVipUzsakymas)
                    .HasName("PRIMARY");

                entity.ToTable("vip_uzsakymas");

                entity.HasIndex(e => e.FkIndividualiVeiklaidIndividualiVeikla)
                    .HasName("uzsako");

                entity.Property(e => e.IdVipUzsakymas).HasColumnName("id_Vip_uzsakymas");

                entity.Property(e => e.FkIndividualiVeiklaidIndividualiVeikla).HasColumnName("fk_Individuali_veiklaid_Individuali_veikla");

                entity.Property(e => e.PbData)
                    .HasColumnName("pb_data")
                    .HasColumnType("date");

                entity.Property(e => e.PrData)
                    .HasColumnName("pr_data")
                    .HasColumnType("date");

                entity.HasOne(d => d.FkIndividualiVeiklaidIndividualiVeiklaNavigation)
                    .WithMany(p => p.VipUzsakymas)
                    .HasForeignKey(d => d.FkIndividualiVeiklaidIndividualiVeikla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uzsako");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
