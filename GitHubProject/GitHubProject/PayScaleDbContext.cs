using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GitHubProject
{
    public partial class PayScaleDbContext : DbContext
    {
        public PayScaleDbContext()
        {
        }

        public PayScaleDbContext(DbContextOptions<PayScaleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pay> Pays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DELL-PC;database=PayScaleDb;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pay>(entity =>
            {
                entity.HasKey(e => e.PayBand)
                    .HasName("PK__Pay__66B0F53F192027FE");

                entity.ToTable("Pay");

                entity.Property(e => e.PayBand).HasMaxLength(1);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
