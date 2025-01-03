using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FGHomeLife.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [StringLength(1000)]
    public string Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [StringLength(500)]
    public string ImageUrl { get; set; }

    public bool IsNew { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
}