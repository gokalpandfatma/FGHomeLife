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

            // User-BlogPost ilişkisi
            modelBuilder.Entity<BlogPost>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // User-BlogComment ilişkisi
            modelBuilder.Entity<BlogComment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // BlogComment-ParentComment ilişkisi
            modelBuilder.Entity<BlogComment>()
                .HasOne(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Örnek kullanıcı
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin User",
                    Email = "admin@example.com",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                }
            );

            // Örnek blog kategorileri
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
                },
                new BlogCategory
                {
                    Id = 3,
                    Name = "Özel Günler",
                    Slug = "ozel-gunler",
                    Description = "Özel günler için çiçek önerileri",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                }
            );

            // Örnek blog etiketleri
            modelBuilder.Entity<BlogTag>().HasData(
                new BlogTag { Id = 1, Name = "Orkide", Slug = "orkide" },
                new BlogTag { Id = 2, Name = "Gül", Slug = "gul" },
                new BlogTag { Id = 3, Name = "Sukulent", Slug = "sukulent" },
                new BlogTag { Id = 4, Name = "Bakım", Slug = "bakim" },
                new BlogTag { Id = 5, Name = "İç Mekan", Slug = "ic-mekan" }
            );

            // Örnek blog yazıları
            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    Id = 1,
                    Title = "Orkide Bakımının Püf Noktaları",
                    Slug = "orkide-bakiminin-puf-noktalari",
                    Summary = "Orkidelerinizin uzun ömürlü olması için dikkat etmeniz gereken önemli bakım ipuçları.",
                    Content = @"<p>Orkideler, güzellikleri ve zarafetleriyle ev dekorasyonunun vazgeçilmez parçalarından biridir. Ancak bakımları konusunda dikkatli olunması gerekir.</p>
                               <h3>1. Doğru Sulama</h3>
                               <p>Orkideleri haftada bir kez, ılık suyla sulayın. Saksının altındaki deliklerden su akana kadar sulama yapın.</p>
                               <h3>2. Işık İhtiyacı</h3>
                               <p>Direkt güneş ışığından koruyun. Parlak ama dolaylı ışık alan bir konumda tutun.</p>",
                    ImageUrl = "/images/blog/orkide-bakim.jpg",
                    CategoryId = 1,
                    ViewCount = 0,
                    IsActive = true,
                    CreatedAt = DateTime.Now.AddDays(-5),
                    UserId = 1
                },
                new BlogPost
                {
                    Id = 2,
                    Title = "Ev Dekorasyonunda Çiçek Kullanımı",
                    Slug = "ev-dekorasyonunda-cicek-kullanimi",
                    Summary = "Evinizi çiçeklerle nasıl daha şık ve yaşanılır hale getirebileceğinizi öğrenin.",
                    Content = @"<p>Çiçekler, ev dekorasyonuna canlılık ve doğallık katan en önemli elementlerdir.</p>
                               <h3>Oturma Odası</h3>
                               <p>Büyük yapraklı bitkiler, oturma odasına tropik bir hava katabilir.</p>
                               <h3>Yatak Odası</h3>
                               <p>Lavanta gibi sakinleştirici çiçekler, yatak odasına huzur getirir.</p>",
                    ImageUrl = "/images/blog/ev-dekorasyon.jpg",
                    CategoryId = 2,
                    ViewCount = 0,
                    IsActive = true,
                    CreatedAt = DateTime.Now.AddDays(-3),
                    UserId = 1
                },
                new BlogPost
                {
                    Id = 3,
                    Title = "Sevgililer Günü İçin Çiçek Seçimi",
                    Slug = "sevgililer-gunu-icin-cicek-secimi",
                    Summary = "Sevgililer gününde partnerinizi şaşırtacak çiçek önerileri ve anlamları.",
                    Content = @"<p>Sevgililer günü için çiçek seçerken dikkat edilmesi gereken noktalar vardır.</p>
                               <h3>Klasik Kırmızı Güller</h3>
                               <p>Kırmızı güller, tutkunun ve aşkın evrensel sembolüdür.</p>
                               <h3>Alternatif Seçenekler</h3>
                               <p>Orkideler zarafeti, laleler ise mükemmel aşkı temsil eder.</p>",
                    ImageUrl = "/images/blog/sevgililer-gunu.jpg",
                    CategoryId = 3,
                    ViewCount = 0,
                    IsActive = true,
                    CreatedAt = DateTime.Now.AddDays(-1),
                    UserId = 1
                }
            );

            // Blog yazıları ve etiketler arasındaki ilişkiler
            modelBuilder.Entity("BlogPostBlogTag").HasData(
                new { BlogPostsId = 1, TagsId = 1 }, // Orkide - Orkide bakımı
                new { BlogPostsId = 1, TagsId = 4 }, // Orkide - Bakım
                new { BlogPostsId = 2, TagsId = 5 }, // Dekorasyon - İç Mekan
                new { BlogPostsId = 3, TagsId = 2 }  // Sevgililer günü - Gül
            );

            // Örnek yorumlar
            modelBuilder.Entity<BlogComment>().HasData(
                new BlogComment
                {
                    Id = 1,
                    BlogPostId = 1,
                    UserId = 1,
                    Content = "Harika bir yazı olmuş, teşekkürler!",
                    IsApproved = true,
                    CreatedAt = DateTime.Now.AddHours(-12)
                },
                new BlogComment
                {
                    Id = 2,
                    BlogPostId = 1,
                    UserId = 1,
                    ParentCommentId = 1,
                    Content = "Yorumunuz için teşekkürler!",
                    IsApproved = true,
                    CreatedAt = DateTime.Now.AddHours(-6)
                }
            );
        }
    }
}