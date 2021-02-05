using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TavSystem.Entities.BaseClass;

namespace TavSystem.Entities
{ 
    public class InvitemDetail : BaseEntity<long>  
    { 
        public int Count { get; set; }  
        public long Price { get; set; }
        public DateTimeOffset Date { get; set; }
        public long InvitemId { get; set; }
        public Invitem Invitem { get; set; }
        public long ProductId { get; set; }
        public Product product { get; set; }
    }
    public class InvitemDetailConfig : IEntityTypeConfiguration<InvitemDetail>
    {
        public void Configure(EntityTypeBuilder<InvitemDetail> builder)
        { 
            builder.HasOne(i => i.Invitem).WithMany(i => i.invitemDetails).HasForeignKey(i => i.InvitemId);
            builder.HasOne(i => i.product).WithMany(i => i.invitemDetails).HasForeignKey(i => i.ProductId);
        }
    }
}
