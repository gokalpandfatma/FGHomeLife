using System;

namespace FGHomeLife.Models.DTOs
{
    public class BlogListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public int CommentCount { get; set; }
        public string Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalCount { get; set; }
    }
}