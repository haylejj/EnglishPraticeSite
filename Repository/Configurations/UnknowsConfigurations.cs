using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class UnknowsConfigurations : IEntityTypeConfiguration<Unknows>
    {
        public void Configure(EntityTypeBuilder<Unknows> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.EnglishWord).IsRequired().HasMaxLength(30);
            builder.Property(x => x.TurkishWord).IsRequired().HasMaxLength(30);
        }
    }
}
