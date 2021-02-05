using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using TavSystem.Entities.BaseClass;

namespace TavSystem.Entities
{
    public class Customer : BaseEntity<long>
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<Invitem> invitems { get; set; }
    }
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {  
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(150); 
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(20); 
        }
    }
}
