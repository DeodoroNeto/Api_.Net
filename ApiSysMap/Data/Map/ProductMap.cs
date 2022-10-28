using ApiSysMap.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSysMap.Data.Map
{
    public class ProductMap : IEntityTypeConfiguration<ProductModels>
    {
        public void Configure(EntityTypeBuilder<ProductModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Valor).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Quantidade).HasMaxLength(1000).IsRequired();
        }
    }
}
