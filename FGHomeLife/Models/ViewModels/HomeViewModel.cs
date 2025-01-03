namespace FGHomeLife.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public List<ProductViewModel> FeaturedProducts { get; set; }
        public List<BlogPostViewModel> RecentBlogPosts { get; set; }
    }
}

public class CategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string IconClass { get; set; }
}

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public bool IsNew { get; set; }
}

public class HomeBlogPostViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public DateTime CreatedAt { get; set; }
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