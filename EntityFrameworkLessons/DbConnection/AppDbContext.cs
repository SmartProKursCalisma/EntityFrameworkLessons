using EntityFrameworkLessons.Entities;
using System.Data.Entity;

namespace EntityFrameworkLessons.DbConnection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("Server=202-00;Database=CourseProjectDb;User Id=sa;Password=1234;") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .Property(x => x.Username)
                .HasColumnName("ad_soyad");
            modelBuilder.Entity<User>()
                .ToTable("Kullanicilar");
            modelBuilder.Entity<User>()
                .Property(x => x.Username)
                .HasMaxLength(50)
                .IsRequired();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }

    }
}
