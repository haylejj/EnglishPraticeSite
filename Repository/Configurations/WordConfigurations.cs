using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class WordConfigurations : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.EnglishWord).IsRequired().HasMaxLength(30);
            builder.Property(x => x.TurkishWord).IsRequired().HasMaxLength(30);
            builder.HasOne(x => x.Favorite).WithOne(x => x.Word).HasForeignKey<Favorite>(x => x.WordId);
            builder.HasOne(x => x.Unknows).WithOne(x => x.Word).HasForeignKey<Unknows>(x => x.WordId);
        }
    }
}
