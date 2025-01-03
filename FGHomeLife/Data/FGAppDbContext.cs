using Microsoft.EntityFrameworkCore;
using FGHomeLife.Models;

namespace FGHomeLife.Data
{
    public class FGAppDbContext : DbContext
    {
        public FGAppDbContext(DbContextOptions<FGAppDbContext> options)
            : base(options)
        {
        }

        // Blog için DbSet'ler
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }

        // Ana sayfa için DbSet'ler
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Blog için ilişkiler
            modelBuilder.Entity<BlogPost>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.BlogPosts)
                .UsingEntity(j => j.ToTable("BlogPostTags"));

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Örnek veriler
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Sevgiliye Çiçekler",
                    Description = "Aşkınızı ifade eden özel tasarımlar",
                    IconClass = "fas fa-heart",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 2,
                    Name = "Doğum Günü",
                    Description = "Özel günler için özel hediyeler",
                    IconClass = "fas fa-gift",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<BlogCategory>().HasData(
                new BlogCategory
                {
                    Id = 1,
                    Name = "Çiçek Bakımı",
                    Slug = "cicek-bakimi",
                    Description = "Çiçeklerinizin bakımı hakkında ipuçları",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new BlogCategory
                {
                    Id = 2,
                    Name = "Dekorasyon",
                    Slug = "dekorasyon",
                    Description = "Ev dekorasyonunda çiçek kullanımı",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                }
            );
        }
    }
}