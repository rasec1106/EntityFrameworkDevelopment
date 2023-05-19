using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test_Practice01_01.Models
{
    public partial class TestPractice01Context : DbContext
    {
        public TestPractice01Context()
        {
        }

        public TestPractice01Context(DbContextOptions<TestPractice01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<MyProvider> MyProviders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LIMAPELP348;Initial Catalog=TestPractice01;User Id=sa;Password=0112Password!@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyProvider>(entity =>
            {
                entity.HasKey(e => e.ProviderId)
                    .HasName("PK__MyProvid__107017F320BD2C20");

                entity.ToTable("MyProvider");

                entity.Property(e => e.ProviderId).HasColumnName("providerId");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.ProviderName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("providerName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
