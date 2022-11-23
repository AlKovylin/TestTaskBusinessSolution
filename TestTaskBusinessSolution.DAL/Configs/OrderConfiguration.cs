using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTaskBusinessSolution.DAL.Entities;

namespace TestTaskBusinessSolution.DAL.Configs
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(m => m.Number).HasColumnType("nvarchar(max)");
            builder.Property(m => m.Date).HasColumnType("datetime2");
        }
    }
}
