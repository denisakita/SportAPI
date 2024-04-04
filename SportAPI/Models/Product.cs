using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportAPI.Models;

public class Product
{
    public int Id { get; set; }

    public string Sku { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    public int CategoryId { get; set; }
    [JsonIgnore]
    public virtual Category Category { get; set; }
}

// public class ProductConfig : IEntityTypeConfiguration<Product>
// {
//     public void Configure(EntityTypeBuilder<Product> builder)
//     {
//        
//         builder.HasOne(p => p.Category)
//             .WithMany(c => c.Products)
//             .HasForeignKey(p => p.CategoryId)
//             .OnDelete(DeleteBehavior.Cascade); 
//
//     }
// }