using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaPrimeiraApi.Entities;

namespace MinhaPrimeiraApi.Data.Configuration
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("tbProduct");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("ID").HasColumnType("int").IsRequired();
            builder.Property(u => u.Name).HasColumnName("NAME").HasColumnType("varchar(100)").IsRequired();
            builder.Property(u => u.Price).HasColumnName("PRICE").HasColumnType("decimal(16,2)").IsRequired();
            builder.Property(u => u.Created).HasColumnName("CREATED").HasColumnType("datetime2").IsRequired();

            

        }
        
    }
}