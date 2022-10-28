using ApiSysMap.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSysMap.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModels>
    {
        public void Configure(EntityTypeBuilder<UserModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
        }
    }
}
