using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTaskBusinessSolution.DAL.Entities;

namespace TestTaskBusinessSolution.DAL.Configs
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.Property(m => m.Name).HasColumnType("nvarchar(max)");
        }
    }
}
