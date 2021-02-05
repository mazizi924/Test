using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TavSystem.Entities.BaseClass;

namespace TavSystem.Entities
{
    public class AccountingDocument: BaseEntity<long>
    { 
        public string DocNo { get; set; } 
        public DateTimeOffset Date { get; set; } 
        public decimal Price { get; set; }
        public long InvitemId { get; set; }
        public Invitem Invitem { get; set; }
    }

    public class AccountingDocumentConfig : IEntityTypeConfiguration<AccountingDocument>
    {
        public void Configure(EntityTypeBuilder<AccountingDocument> builder)
        {
            builder.Property(p => p.DocNo).IsRequired().HasMaxLength(50);
            //builder.Property(p => p.InvitemNo).IsRequired().HasMaxLength(50); 
            builder.HasOne(p => p.Invitem).WithOne();
        }
    }
}
