using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.DAL.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer.DAL.Entities.Customer>
    {
        public void Configure(EntityTypeBuilder<Entities.Customer> builder)
        {
            builder.HasKey(e => e.CustomerId);
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.PassWord).IsRequired();
        }
    }
}
