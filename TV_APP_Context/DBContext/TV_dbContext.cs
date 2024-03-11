using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TV_APP_Context.Models;

namespace TV_APP_Context.DBContext
{
    public partial class TV_dbContext : DbContext
    {
        public TV_dbContext()
        {
        }

        public TV_dbContext(DbContextOptions<TV_dbContext> options)
            : base(options)
        {
        }

        public  DbSet<Event> Events { get; set; } 
        public  DbSet<Video> Videos { get; set; } 
        public  DbSet<Fact> Facts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DDO84UQ; Initial Catalog=TV_db; Integrated Security=True");
                //"Data Source=ORIT-14\\SQLEXPRESS; Initial Catalog=TV_db; User id=Student ORIT ; Password=DabiduN");
                //
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.IdEvent);

                entity.Property(e => e.IdEvent).HasColumnName("ID_Event");

                entity.Property(e => e.DateEvent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Date_Event");

                entity.Property(e => e.NameEvent)
                    .HasMaxLength(50)
                    .HasColumnName("Name_Event");

                entity.Property(e => e.PictureEvent).HasColumnName("Picture_Event");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasKey(e => e.IdVideo);

                entity.Property(e => e.IdVideo)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Video");

                entity.Property(e => e.SourceVideo).HasColumnName("Source_Video");
            });

            modelBuilder.Entity<Fact>(entity =>
            {
                entity.HasKey(entity => entity.IdFact);

                entity.Property(entity => entity.IdFact)
                    .HasColumnName("ID_Fact");

                entity.Property(entity => entity.DescFact).HasColumnName("Desc_Fact");

                entity.Property(entity => entity.TitleFact).HasColumnName("Title_Fact");

                entity.Property(entity => entity.PictureFact).HasColumnName("Picture_Fact");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
