using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTaskBusinessSolution.DAL.Entities;

namespace TestTaskBusinessSolution.DAL.Configs
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(m => m.Name).HasColumnType("nvarchar(max)");
            builder.Property(m => m.Quantity).HasPrecision(18, 3);
            builder.Property(m => m.Unit).HasColumnType("nvarchar(max)");
        }
    }
}
