using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatMash.Services.Cat.DataAccess
{
    public partial class CatDBContext : DbContext
    {
        public CatDBContext()
        {
        }

        public CatDBContext(DbContextOptions<CatDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TCat> TCat { get; set; }
        public virtual DbSet<TVote> TVote { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCat>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.ToTable("T_Cat");

                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<TVote>(entity =>
            {
                entity.HasKey(e => e.VoteId);

                entity.ToTable("T_Vote");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.LostCat)
                    .WithMany(p => p.TVoteLostCat)
                    .HasForeignKey(d => d.LostCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vote_LostCat_CatId");

                entity.HasOne(d => d.WinCat)
                    .WithMany(p => p.TVoteWinCat)
                    .HasForeignKey(d => d.WinCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vote_WinCat_CatId");
            });
        }
    }
}
