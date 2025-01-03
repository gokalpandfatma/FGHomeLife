using System.ComponentModel.DataAnnotations;

namespace FGHomeLife.Models.Blog
{
    public class BlogTag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Slug { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}
