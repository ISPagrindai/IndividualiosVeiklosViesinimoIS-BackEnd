using System;
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

        public virtual DbSet<Comments> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("user id=root;persistsecurityinfo=True;server=127.0.0.1;database=individuali_veikla;password=root", x => x.ServerVersion("8.0.20-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("comments");

                entity.Property(e => e.IdComments).HasColumnName("idComments");

                entity.Property(e => e.Turinys)
                    .HasColumnName("turinys")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
