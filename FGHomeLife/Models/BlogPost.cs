using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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

        [Required]
        [StringLength(500)]
        public string Summary { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        public int ViewCount { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual BlogCategory Category { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual User User { get; set; }

        public virtual ICollection<BlogTag> Tags { get; set; }
        public virtual ICollection<BlogComment> Comments { get; set; }
    }
}