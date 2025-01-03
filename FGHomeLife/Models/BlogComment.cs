using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FGHomeLife.Models
{
    public class BlogComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int BlogPostId { get; set; }

        [ForeignKey("BlogPostId")]
        public virtual BlogPost BlogPost { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual User User { get; set; }

        public int? ParentCommentId { get; set; }

        [ForeignKey("ParentCommentId")]
        public virtual BlogComment ParentComment { get; set; }

        public virtual ICollection<BlogComment> Replies { get; set; }
    }
}