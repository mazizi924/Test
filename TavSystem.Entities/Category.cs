using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using TavSystem.Entities.BaseClass;

namespace TavSystem.Entities
{
    public class Category : BaseEntity<int>
    {  
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
        public List<Product> products { get; set; }
    }


    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);

            builder.HasMany(c => c.Children).WithOne(c => c.Parent).HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
