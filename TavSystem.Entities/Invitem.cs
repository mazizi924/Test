using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TavSystem.Entities.BaseClass;

namespace TavSystem.Entities
{ 
    public class Invitem : BaseEntity<long> 
    { 
        public string InvitemNo { get; set; }
        public DateTimeOffset InvitemDate { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<InvitemDetail> invitemDetails { get; set; }  
    }

    public class InvitemConfig : IEntityTypeConfiguration<Invitem>
    {  
        public void Configure(EntityTypeBuilder<Invitem> builder)
        {
            builder.Property(i => i.InvitemNo).IsRequired().HasMaxLength(50);
            builder.HasOne(i => i.Customer).WithMany(i => i.invitems).HasForeignKey(i => i.CustomerId);
        }
    }
}
