using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rdp.Data.Entities;

namespace rdp.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                new ApplicationUser { Name = "Furkan", SurName = "Kus", Id = 1 },
                new ApplicationUser { Name = "Sena", SurName = "Kus", Id = 2 },
                new ApplicationUser { Name = "Timur", SurName = "Kus", Id = 3 });


            //builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Accounts)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Name).IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.SurName).IsRequired()
                .HasMaxLength(50);
        }
    }
}