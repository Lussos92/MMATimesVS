using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatabaseLayer.Models
{
    public partial class MMATimes_MainContext : DbContext
    {
        public MMATimes_MainContext()
        {
        }

        public MMATimes_MainContext(DbContextOptions<MMATimes_MainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NewsStory> NewsStories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-5SO0K6B;Initial Catalog=MMATimes_Main;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<NewsStory>(entity =>
            {
                entity.ToTable("NewsStory");

                entity.Property(e => e.Blurb).HasMaxLength(100);

                entity.Property(e => e.MainBody).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
