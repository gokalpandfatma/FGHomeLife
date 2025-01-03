﻿// <auto-generated />
using System;
using FGHomeLife.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FGHomeLife.Migrations
{
    [DbContext(typeof(FGAppDbContext))]
    partial class FGAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlogPostBlogTag", b =>
                {
                    b.Property<int>("BlogPostsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("BlogPostsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("BlogPostTags", (string)null);

                    b.HasData(
                        new
                        {
                            BlogPostsId = 1,
                            TagsId = 1
                        },
                        new
                        {
                            BlogPostsId = 1,
                            TagsId = 4
                        },
                        new
                        {
                            BlogPostsId = 2,
                            TagsId = 5
                        },
                        new
                        {
                            BlogPostsId = 3,
                            TagsId = 2
                        });
                });

            modelBuilder.Entity("FGHomeLife.Models.BlogCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BlogCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6137),
                            Description = "Çiçeklerinizin bakımı hakkında ipuçları",
                            IsActive = true,
                            Name = "Çiçek Bakımı",
                            Slug = "cicek-bakimi"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6211),
                            Description = "Ev dekorasyonunda çiçek kullanımı",
                            IsActive = true,
                            Name = "Dekorasyon",
                            Slug = "dekorasyon"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6212),
                            Description = "Özel günler için çiçek önerileri",
                            IsActive = true,
                            Name = "Özel Günler",
                            Slug = "ozel-gunler"
                        });
                });

            modelBuilder.Entity("FGHomeLife.Models.BlogComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlogPostId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.HasIndex("ParentCommentId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("BlogComments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlogPostId = 1,
                            Content = "Harika bir yazı olmuş, teşekkürler!",
                            CreatedAt = new DateTime(2025, 1, 3, 13, 6, 37, 546, DateTimeKind.Local).AddTicks(9194),
                            IsApproved = true,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BlogPostId = 1,
                            Content = "Yorumunuz için teşekkürler!",
                            CreatedAt = new DateTime(2025, 1, 3, 19, 6, 37, 546, DateTimeKind.Local).AddTicks(9332),
                            IsApproved = true,
                            ParentCommentId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("FGHomeLife.Models.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("BlogPosts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Content = "<p>Orkideler, güzellikleri ve zarafetleriyle ev dekorasyonunun vazgeçilmez parçalarından biridir. Ancak bakımları konusunda dikkatli olunması gerekir.</p>\r\n                               <h3>1. Doğru Sulama</h3>\r\n                               <p>Orkideleri haftada bir kez, ılık suyla sulayın. Saksının altındaki deliklerden su akana kadar sulama yapın.</p>\r\n                               <h3>2. Işık İhtiyacı</h3>\r\n                               <p>Direkt güneş ışığından koruyun. Parlak ama dolaylı ışık alan bir konumda tutun.</p>",
                            CreatedAt = new DateTime(2024, 12, 30, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(7358),
                            ImageUrl = "/images/blog/orkide-bakim.jpg",
                            IsActive = true,
                            Slug = "orkide-bakiminin-puf-noktalari",
                            Summary = "Orkidelerinizin uzun ömürlü olması için dikkat etmeniz gereken önemli bakım ipuçları.",
                            Title = "Orkide Bakımının Püf Noktaları",
                            UserId = 1,
                            ViewCount = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Content = "<p>Çiçekler, ev dekorasyonuna canlılık ve doğallık katan en önemli elementlerdir.</p>\r\n                               <h3>Oturma Odası</h3>\r\n                               <p>Büyük yapraklı bitkiler, oturma odasına tropik bir hava katabilir.</p>\r\n                               <h3>Yatak Odası</h3>\r\n                               <p>Lavanta gibi sakinleştirici çiçekler, yatak odasına huzur getirir.</p>",
                            CreatedAt = new DateTime(2025, 1, 1, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(7534),
                            ImageUrl = "/images/blog/ev-dekorasyon.jpg",
                            IsActive = true,
                            Slug = "ev-dekorasyonunda-cicek-kullanimi",
                            Summary = "Evinizi çiçeklerle nasıl daha şık ve yaşanılır hale getirebileceğinizi öğrenin.",
                            Title = "Ev Dekorasyonunda Çiçek Kullanımı",
                            UserId = 1,
                            ViewCount = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Content = "<p>Sevgililer günü için çiçek seçerken dikkat edilmesi gereken noktalar vardır.</p>\r\n                               <h3>Klasik Kırmızı Güller</h3>\r\n                               <p>Kırmızı güller, tutkunun ve aşkın evrensel sembolüdür.</p>\r\n                               <h3>Alternatif Seçenekler</h3>\r\n                               <p>Orkideler zarafeti, laleler ise mükemmel aşkı temsil eder.</p>",
                            CreatedAt = new DateTime(2025, 1, 3, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(7538),
                            ImageUrl = "/images/blog/sevgililer-gunu.jpg",
                            IsActive = true,
                            Slug = "sevgililer-gunu-icin-cicek-secimi",
                            Summary = "Sevgililer gününde partnerinizi şaşırtacak çiçek önerileri ve anlamları.",
                            Title = "Sevgililer Günü İçin Çiçek Seçimi",
                            UserId = 1,
                            ViewCount = 0
                        });
                });

            modelBuilder.Entity("FGHomeLife.Models.BlogTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("BlogTags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6451),
                            Name = "Orkide",
                            Slug = "orkide"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6650),
                            Name = "Gül",
                            Slug = "gul"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6651),
                            Name = "Sukulent",
                            Slug = "sukulent"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6651),
                            Name = "Bakım",
                            Slug = "bakim"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6652),
                            Name = "İç Mekan",
                            Slug = "ic-mekan"
                        });
                });

            modelBuilder.Entity("FGHomeLife.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("IconClass")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FGHomeLife.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(2483),
                            Email = "admin@example.com",
                            IsActive = true,
                            Name = "Admin User"
                        });
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BlogPostBlogTag", b =>
                {
                    b.HasOne("FGHomeLife.Models.BlogPost", null)
                        .WithMany()
                        .HasForeignKey("BlogPostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FGHomeLife.Models.BlogTag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FGHomeLife.Models.BlogComment", b =>
                {
                    b.HasOne("FGHomeLife.Models.BlogPost", "BlogPost")
                        .WithMany("Comments")
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FGHomeLife.Models.BlogComment", "ParentComment")
                        .WithMany("Replies")
                        .HasForeignKey("ParentCommentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FGHomeLife.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FGHomeLife.Models.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId1");

                    b.Navigation("BlogPost");

                    b.Navigation("ParentComment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FGHomeLife.Models.BlogPost", b =>
                {
                    b.HasOne("FGHomeLife.Models.BlogCategory", "Category")
                        .WithMany("BlogPosts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FGHomeLife.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.HasOne("FGHomeLife.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FGHomeLife.Models.BlogCategory", b =>
                {
                    b.Navigation("BlogPosts");
                });

            modelBuilder.Entity("FGHomeLife.Models.BlogComment", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("FGHomeLife.Models.BlogPost", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("FGHomeLife.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FGHomeLife.Models.User", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
