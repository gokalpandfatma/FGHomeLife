using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FGHomeLife.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Slug { get; set; }

        [StringLength(500)]
        public string Summary { get; set; }

        public string Content { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public int ViewCount { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("CategoryId")]
        public virtual BlogCategory Category { get; set; }
        public virtual ICollection<BlogTag> Tags { get; set; }
        public virtual ICollection<BlogComment> Comments { get; set; }
    }
}
