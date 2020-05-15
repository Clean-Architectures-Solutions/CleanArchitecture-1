using Audit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Audit.Infrastructure.Persistence.Configurations
{
    public class FashionConfiguration: IEntityTypeConfiguration<Fashion>
    {
        public void Configure(EntityTypeBuilder<Fashion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                .HasMaxLength(120)
                .IsRequired();
        }
    }
}