using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TavSystem.Entities.BaseClass;

namespace TavSystem.Entities
{  
    public class Product : BaseEntity<long>
    { 
        public string Name { get; set; }  
        public string ProductCode { get; set; } 
        public int MinInventory { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<InvitemDetail> invitemDetails { get; set; }
        public List<Delivery> Deliveries { get; set; }
    }

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.ProductCode).IsRequired().HasMaxLength(50);
            builder.HasOne(p => p.Category).WithMany(p => p.products).HasForeignKey(p=>p.CategoryId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
