using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PW.Domain.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.Persistence.Configurations.Membership
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(user => user.LastName).IsRequired().HasMaxLength(100);
            builder.Property(user => user.Email).IsRequired().HasMaxLength(255);
            builder.Property(user => user.PasswordHash).IsRequired();
            builder.Property(user => user.CreatedAt).IsRequired();
        }
    }
}
