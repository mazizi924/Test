using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TavSystem.Entities.BaseClass;

namespace TavSystem.Entities
{
    public class Delivery : BaseEntity<long>
    { 
        public string DeliveryNo { get; set; }  
        public int Count { get; set; }
        public DateTimeOffset Date { get; set; }
        public long ProductId { get; set; }
        public Product product { get; set; }
    }
    public class DeliveryConfig : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        { 
            builder.Property(p => p.DeliveryNo).IsRequired().HasMaxLength(50);
            builder.HasOne(p => p.product).WithMany(p => p.Deliveries).HasForeignKey(p => p.ProductId);

        }
    }
}
