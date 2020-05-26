namespace Model.Xsis
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<TB_KREDIT_RUMAH> TB_KREDIT_RUMAH { get; set; }
        public virtual DbSet<TB_NASABAH> TB_NASABAH { get; set; }
        public virtual DbSet<TB_REKENING> TB_REKENING { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_KREDIT_RUMAH>()
                .Property(e => e.NO_REKENING)
                .IsUnicode(false);

            modelBuilder.Entity<TB_KREDIT_RUMAH>()
                .Property(e => e.NAMA)
                .IsUnicode(false);

            modelBuilder.Entity<TB_KREDIT_RUMAH>()
                .Property(e => e.PLAFOND)
                .HasPrecision(19, 0);

            modelBuilder.Entity<TB_KREDIT_RUMAH>()
                .Property(e => e.PERSEN_BUNGA)
                .HasPrecision(5, 0);

            modelBuilder.Entity<TB_KREDIT_RUMAH>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<TB_KREDIT_RUMAH>()
                .Property(e => e.UPDATE_BY)
                .IsUnicode(false);

            modelBuilder.Entity<TB_NASABAH>()
                .Property(e => e.NAMA)
                .IsUnicode(false);

            modelBuilder.Entity<TB_NASABAH>()
                .Property(e => e.NIK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_NASABAH>()
                .Property(e => e.TELEPON)
                .IsUnicode(false);

            modelBuilder.Entity<TB_NASABAH>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<TB_NASABAH>()
                .Property(e => e.JENIS_KELAMIN)
                .IsUnicode(false);

            modelBuilder.Entity<TB_NASABAH>()
                .Property(e => e.AGAMA)
                .IsUnicode(false);

            modelBuilder.Entity<TB_NASABAH>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_NASABAH>()
                .Property(e => e.NAMA_IBU_KANDUNG)
                .IsUnicode(false);

            modelBuilder.Entity<TB_NASABAH>()
                .Property(e => e.PEKERJAAN)
                .IsUnicode(false);

            modelBuilder.Entity<TB_NASABAH>()
                .Property(e => e.ALAMAT)
                .IsUnicode(false);

            modelBuilder.Entity<TB_NASABAH>()
                .Property(e => e.UPDATE_BY)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REKENING>()
                .Property(e => e.NO_REKENING)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REKENING>()
                .Property(e => e.UPDATE_BY)
                .IsUnicode(false);

            modelBuilder.Entity<TB_REKENING>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);
        }
    }
}
