using System;
using System.Collections.Generic;

namespace FGHomeLife.Models.ViewModels
{
    public class BlogListViewModel
    {
        public List<BlogPostViewModel> Posts { get; set; }
        public List<BlogCategoryViewModel> Categories { get; set; }
        public List<BlogTagViewModel> PopularTags { get; set; }
        public PaginationViewModel Pagination { get; set; }
    }

    public class BlogPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public List<string> Tags { get; set; }
        public int CommentCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class BlogDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public List<string> Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<BlogCommentViewModel> Comments { get; set; }
        public List<BlogPostViewModel> RelatedPosts { get; set; }
    }

    public class BlogCommentViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<BlogCommentViewModel> Replies { get; set; }
    }

    public class BlogCategoryViewModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int PostCount { get; set; }
    }

    public class BlogTagViewModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int PostCount { get; set; }
    }

    public class PaginationViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }

    public class HomeBlogPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}