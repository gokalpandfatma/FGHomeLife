using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FGHomeLife.Models
{
    public class BlogComment
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public int UserId { get; set; }
        public int? ParentCommentId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("BlogPostId")]
        public virtual BlogPost BlogPost { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ParentCommentId")]
        public virtual BlogComment ParentComment { get; set; }
        public virtual ICollection<BlogComment> Replies { get; set; }
    }
}
